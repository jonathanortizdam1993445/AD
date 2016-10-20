using System;

namespace PGTKArticuloLuis
{
	public class Articulo
	{
		public Articulo (long id, String nombre, decimal? precio,long? categoria){
			ID = id;
			Nombre = nombre;
			Precio = precio;
			Categoria = categoria;
		}

		public long ID {get; set;}
		public string Nombre{get; set;}
		public decimal? Precio {get; set;}// ? Para que pueda tener null
		public long? Categoria {get; set;}// ? Para que pueda tener null             
	}
}

