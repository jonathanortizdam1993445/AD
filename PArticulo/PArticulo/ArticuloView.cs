using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Org.InstitutoSerpis.Ad;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView (Articulo articulo) : base(Gtk.WindowType.Toplevel) {
			this.Build ();

			entryNombre.Text = articulo.Nombre;
			spinButtonPrecio.Value = (double)articulo.Precio;
			fillComboBoxCategoria(articulo.Categoria);

			refreshactions ();

			saveAction.Activated += delegate {
				articulo.Nombre = entryNombre.Text;
				articulo.Precio = (decimal)spinButtonPrecio.Value;
				articulo.Categoria = (long?)ComboBoxHelper.GetId(comboBoxCategoria);

				ArticuloDao.Save(articulo);
			};

			entryNombre.Changed += delegate {
				refreshactions();
			};
		}

		private void refreshactions(){
			string content = entryNombre.Text.Trim();
			saveAction.Sensitive = content != string.Empty;
		}

		private void fillComboBoxCategoria(object categoria) {
			IList list = CategoriaDao.GetList ();
			ComboBoxHelper.Fill(comboBoxCategoria, list, "Nombre", categoria);
		}
	}
}

