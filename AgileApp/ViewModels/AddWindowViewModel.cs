using AgileApp.Helpers;
using System;
using System.Windows.Input;

namespace AgileApp.ViewModels
{
	public class AddWindowViewModel : IDialogRequestClose
	{
		public AddWindowViewModel()
		{
			//Name = null;
			//SetRole = new DelegateCommand(p => f());
			//MyCommand = new DelegateCommand(executemethod, canexecutemethod);
			//OkCommand = new DelegateCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true)));

			//CancelCommand = new DelegateCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
		}
		
		//public ICommand SetRole { get; }
		//public ICommand MyCommand { get; set; }
		//public ICommand OkCommand { get; }
		////private string _name;
		//private string _test;

		public static string Name { get; set; }


		//public string Name
		//{
		//	get { return _name; }
		//	set
		//	{
		//		_name = value;
		//		RaisePropertyChangedEvent("Name");
		//	}
		//}

		//public static string test;
		

		//private void f()
		//{
		//	if (Name == "Product owner")
		//		test = Name;
		//}

		private bool canexecutemethod(object parameter)
		{
			if (parameter != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void executemethod(object parameter)
		{
			Name = (string)parameter;
		}

		//public ICommand CancelCommand { get; }
		public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
		public string Message { get; }

	}
}
