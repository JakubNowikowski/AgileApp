using AgileApp.Helpers;
using System.ComponentModel;
using System.Windows.Input;

namespace AgileApp.ViewModels
{
	public class MainWindowViewModel : ObservableObject
	{
		public MainWindowViewModel(IDialogService dialogService)
		{
			this.dialogService = dialogService;
			DisplayMessageCommand = new DelegateCommand(p => DisplayMessage());
			DisplayUserName = new DelegateCommand(p => SetUserName());
			//DisplayMessageCommand2 = new DelegateCommand(p => DisplayMessage2());
		}


		//public string getName()
		//{
		//	return addWindowVm.Name;
		//}

		private readonly IDialogService dialogService;

		private string _userName;

		public string UserName
		{
			get { return _userName; }
			set
			{
				_userName = AddWindowViewModel.Name;
				RaisePropertyChangedEvent("UserName");
			}
		}

		private void SetUserName()
		{
			UserName = "test";
		}

		//private void SetUserName()
		//{
		//	if (getName() == "Product owner")
		//		UserName = "test";
		//}


		//public ICommand SetUserNameText
		//{
		//	get { return new DelegateCommand(SetUserName1); }
		//}


		public ICommand DisplayMessageCommand { get; }
		public ICommand DisplayUserName { get; }

		//public ICommand DisplayMessageCommand2 { get; }

		private void DisplayMessage()
		{
			var viewModel = new AddWindowViewModel();

			bool? result = dialogService.ShowDialog(viewModel);

			if (result.HasValue)
			{
				if (result.Value)
				{
					// Accepted
				}
				else
				{
					// Cancelled
				}
			}
		}

		//public event PropertyChangedEventHandler PropertyChanged;

		//protected void RaisePropertyChangedEvent(string propertyName)
		//{
		//	var handler = PropertyChanged;
		//	if (handler != null)
		//		handler(this, new PropertyChangedEventArgs(propertyName));
		//}


		//private void DisplayMessage2()
		//{
		//	var viewModel = new DialogViewModel("elo");

		//	bool? result = dialogService.ShowDialog(viewModel);

		//	if (result.HasValue)
		//	{
		//		if (result.Value)
		//		{
		//			// Accepted
		//		}
		//		else
		//		{
		//			// Cancelled
		//		}
		//	}
		//}




		//private string _userName1;

		//public string UserName1
		//{
		//	get { return _userName1; }
		//	set
		//	{
		//		_userName1 = value;
		//		RaisePropertyChangedEvent("UserName1");
		//	}
		//}


		//public ICommand SetUserNameText
		//{
		//	get { return new DelegateCommand(SetUserName1); }
		//}

		//private void SetUserName1()
		//{
		//	UserName1 = "test";
		//}
	}
}
