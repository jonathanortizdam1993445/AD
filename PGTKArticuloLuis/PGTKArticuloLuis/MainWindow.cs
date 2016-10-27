using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

using Org.InstitutoSerpis.Ad;
using PGTKArticuloLuis;


public partial class MainWindow: Gtk.Window
{	

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{

		Build ();

		App.Instance.Dbconnection = new MySqlConnection ("Database = dbprueba; User Id=root; Password=sistemas");

		App.Instance.Dbconnection.Open ();

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

	private void fill() {
		List<Articulo> list = new List<Articulo>();
		string selectSql = "select * from articulo";
		IDbCommand dbCommand = App.Instance.Dbconnection.CreateCommand ();
		dbCommand.CommandText = selectSql;
		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			long id = (long)dataReader ["id"];
			string nombre = (string)dataReader ["nombre"];
			decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?)dataReader ["precio"];
			long? categoria = dataReader["categoria"] is DBNull ? null : (long?)dataReader["categoria"];
			Articulo articulo = new Articulo(id, nombre, precio, categoria);
			list.Add (articulo);
		}
		dataReader.Close ();

		editAction.Sensitive = false;
		deleteAction.Sensitive = false;

		TreeViewHelper.Fill (treeview1, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		App.Instance.Dbconnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}
