using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Gtk;
using Org.InstitutoSerpis.Ad;

namespace PArticulo
{
	
	public class ArticuloDao
	{

		private const string SELECT_SQL = "select * from articulo";

		public static List<Articulo> GetList(){
			List<Articulo> list = new List<Articulo>();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = SELECT_SQL;
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
			return list;
		}

		private const string INSERT_SQL = "insert into articulo (nombre, precio, categoria) " +
			"values (@nombre, @precio, @categoria)";
		public static void save(Articulo articulo){

			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
			dbCommand.CommandText = INSERT_SQL;
			DbCommandHelper.AddParameter(dbCommand, "nombre", articulo.Nombre);
			DbCommandHelper.AddParameter(dbCommand, "precio", articulo.Precio);
			DbCommandHelper.AddParameter(dbCommand, "categoria", articulo.Categoria);
			dbCommand.ExecuteNonQuery();
		}
		private const string DELETE_SQL="delete from articulo where id=@id";

		public static void deletete(object id){
			IDbCommand dbcommand = App.Instance.DbConnection.CreateCommand ();
			dbcommand.CommandText = DELETE_SQL;
	//		long id=(long)TreeViewHelper.GetId (id);
			DbCommandHelper.AddParameter (dbcommand, "id", id);
			dbcommand.ExecuteNonQuery ();
			//TODO LANZAR EXCEPCION SI NO ELIMNIA REGISTRO
		
		}


	}
}

