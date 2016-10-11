using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Reflection;

namespace Org.InstitutoSerpis.Ad
{
	public class TreeViewHelper
	{
		public static void AppendColumns(TreeView treeView, string[] columnNames) {
			foreach (string columnName in columnNames) {
				treeView.AppendColumn (columnName, new CellRendererText (),
					delegate(TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
						int column = Array.IndexOf(treeView.Columns, tree_column);
						CellRendererText cellRendererText = (CellRendererText)cell;
						object value = tree_model.GetValue(iter, column);
						cellRendererText.Text = value.ToString();
					}
				);
			}
		}

		public static void AppendColumns(TreeView treeView, Type type){
			PropertyInfo[] propertyinfos = type.GetProperties ();
			List<String> propertyNames = new List<String>();
			foreach (PropertyInfo propertyinfo in propertyinfos)
			propertyNames.Add (propertyinfo.Name);
			AppendColumns (treeView, propertyNames.ToArray ());
		}


		public static void Fill (TreeView treeview, IList list){
			if (treeview.Columns.Length == 0) 
				return;
				Type listtype = list.GetType ();
				Type elementType = listtype.GetGenericArguments () [0];
				PropertyInfo[] propertyinfos = elementType.GetProperties ();
				foreach (PropertyInfo propertyinfo in propertyinfos) {
					String columname = propertyinfo.Name;
					treeview.AppendColumn (columname, new CellRendererText (),
					                      delegate(TreeViewColumn tree_column, CellRenderer Cell, TreeModel tree_model, TreeIter tree_iter) {
						object item = tree_model.GetValue (tree_iter, 0);
						object value = propertyinfo.GetValue (item, null);
						CellRendererText cellrenderertext = (CellRendererText)Cell;
						cellrenderertext.Text = value == null ? "" : value.ToString ();
					}
					);
				}


		}

		public static void appendValues (TreeView treeview, IList list){
			ListStore liststore = new ListStore (typeof(long));
			treeview.Model = liststore;
			foreach(object item in list){
				liststore.AppendValues (item);
			}
		}
	}
}

