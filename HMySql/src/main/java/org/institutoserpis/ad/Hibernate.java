package org.institutoserpis.ad;

import java.util.Calendar;
import java.util.List;
import java.util.Date;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class Hibernate {

	public static void main(String[] args) {
		
		EntityManagerFactory entityManagerFactory = 
				Persistence.createEntityManagerFactory("org.institutoserpis.ad.hmysql");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
	/*	Categoria categoria = new Categoria();
		categoria.setNombre("nueva " + Calendar.getInstance().getTime());
	//	entityManager.persist(categoria);
	//	System.out.printf("%d %s\n", categoria.getId(), categoria.getNombre());
		
		List<Categoria> categorias = entityManager.createQuery("from Categoria", Categoria.class).getResultList();
		for (Categoria item : categorias){
			System.out.printf("%d %s\n", item.getId(), item.getNombre());
		}
		*/
		//LEER
		Articulo articulo=entityManager.find(Articulo.class, 5L);
		System.out.println(articulo);
		
		//MODIFICAR ARTICULO
		articulo.setNombre("articulo modificado "+Calendar.getInstance().getTime());
		entityManager.persist(articulo);
		
		//MODIFICAR CATEGORIA
		Categoria categoria=entityManager.find(Categoria.class, 8L);
		articulo.setCategoria(categoria);
		entityManager.persist(articulo);
		
		//ELIMINAR
		
		
		//Articulo articulo = new Articulo();
		//articulo.setNombre("nueva " + Calendar.getInstance().getTime());
		//entityManager.persist(categoria);
		
		//List<Articulo> articulos = entityManager.createQuery("from Articulo", Articulo.class).getResultList();
		//for (Articulo item : articulos){
		//	System.out.printf("%d %s %s %s \n", item.getId(), item.getNombre(), item.getPrecio(), item.getCategoria());
			
		//}
		
		entityManager.getTransaction().commit();
		entityManager.close();
		entityManagerFactory.close();
	}
}
