using System;
using MySql.Data.MySqlClient;


namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("probando acceso a dbprueba");
			MySqlConnection mysqlconnection = new MySqlConnection(
				"Database=dbpruebas;User Id=root;Password=sistemas");

			mysqlconnection.Open ();

			//operaciones

			mysqlconnection.Close ();



		}
	}
}
