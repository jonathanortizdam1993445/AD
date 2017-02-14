package org.institutoserpis.ad;

import java.math.BigDecimal;
import java.sql.Date;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Scanner;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import java.util.*;

public class Hibernate {
	
	private static Scanner tcl;
	private static EntityManager entityManager; 
	private static EntityManagerFactory entityManagerFactory;
	private static ResultSet rs;
	
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
						listarcliente();
						System.out.println("Introduce el id del cliente");
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
				int opci2=0;
				System.out.println("MODIFICAR");
				System.out.println();
				System.out.println("7. Cliente");
				System.out.println("8. Pedido");
				System.out.println("9. Salir");
				opci2=tcl.nextInt();
				
					if(opci2==7) {
						System.out.println("Vas a modificar un cliente");
						listarcliente();
						System.out.println("Indica el id");
						String id=tcl.next();
						System.out.println("Introduce el nombre nuevo");
						String nombre=tcl.next();
						modificarcliente(id,nombre);
						break;
					}
						
						
					if(opci2==8){
						System.out.println("Vas a modificar un pedido");
						listarpedido();
						System.out.println("Introduce el id del pedido");
						String id=tcl.next();
						System.out.println("Introduce el id del cliente");
						String idcli=tcl.next();
						System.out.println("Introduce el importe");
						BigDecimal importe=tcl.nextBigDecimal();
						modificarpedido(idcli,id,importe);
						break;
					}
					
					if(opci2==9){
						System.out.println("Has salido de la opción insertar");
						break;
					}
				break;
			
			case 3:
						int opci3=0;
						System.out.println("ELIMINAR");
						System.out.println();
						System.out.println("7. Cliente");
						System.out.println("8. Pedido");
						System.out.println("9. Salir");
						opci3=tcl.nextInt();
						
							if(opci3==7) {
								System.out.println("Vas a eliminar un cliente");
								listarcliente();
								System.out.println("Indica el id");
								String nombre=tcl.next();
								eliminarcliente(nombre);
								break;
							}
								
								
							if(opci3==8){
								System.out.println("Vas a eliminar un pedido");
								listarpedido();
								System.out.println("Introduce el id del cliente");
								String nombre=tcl.next();
								eliminarpedido(nombre);
								break;
							}
							
							if(opci3==9){
								System.out.println("Has salido de la opción insertar");
								break;
							}					
			
			case 4:
				int opci4=0;
				System.out.println("CONSULTAR");
				System.out.println();
				System.out.println("7. Cliente");
				System.out.println("8. Pedido");
				System.out.println("9. Salir");
				opci4=tcl.nextInt();
				
					if(opci4==7) {
						System.out.println("Introduce el id");
						String id=tcl.next();
						consultarcliente(id);;
						break;
					}
						
						
					if(opci4==8){
						System.out.println("Introduce el id");
						String id=tcl.next();
						consultarpedido(id);
						break;
					}
					
					if(opci4==9){
						System.out.println("Has salido de la opción insertar");
						break;
					}
				
				
				break;
			
			case 5:
				int opci5=0;
				System.out.println("LISTAR TODOS");
				System.out.println();
				System.out.println("7. Cliente");
				System.out.println("8. Pedido");
				System.out.println("9. Salir");
				opci5=tcl.nextInt();
				
					if(opci5==7) {
						listarcliente();
						break;
					}
						
						
					if(opci5==8){
						listarpedido();
						break;
					}
					
					if(opci5==9){
						System.out.println("Has salido de la opción insertar");
						break;
					}
					
				break;
			/*
			 * 
			 * 
			case 0:
				System.out.println("Has salido del programa");
				break;
			*/

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
	
	public static void eliminarcliente(String idcliente){
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Cliente cliente = entityManager.getReference(Cliente.class,Long.parseLong(idcliente));
		
		entityManager.remove(cliente);
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
	}
	
	public static void eliminarpedido(String idpedido){
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Pedido pedido = entityManager.getReference(Pedido.class,Long.parseLong(idpedido));
		
		entityManager.remove(pedido);
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
	}
	
	
	public static void listarcliente(){
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Cliente cliente = new Cliente();
		
		System.out.printf("%5s %30s\n", cliente.getId(), cliente.getNombre());
		
		List<Cliente> clientes =entityManager.createQuery("from Cliente", Cliente.class).getResultList();
		
		for (Cliente item: clientes) {
			System.out.printf("%5s %30s\n",item.getId(),item.getNombre());
			
		}
		entityManager.getTransaction().commit();
		entityManager.close();
		
	}
	
	public static void listarpedido(){
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Pedido pedido = new Pedido();
		
		//System.out.printf("%d %s %s %s\n", pedido.getId(), pedido.getCliente(),pedido.getFecha(),pedido.getImporte());
		
		List<Pedido> pedidos =entityManager.createQuery("from Pedido", Pedido.class).getResultList();
		
		for (Pedido item: pedidos) {
			Cliente cli=item.getCliente();
			System.out.printf("%d %s %s %s\n",item.getId(),"cliente["+cli.getId(),cli.getNombre()+"]",item.getImporte());
			
		}
		entityManager.getTransaction().commit();
		entityManager.close();
		
	}
	
	public static void consultarcliente(String id){
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Cliente cliente=entityManager.getReference(Cliente.class,Long.parseLong(id));
		
		System.out.printf("%d %s\n", cliente.getId(), cliente.getNombre());
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
	}
	
	public static void consultarpedido(String id){
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Pedido pedido=entityManager.getReference(Pedido.class,Long.parseLong(id));
		
		System.out.printf("%d %s %s %s\n", pedido.getId(),"cliente["+pedido.getId(),pedido.getCliente()+"]",pedido.getFecha(),pedido.getImporte());
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
	}
	
	public static void modificarcliente(String idcliente, String nombre){
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Cliente cliente=entityManager.getReference(Cliente.class,Long.parseLong(idcliente));
		
		cliente.setNombre(nombre);
		entityManager.flush();
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
	}
	
	public static void modificarpedido(String idcliente, String idpedido, BigDecimal importe){
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Cliente cliente=entityManager.getReference(Cliente.class,Long.parseLong(idcliente));
		
		Pedido pedido=entityManager.getReference(Pedido.class,Long.parseLong(idpedido));
		
		pedido.setCliente(cliente);
		pedido.setImporte(importe);
		entityManager.flush();
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
	}
	
	
}


