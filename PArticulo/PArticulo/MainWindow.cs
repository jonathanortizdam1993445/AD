using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;

using Org.InstitutoSerpis.Ad;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
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
			new ArticuloView();
		};

		deleteAction.Activated+= delegate {
			MessageDialog messagedialog = new MessageDialog(
				this,
				DialogFlags.Modal,
				MessageType.Question,
				ButtonsType.YesNo,
				"¿Quieres eliminar el registro?");
			ResponseType Response =(ResponseType)messagedialog.Run();
			messagedialog.Destroy();
			if (Response !=ResponseType.Yes){
				return;
				Console.WriteLine("id ='{0}' ",TreeViewHelper.GetId(treeView));

			}
			else{
				ArticuloDao.deletete(TreeViewHelper.GetId(treeView));
				refreshAction.Activate();
				return;
			}
	};


		refreshAction.Activated += delegate {
			fill();
		};

		new ArticuloView ();
	}

	private void fill() {

		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		IList list = ArticuloDao.GetList();

		TreeViewHelper.Fill (treeView, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		App.Instance.DbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}
