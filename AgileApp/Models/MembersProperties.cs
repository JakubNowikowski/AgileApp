using Prism.Mvvm;
using System.Windows.Controls;

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
			private int _id;
			public int Id
			{
				get { return _id; }
				set { _id = value; }
			}
			private string _name;

			public string Name
			{
				get { return _name; }
				set { _name = value; }
			}
		}

	}
}
