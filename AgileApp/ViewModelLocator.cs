using AgileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileApp
{
	public class ViewModelLocator
	{
		private static MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
		private static AddWindowViewModel addWindowViewModel =	new AddWindowViewModel();

		public static AddWindowViewModel AddWindowViewModel
		{
			get
			{
				return addWindowViewModel;
			}
		}

		public static MainWindowViewModel MainWindowViewModel
		{
			get
			{
				return mainWindowViewModel;
			}
		}
	}
}
