package org.institutoserpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.DecimalFormat;
import java.util.Scanner;

import javax.swing.plaf.synth.SynthDesktopIconUI;

public class GArticulo {
	
private static Connection connection;
private static Scanner tcl;

	public static void main(String[] args) throws SQLException{
		connection=DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba", 
				"root", 
				"sistemas");
		
		System.out.println("Menu");
		System.out.println("*******************");
		System.out.println("1.NUEVO");
		System.out.println("2.MODIFICAR");
		System.out.println("3.ELIMINAR");
		System.out.println("4.CONSULTAR");
		System.out.println("5.LISTAR TODOS");
		System.out.println("0.SALIR");
		System.out.println("*******************");
		
		
		tcl = new Scanner(System.in);
		int opcion=0;
		do {
		System.out.println("Selecciona una opcion");
		opcion=tcl.nextInt();
		
		switch (opcion) {
		case 1:
			System.out.println("NUEVO");
			nuevo();
			break;
			
		case 2:
			System.out.println("MODIFICAR");
			modificar();
			break;
			
		case 3:	
			System.out.println("ELIMINAR");
			eliminar();
			break;
		case 4:
			System.out.println("CONSULTAR");
			consultar();
			break;
		case 5:
			System.out.println("LISTAR TODOS");
			listartodos();
			break;
			
		case 0:
			System.out.println("SALIR");
			break;
			
		default:
			System.out.println("opcion no valida");
			break;
		}
		} while (opcion!=0);
	}
	
	public static void nuevo() throws SQLException{
		
		System.out.println("Indica el nombre");
		String nombre=tcl.next();
		
		System.out.println("Indica el precio");
		Double precio=tcl.nextDouble();
		
		System.out.println("Indica la categoria");
		int categoria=tcl.nextInt();
		
		String sql="INSERT INTO articulo (id,nombre,precio,categoria) "
				+ "VALUES (id,?,?,?)";
		PreparedStatement ps= connection.prepareStatement(sql);
		
		ps.setString(1, nombre);
		ps.setDouble(2, precio);
		ps.setInt(3, categoria);
		
		ps.executeUpdate();
		ps.close();
	}
	
	public static void modificar() throws SQLException{
		
		listartodos();
		
		System.out.println("Indica el id");
		int id=tcl.nextInt();
		
		System.out.println("Indica el nuevo nombre");
		String nombrenuevo=tcl.next();
		
		System.out.println("Indica el nuevo precio");
		Double precionuevo=tcl.nextDouble();
		
		System.out.println("Indica la nueva categoria");
		int categorianuevo=tcl.nextInt();
		
		String sql="UPDATE articulo SET nombre=?,precio=?,categoria=? "
				+ "where id='"+id+"'";
		
		PreparedStatement ps= connection.prepareStatement(sql);
		
		ps.setString(1, nombrenuevo);
		ps.setDouble(2, precionuevo);
		ps.setInt(3, categorianuevo);
		
		ps.executeUpdate();
		ps.close();
	}
	public static void eliminar() throws SQLException{
		System.out.println("Indica el id");
		int id=tcl.nextInt();
		
		String sql="DELETE FROM articulo where id='"+id+"'";
		
		PreparedStatement ps= connection.prepareStatement(sql);
		
		ps.executeUpdate();
		ps.close();
	}
	public static void consultar() throws SQLException{
		System.out.println("Indica el id");
		int id=tcl.nextInt();
		
		String sql="SELECT * FROM articulo where id='"+id+"'";
		
		PreparedStatement ps= connection.prepareStatement(sql);
		System.out.printf("%5s %30s %10s %5s\n", "id", "nombre", "precio","categoria");
		ResultSet rs = ps.executeQuery();
		while (rs.next()) {
			System.out.printf("%5s %30s %10s %5s\n",rs.getInt("id"),rs.getString("nombre"),rs.getDouble("precio"),rs.getInt("categoria"));
			System.out.println();
			
		}
		rs.close();
		ps.close();
	}
	public static void listartodos() throws SQLException{
		String sql="SELECT * FROM articulo";
		
		PreparedStatement ps= connection.prepareStatement(sql);
		System.out.printf("%5s %30s %10s %5s\n", "id", "nombre", "precio","categoria");
		ResultSet rs = ps.executeQuery();
		while (rs.next()) {
			System.out.printf("%5s %30s %10s %5s\n",rs.getInt("id"),rs.getString("nombre"),rs.getDouble("precio"),rs.getInt("categoria"));
			System.out.println();
		}
		rs.close();
		ps.close();
	}

}
