using AgileApp.Models;
using Prism.Mvvm;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using System.Collections.ObjectModel;
using static AgileApp.Models.MembersProperties;

namespace AgileApp.ViewModels
{
	class MainWindowViewModel : BindableBase
	{
		private MembersProperties _userProp;

		private readonly StackPanel _stkpnlProjectManager;
		private readonly StackPanel _stkpnlProductOwner;
		private readonly StackPanel _stkpnlScrumMaster;
		private readonly StackPanel _stkpnlArchitect;
		private readonly StackPanel _stkpnlDevTeam;

		public ICommand AddCommand { get; private set; }
		public ICommand MyCommand { get; set; }



		public MainWindowViewModel(StackPanel stkpnlProductOwner, StackPanel stkpnlProjectManager, StackPanel stkpnlScrumMaster, StackPanel stkpnlArchitect, StackPanel stkpnlDevTeam)
		{
			//this.dialogService = dialogService;
			////DisplayMessageCommand = new DelegateCommand(p => DisplayMessage());
			//DisplayUserName = new DelegateCommand(p => SetUserName());


			Persons = new ObservableCollection<Person>()
			{
			new Person(){ Id=1, Name="Product Owner"}
				,new Person(){Id=2,Name="Project Manager"}
				,new Person(){Id=3 , Name="Scrum Master"}
				,new Person(){Id=4 , Name="Architect"}
				,new Person(){Id=5 , Name="Dev team"}
			};

			_stkpnlProjectManager = stkpnlProjectManager;
			_stkpnlProductOwner = stkpnlProductOwner;
			_stkpnlScrumMaster = stkpnlScrumMaster;
			_stkpnlArchitect = stkpnlArchitect;
			_stkpnlDevTeam = stkpnlDevTeam;

			_userProp = new MembersProperties();
			//_userProp.stkPanel = stkpnlProjectManager;
			AddCommand = new DelegateCommand(AddMemberToStackPanel);
			//MyCommand = new DelegateCommand(executemethod, canexecutemethod);
		}

		public MembersProperties UserProperties
		{
			get { return _userProp; }
			set { SetProperty(ref _userProp, value); }
		}

		private void AddMemberToStackPanel()
		{
			MatchRoleWithStackPanel();

			_userProp.Message = SPerson.Name;
			TextBlock lbl = new TextBlock()
			{
				Text = "This is Dynamic Label"
			};
			_userProp.stkPanel.Children.Add(lbl);
			//_userProp.stkPanel.RegisterName(lbl.Name, lbl);
		}

		private void MatchRoleWithStackPanel()
		{
			switch (SPerson.Name)
			{
				case "Project Manager":
					_userProp.stkPanel = _stkpnlProjectManager;
					break;
				case "Product Owner":
					_userProp.stkPanel = _stkpnlProductOwner;
					break;
				case "Scrum Master":
					_userProp.stkPanel = _stkpnlScrumMaster;
					break;
				case "Architect":
					_userProp.stkPanel = _stkpnlArchitect;
					break;
				case "Dev team":
					_userProp.stkPanel = _stkpnlDevTeam;
					break;
				default:
					_userProp.stkPanel = null;
					break;
			}

		}

		private ObservableCollection<Person> _persons;

		public ObservableCollection<Person> Persons
		{
			get { return _persons; }
			set { _persons = value; }
		}
		private Person _sperson;

		public Person SPerson
		{
			get { return _sperson; }
			set { _sperson = value; }
		}


		//private string _userName;

		//public string Name { get; set; }

		//public string UserName
		//{
		//	get { return _userName; }
		//	set
		//	{
		//		_userName = Name;
		//		RaisePropertyChanged("UserName");
		//	}
		//}

		////public ICommand DisplayMessageCommand { get; }
		//public ICommand DisplayUserName { get; }

		//private bool canexecutemethod(object parameter)
		//{
		//	if (parameter != null)
		//	{
		//		return true;
		//	}
		//	else
		//	{
		//		return false;
		//	}
		//}

		//private void executemethod(object parameter)
		//{
		//	Name = (string)parameter;
		//}
	}
}
