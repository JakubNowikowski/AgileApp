using AgileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AgileApp.Services
{
	public class DialogService
	{

		Window addWindow = null;

		public DialogService()
		{
		}

		public void ShowAddWindow()
		{
			addWindow = new AddWindow();
			addWindow.ShowDialog();
		}

		public void CloseDetailDialog()
		{
			if (addWindow != null)
				addWindow.Close();
		}
	}
}
