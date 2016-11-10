using System;
using Gtk;

namespace Org.InstitutoSerpis.Ad
{
	public class WindowHelper
	{
		public static bool Confirm(Window parent,string message){
			MessageDialog messagedialog = new MessageDialog(
				parent,
				DialogFlags.Modal,
				MessageType.Question,
				ButtonsType.YesNo,
				message
				);
			messagedialog.Title = parent.Title;
			ResponseType response =(ResponseType)messagedialog.Run();
			messagedialog.Destroy();
			return response == ResponseType.Yes;

		}
	}
}

