using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AgileApp.ViewModels
{
	public class Presenter : ObservableObject
	{
		private string _userName1;

		public string UserName1
		{
			get { return _userName1; }
			set
			{
				_userName1 = value;
				RaisePropertyChangedEvent("UserName1");
			}
		}

		//public ICommand OpenAddWindow => new DelegateCommand(() =>
		//{
		//	UserName1 = "eeeee";
		//});

		public ICommand SetUserNameText
		{
			get { return new DelegateCommand(SetUserName1); }
		}

		private void SetUserName1()
		{
			UserName1 = "test";
		}
	}
}
