package org.institutoserpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class ArticuloDao {
	public static void main(String[] args) throws SQLException{
	//public static void main(String[] args){
		
		Connection connection=DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba", 
				"root", 
				"sistemas");
		PreparedStatement ps= connection.prepareStatement("select * from articulo where id>?");
		
		ps.setObject(1, Long.parseLong(args[0]));
		ResultSet resultSet=ps.executeQuery();
		
		//Statement statement=connection.createStatement();
		//ResultSet resultSet= statement.executeQuery("SELECT * FROM articulo");
		
		System.out.printf("%5s %-30s %10s %5s\n", "id", "nombre", "precio","categoria");
		while (resultSet.next()) {
			
			System.out.printf("%5d %-30s %10s %5d\n",
					resultSet.getObject("id"),
					resultSet.getObject("nombre"),
					resultSet.getObject("precio"), 
					resultSet.getObject("categoria"));
			
		}
		
		ps.close();
			connection.close();	
			System.out.println("fin");


	}

}
