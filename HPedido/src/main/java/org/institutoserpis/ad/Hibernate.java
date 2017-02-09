package org.institutoserpis.ad;

import java.math.BigDecimal;
import java.sql.Date;
import java.util.Scanner;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import java.util.*;

public class Hibernate {
	
	private static Scanner tcl;
	private static EntityManager entityManager; 
	private static EntityManagerFactory entityManagerFactory;
	
	public static void main(String[] args){
		
		entityManagerFactory = Persistence.createEntityManagerFactory("org.institutoserpis.ad.hpedido");
	
		tcl = new Scanner(System.in);
		int opc = 0;
		
		System.out.println("MENÚ");
		System.out.println("----------------------------");
		System.out.println("1. Insertar");
		System.out.println("2. Modificar");
		System.out.println("3. Eliminar");
		System.out.println("4. Consultar");
		System.out.println("5. Listar");
		System.out.println("0. Salir");
		
		System.out.println("-----------------------------");
		
		do{
			System.out.println("Escoge una opción: ");
			opc = tcl.nextInt();
		
			switch (opc) {
			case 1:
				int opci=0;
				System.out.println("INSERTAR");
				System.out.println();
				System.out.println("7. Cliente");
				System.out.println("8. Pedido");
				System.out.println("9. Salir");
				opci=tcl.nextInt();
				
					if(opci==7) {
						System.out.println("Vas a insertar un cliente");
						System.out.println("Indica el nombre");
						String nombre=tcl.next();
						nuevocliente(nombre);
					}
						
						
					if(opci==8){
						System.out.println("Vas a insertar un pedido");
						System.out.println("Introduce el nombre del cliente");
						String nombre=tcl.next();
						System.out.println("Introduce el importe");
						BigDecimal total=tcl.nextBigDecimal();
						nuevopedido(nombre,total);
					}		
					if(opci==9){
						System.out.println("Has salido de la opción insertar");
						break;
					}
					
					
		
			case 2:
				System.out.println("Vas a modificar un articulo");
				System.out.println();
				//listar();
				//modificar();
				break;
			
			case 3:
				System.out.println("Vas a eliminar un artículo");
				System.out.println();
				//eliminar();
				break;
			
			case 4:
				System.out.println("Vas a consultar un artículo de tu base de datos");
				System.out.println();
				//consultar();
				break;
			
			case 5:
				System.out.println("Vas a listar los artículos de tu base de datos");
				System.out.println();
				//listar();
				break;
			
			case 0:
				System.out.println("Has salido del programa");
				break;

			default:
				System.out.println("Opción incorrecta");
				break;
			}
		}while(opc!=0);
		
}
	
	public static void nuevocliente(String nombre){
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Cliente cliente=new Cliente();
		cliente.setNombre(nombre);
		entityManager.persist(cliente);
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
public static void nuevopedido(String idcliente,BigDecimal importe){
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Cliente cliente2=entityManager.getReference(Cliente.class, Long.parseLong(idcliente));
		
		Pedido pedido = new Pedido();
		pedido.setCliente(cliente2);
		
		java.util.Date fec= Calendar.getInstance().getTime();
		
		Date date= new Date(fec.getDate());
		pedido.setFecha(date);
		pedido.setImporte(importe);
		
		entityManager.persist(pedido);
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	/*
	public static void modificar(){
		
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
		
	}
	public static void eliminar(){
		System.out.println("Indica el id");
		int id=tcl.nextInt();
		
		String sql="DELETE FROM articulo where id='"+id+"'";
		
		
	}
	public static void consultar(){
		System.out.println("Indica el id");
		int id=tcl.nextInt();
		
		String sql="SELECT * FROM articulo where id='"+id+"'";
		
		
		System.out.printf("%5s %30s %10s %5s\n", "id", "nombre", "precio","categoria");
		
		while (rs.next()) {
			System.out.printf("%5s %30s %10s %5s\n",rs.getInt("id"),rs.getString("nombre"),rs.getDouble("precio"),rs.getInt("categoria"));
			System.out.println();
			
		}
		
	}
	public static void listartodos(){
		String sql="SELECT * FROM articulo";
		
		
		System.out.printf("%5s %30s %10s %5s\n", "id", "nombre", "precio","categoria");
		ResultSet rs = ps.executeQuery();
		while (rs.next()) {
			System.out.printf("%5s %30s %10s %5s\n",rs.getInt("id"),rs.getString("nombre"),rs.getDouble("precio"),rs.getInt("categoria"));
			System.out.println();
		}
		
	}
	*/
}


