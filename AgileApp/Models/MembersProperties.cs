using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgileApp.Models
{
	class MembersProperties : BindableBase
	{

		private StackPanel _stkPanel;
		public StackPanel stkPanel
		{
			get { return _stkPanel; }
			set { SetProperty(ref _stkPanel, value); }
		}


		private string _message;
		public string Message
		{
			get { return _message; }
			set { SetProperty(ref _message, value); }
		}

		//ComboBox list 

		public class Person
		{
			public int Id { get; set; }

			public string Name { get; set; }

		}

		//Dynamic button

		public class ButtonModel
		{

			public string Content { get; set; }

			public ICommand Command { get; set; }

		}

		// Dynamic combobox


		public class ComboboxModel
		{

			public ObservableCollection<Person> ItemsSource { get; set; }

			public Person SelectedItem { get; set; }

		}

		//public class SomeDataModel
		//{
		//	public string Content { get; set; }

		//	public ICommand Command { get; set; }

		//	public SomeDataModel(string content, ICommand command)
		//	{
		//		Content = content;
		//		Command = command;
		//	}
		//}

	}
}
