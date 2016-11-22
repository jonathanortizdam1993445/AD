using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;

using Org.InstitutoSerpis.Ad;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	private IEntityDao<Articulo> entityDao;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		App.Instance.DbConnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=sistemas"
		);
		App.Instance.DbConnection.Open ();

		fill ();

		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
		};

		newAction.Activated += delegate {
			Articulo articulo = new Articulo();
			articulo.Nombre=String.Empty;//los entry esperan que no sean null
			articulo.Precio = 0;//hasta que se permita null
			new ArticuloView(articulo);
		};

		editAction.Activated += delegate {
			Articulo articulo = entityDao.Load(TreeViewHelper.GetId(treeView));
			new ArticuloView(articulo);
		};

		deleteAction.Activated += delegate {
			if (WindowHelper.Confirm(this,"Quieres eliminar el registro?"))
				ArticuloDao.delete(TreeViewHelper.GetId(treeView));
		};

		refreshAction.Activated += delegate {
			fill();
		};
	}
	public IEntityDao<Articulo> EntityDao{
		set{entityDao = value;}
	}

	private void fill() {
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		//IList list = ArticuloDao.GetList ();
		IList list = EntityDao.GetList<Articulo> ();
		TreeViewHelper.Fill (treeView, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		App.Instance.DbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}
