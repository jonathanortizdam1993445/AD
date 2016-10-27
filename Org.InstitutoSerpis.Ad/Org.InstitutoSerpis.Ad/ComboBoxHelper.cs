using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using Gtk;

namespace Org.InstitutoSerpis.Ad
{
	
	public class ComboBoxHelper
	{
		public static void Fill(ComboBox comboBox, IList list, string propertyName) {
			Type listType = list.GetType ();
			Type elementType = listType.GetGenericArguments () [0];
			PropertyInfo propertyInfo = elementType.GetProperty (propertyName);
			ListStore listStore = new ListStore (typeof(object));
			TreeIter initialTreeIter = listStore.AppendValues (Null.Value);
			foreach (object item in list)
				listStore.AppendValues (item);
			comboBox.Model = listStore;
			comboBox.SetActiveIter (initialTreeIter);
			CellRendererText cellRendererText = new CellRendererText ();
			comboBox.PackStart (cellRendererText, false);
			comboBox.SetCellDataFunc (cellRendererText, 
			                          delegate(CellLayout cell_layout, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
				object item = tree_model.GetValue(iter, 0);
				object value = item == Null.Value ? 
					"<sin asignar>" : propertyInfo.GetValue(item, null);
				cellRendererText.Text = value.ToString();
			}
			);
		}
	}
}



