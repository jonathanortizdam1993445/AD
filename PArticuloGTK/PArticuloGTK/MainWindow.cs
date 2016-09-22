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
		ListStore lista = new ListStore (typeof(long), typeof(string),typeof(string),typeof(long));
		treeview2.Model = lista;

		dbconnection.Open ();

		dbcomand.CommandText = "select * from articulo";

		query=dbcomand.ExecuteReader();

		//INTRODUCE LOS NOMBRES DE LA CABECERA
		treeview2.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeview2.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		treeview2.AppendColumn ("precio", new CellRendererText (), "text", 2);
		treeview2.AppendColumn ("categoria", new CellRendererText (), "text", 3);

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


	//	IDbCommand dbcomand1 = dbconnection.CreateCommand ();

	//	IDbCommand dbcomand2 = dbconnection.CreateCommand ();

	//	IDataParameter parameter1 = dbcomand1.CreateParameter ();
	//	IDataParameter parameter2 = dbcomand1.CreateParameter ();
	//	IDataParameter parameter3 = dbcomand1.CreateParameter ();

	//	dbconnection.Open ();

		//LISTAR TODO SOBRE LA TABLA CATEGORIA
	//	dbcomand2.CommandText="select * from categoria";



		//INTRODUCCION DE DATOS
	//	Console.Write ("Introduce el nombre");
	//	String nombre = Console.ReadLine();

	//	Console.Write ("Indica el numero de categoria");
	//	int id = Console.Read ();

	//	dbcomand2.CommandText="insert into articulo (id,nombre,precio,categoria) values(id,@nombre,@precio,@categoria)";

	//	dbconnection.Close ();


	}

	protected void OnEditActionActivated (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}
	
	protected void OnDeleteActionActivated (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}
	
	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		refreshAction.Sensitive = treeview2.Selection.CountSelectedRows () > 0;
	}

	protected void OnQuitActionActivated (object sender, EventArgs e)
	{
		Application.Quit ();
	}
}
