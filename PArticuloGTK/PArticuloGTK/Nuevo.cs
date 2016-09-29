using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace PArticuloGTK
{
	public partial class Nuevo : Gtk.Window
	{
		public Nuevo () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}


		protected void OnButton1Clicked (object sender, EventArgs e)
		{
			try {
				IDbConnection dbconnection = new MySqlConnection (
					"Database=dbprueba;User Id=root;Password=sistemas"
				);

				dbconnection.Open ();

				IDbCommand dbcomand = dbconnection.CreateCommand ();
				dbcomand.CommandText = "insert into articulo (nombre,precio,categoria) values (@nombre,@precio,@categoria)";
				string nombre = texto.Text;
				String precio = entry2.Text;
				String categoria = entry3.Text;

				IDbDataParameter parameter = dbcomand.CreateParameter ();
				IDbDataParameter parameter2 = dbcomand.CreateParameter ();
				IDbDataParameter parameter3 = dbcomand.CreateParameter ();

				parameter.ParameterName = "nombre";
				parameter.Value = nombre;
				dbcomand.Parameters.Add (parameter);

				parameter2.ParameterName = "precio";
				parameter2.Value = precio;
				dbcomand.Parameters.Add (parameter2);

				parameter3.ParameterName = "categoria";
				parameter3.Value = categoria;
				dbcomand.Parameters.Add (parameter3);

			
				dbcomand.ExecuteNonQuery ();
				dbconnection.Close ();

				} catch (MySqlException ex) {
				ex.GetBaseException();
					Console.Write ("ID no existe");
					
				}
		}
	}
}






