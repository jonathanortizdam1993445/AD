using System;
using System.Data;

namespace Org.InstitutoSerpis.Ad
{
	public class DbcommandHelper
	{
		public static void AddParameter(IDbCommand dbinsert, String nom, object value){
			IDataParameter dbdataparameter = dbinsert.CreateParameter();
			dbdataparameter.ParameterName="nombre";
			dbdataparameter.Value=nom;
			dbinsert.Parameters.Add(dbdataparameter);

		}
	}
}

