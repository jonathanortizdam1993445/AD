using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using Gtk;

namespace Org.InstitutoSerpis.Ad
{
	public class ComboBoxHelper
	{
		public static void Fill (ComboBox ComboBox, IList list, String propertyname){
			Type listType = list.GetType ();
			Type elementType = listType.GetGenericArguments () [0];

			PropertyInfo propertyinfo = elementType.GetProperty (propertyname);

			ListStore listStore = new ListStore (typeof(object));
			foreach (object item in list)
				listStore.AppendValues (item);

			ComboBox.Model = listStore;

			CellRendererText cellRendererText = new CellRendererText();

			ComboBox.Model = listStore;

			ComboBox.PackStart (cellRendererText, false);

			ComboBox.SetCellDataFunc (cellRendererText, 
			                                   delegate(CellLayout cell_layout, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
				object item =tree_model.GetValue(iter,0);
				object value = propertyinfo.GetValue(item,null);
				cellRendererText.Text=value.ToString();

			});
		}
	}
}

