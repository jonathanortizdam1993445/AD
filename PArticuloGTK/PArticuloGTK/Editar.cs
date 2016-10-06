using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PArticuloGTK
{
	public partial class Editar : Gtk.Window
	{
		public Editar () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
		protected void OnButton1Clicked (object sender, EventArgs e)
		{
			try{
				IDbConnection dbconnection = new MySqlConnection (
					"Database=dbprueba;User Id=root;Password=sistemas"
					);

				dbconnection.Open ();

				IDbCommand dbcomand = dbconnection.CreateCommand ();
				dbcomand.CommandText = "update articulo set nombre='"+this.entry2.Text+"',precio='"+this.entry3.Text+"',categoria='"+this.entry4.Text+"'where id='"+this.entry1.Text+"';";

				// ASÍ NO FUNCIONA,SE SALE DEL PROGRAMA

		//		String id = entry1.Text;
		//		String nombre = entry2.Text;
		//		String precio = entry3.Text;
		//		String categoria = entry4.Text;
				
		//		IDbDataParameter parameter = dbcomand.CreateParameter ();
		//		IDbDataParameter parameter2 = dbcomand.CreateParameter ();
		//		IDbDataParameter parameter3 = dbcomand.CreateParameter ();
		//	    IDbDataParameter parameter4 = dbcomand.CreateParameter ();

		//		parameter.ParameterName = "id";
		//		parameter.Value = id;
		//		dbcomand.Parameters.Add (parameter);

		//		parameter2.ParameterName = "nombre";
		//		parameter2.Value = nombre;
		//		dbcomand.Parameters.Add (parameter2);

		//		parameter3.ParameterName = "precio";
		//		parameter3.Value = precio;
		//		dbcomand.Parameters.Add (parameter3);

		//		parameter4.ParameterName= "categoria";
		//		parameter4.Value = precio;
		//		dbcomand.Parameters.Add (parameter4);

				dbcomand.ExecuteNonQuery ();
				dbconnection.Close ();

				} catch (MySqlException ex) {
					ex.GetBaseException();
					Console.Write ("ID no existe");
				}
			}
		}
	}


