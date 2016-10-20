using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

using Org.InstitutoSerpis.Ad;
using PGTKArticuloLuis;


public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{

		Build ();

		dbConnection = new MySqlConnection ("Database = dbprueba; User Id=root; Password=sistemas");

		dbConnection.Open ();

		fill ();

		treeview1.Selection.Changed += delegate(object sender, EventArgs e) {

			bool selected = treeview1.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
			Console.WriteLine ("ha ocurrido el evento treeView.Selection.Changed selected={0}",selected);

		};

		newAction.Activated += delegate {
			new ArticuloView();
		};

		refreshAction.Activated += delegate {
			fill();
		};


	}

	private void fill(){

		List <Articulo> list = new List<Articulo>();

		//Se puede porque es tipo referencia, decimal no porque es un tipo valor
		//pero si pones ? al lado del tipo de la variable si que se puede

		string selectSql = "select * from articulo";
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = selectSql;

		IDataReader datareader = dbCommand.ExecuteReader ();
		while (datareader.Read()) {
			long id = (long)datareader ["id"];
			string nombre = (string)datareader ["nombre"];
			decimal? precio = datareader ["precio"] is DBNull ? null : (decimal?)datareader ["precio"];
			long? categoria = datareader ["categoria"] is DBNull ? null : (long?)datareader ["categoria"];
			Articulo articulo = new Articulo (id, nombre, precio, categoria);
			list.Add (articulo);


		}

		datareader.Close ();

		editAction.Sensitive = false;
		deleteAction.Sensitive = false;


		TreeViewHelper.Fill (treeview1, list);

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}
