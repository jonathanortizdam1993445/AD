using System;
using System.Data;
using MySql.Data.MySqlClient;
using Gtk;
using PArticuloGTK;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();


		IDbConnection dbconnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=sistemas"
			);

		IDbCommand dbcomand = dbconnection.CreateCommand ();
		IDataReader query;

		dbconnection.Open ();

		ListStore lista = new ListStore (typeof(long), typeof(string),typeof(string),typeof(long));
		treeview2.Model = lista;

		treeview2.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeview2.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		treeview2.AppendColumn ("precio", new CellRendererText (), "text", 2);
		treeview2.AppendColumn ("categoria", new CellRendererText (), "text", 3);


		dbcomand.CommandText = "select * from articulo";

		query=dbcomand.ExecuteReader();

		//INTRODUCE LOS NOMBRES DE LA CABECERA


		while (query.Read()) {

			//para que lea y liste los datos de los campos

			lista.AppendValues (query["id"],query["nombre"]," "+query["precio"],query["categoria"]);

		}
		query.Close ();


		dbconnection.Close ();

	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnNewActionActivated (object sender, EventArgs e)
	{
		Nuevo abrir = new Nuevo ();
		abrir.Show ();
	}
	
	protected void OnQuitActionActivated (object sender, EventArgs e)
	{
		Application.Quit ();
	}
	protected void OnDeleteActionActivated (object sender, EventArgs e)
	{
		Eliminar delete = new Eliminar ();
		delete.Show ();
	}
	
}
