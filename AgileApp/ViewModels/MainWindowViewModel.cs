using AgileApp.Models;
using AgileApp.Views;
using Prism.Mvvm;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using System.Collections.ObjectModel;
using static AgileApp.Models.MembersProperties;
using System.Data;

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
		private readonly StackPanel _stkpnlTeamMembers;



		public ICommand AddNewMemberCommand { get; private set; }
		public ICommand AddJerryCommand { get; private set; }
		public ICommand AddJohnnyCommand { get; private set; }
		public ICommand ClearStkpnlProductOwner { get; private set; }
		public ICommand ClearStkpnlProjectManager { get; private set; }
		public ICommand MyCommand { get; set; }



		public MainWindowViewModel(StackPanel stkpnlProductOwner, StackPanel stkpnlProjectManager, StackPanel stkpnlScrumMaster, StackPanel stkpnlArchitect, StackPanel stkpnlDevTeam, StackPanel stkpnlTeamMembers)
		{
			//this.dialogService = dialogService;
			//DisplayMessageCommand = new DelegateCommand(p => DisplayMessage());
			//DisplayUserName = new DelegateCommand(p => SetUserName());


			Persons = new ObservableCollection<Person>()
			{
			new Person(){ Id=1, Name="Product Owner"}
				,new Person(){Id=2,Name="Project Manager"}
				,new Person(){Id=3 , Name="Scrum Master"}
				,new Person(){Id=4 , Name="Architect"}
				,new Person(){Id=5 , Name="Dev team"}
			};

			//MyData = new ObservableCollection<SomeDataModel>()
			//{
			//new SomeDataModel(){ Content="Jerry", Command=MyCommand}
			//};

			_stkpnlProjectManager = stkpnlProjectManager;
			_stkpnlProductOwner = stkpnlProductOwner;
			_stkpnlScrumMaster = stkpnlScrumMaster;
			_stkpnlArchitect = stkpnlArchitect;
			_stkpnlDevTeam = stkpnlDevTeam;
			_stkpnlTeamMembers = stkpnlTeamMembers;


			_userProp = new MembersProperties();
			//_userProp.stkPanel = stkpnlProjectManager;
			AddJerryCommand = new DelegateCommand(() => AddMemberToStackPanel("Jerry"));
			AddJohnnyCommand = new DelegateCommand(() => AddMemberToStackPanel("Johnny"));
			ClearStkpnlProductOwner = new DelegateCommand(() => ClearStackPanel(stkpnlProductOwner));
			ClearStkpnlProjectManager = new DelegateCommand(() => ClearStackPanel(stkpnlProjectManager));
			AddNewMemberCommand = new DelegateCommand(AddNewMember);
			MyCommand = new DelegateCommand(() => AddMemberToStackPanel("MyCommand"));

			//MyCommand = new DelegateCommand(executemethod, canexecutemethod);
		}

		private void ShowAddWindow()
		{
			AddWindow objAddWindow = new AddWindow();
			objAddWindow.Show();
		}

		private string _memberName;

		public string MemberName
		{
			get { return _memberName; }
			set
			{
				_memberName = value;
				RaisePropertyChanged("MemberName");
			}
		}

		private void AddNewMember()
		{

			_userProp.stkPanel = _stkpnlTeamMembers;

			//MyData = new ObservableCollection<SomeDataModel>()
			//{
			//new SomeDataModel(){ Content="Jerry", Command=MyCommand}
			//};


			NewAddButton.Add(new ButtonModel() {Content="Jerry", Command=MyCommand });

			NewCombobox.Add(new ComboboxModel() { ItemsSource = Persons, SelectedItem = SPerson });

			//NewCombobox.Add(new ComboboxModel());

			//MyData.Add()

			//StackPanel lbl = new StackPanel()
			//{

			//	Name = MemberName
			//};
			//_userProp.stkPanel.Children.Add(lbl);

		}

		//private ObservableCollection<SomeDataModel> _MyData = new ObservableCollection<SomeDataModel>();
		//public ObservableCollection<SomeDataModel> MyData { get { return _MyData; } }


		private ObservableCollection<ButtonModel> _newAddButton = new ObservableCollection<ButtonModel>();
		public ObservableCollection<ButtonModel> NewAddButton 
		{
			get { return _newAddButton; }
			set { _newAddButton = value; RaisePropertyChanged("MyData"); }
		}
		//public ObservableCollection<Person> Persons
		//{
		//	get { return _persons; }
		//	set { _persons = value; }
		//}

		private ObservableCollection<ComboboxModel> _newCombobox = new ObservableCollection<ComboboxModel>();
		public ObservableCollection<ComboboxModel> NewCombobox
		{
			get { return _newCombobox; }
			set { _newCombobox = value; RaisePropertyChanged("NewCombobox"); }
		}



		public MembersProperties UserProperties
		{
			get { return _userProp; }
			set { SetProperty(ref _userProp, value); }
		}

		private void AddMemberToStackPanel(string memberName)
		{
			MatchRoleWithStackPanel();

			TextBlock lbl = new TextBlock()
			{
				Text = memberName
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

		private void ClearStackPanel(StackPanel stkpnl)
		{
			stkpnl.Children.Clear();
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
			set { _sperson = value; RaisePropertyChanged("SPerson"); }
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
