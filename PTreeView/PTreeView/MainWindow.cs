using Gtk;
using System;
using System.Collections.Generic;
using System.Collections;
using Org.InstitutoSerpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		//List <Categoria> categorias =new List<Categoria>();

		IList list = new List<Categoria> ();
		list.Add (new Categoria (1, "categoria1"));
		list.Add (new Categoria (2, "categoria2"));
		list.Add (new Categoria (3, "categoria3"));


		TreeViewHelper.Fill(treeView,list);

//		TreeViewHelper.AppendColumns (treeView, typeof(Articulo));
//
//		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(decimal));
//
//		listStore.AppendValues (1L, "artículo 1", 1.5m);
//		listStore.AppendValues (2L, "artículo 2", 2.5m);
//		treeView.Model = listStore;

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}

	public class Categoria{
		public Categoria(long id,String nombre){
			Id=id;
			Nombre=nombre;
		}
		public long Id{ get; set;}
		public string Nombre{ get; set;}
	}

	public class Articulo{
		public Articulo(long id, string nombre, decimal precio){
			Id=id;
			Nombre=nombre;
			Precio=precio;
		}
		public long Id { get; set;}
		public String Nombre { get; set;}
		public decimal Precio { get; set;}
	}


