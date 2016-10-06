using Gtk;
using System;
using Org.InstitutoSerpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		TreeViewHelper.AppendColumns (treeView, typeof(Articulo));
		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(decimal));
		listStore.AppendValues (1L, "artículo 1", 1.5m);
		listStore.AppendValues (2L, "artículo 2", 2.5m);
		treeView.Model = listStore;

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	public class Categoria{
		public long Id { get; set;}
		public String nombre { get; set;}
	}

	public class Articulo{
		public long Id { get; set;}
		public String nombre { get; set;}
		public decimal precio { get; set;}
	}

}
