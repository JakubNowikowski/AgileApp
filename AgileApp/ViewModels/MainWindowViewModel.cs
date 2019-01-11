using AgileApp.Models;
using AgileApp.Views;
using Prism.Mvvm;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AgileApp.Services;
using AgileApp.Utility;
using AgileApp.Messages;
using AgileApp.Extensions;
using System;

namespace AgileApp.ViewModels
{
	//class MainWindowViewModel : BindableBase
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private DialogService dialogService = new DialogService();

		private bool CanDeleteMember(object obj)
		{
			if (SelectedMember != null)
				return true;


			return false;
		}

		private void DeleteMember(object member)
		{
			memberDataService.DeleteMember(selectedMember.MemberId);

			Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
		}


		public event PropertyChangedEventHandler PropertyChanged;
		private MemberDataService memberDataService;

		private ObservableCollection<Member> members;
		public ObservableCollection<Member> Members
		{
			get
			{
				return members;
			}
			set
			{
				members = value;
				RaisePropertyChanged("Members");
			}
		}

		private Member selectedMember;

		public Member SelectedMember
		{
			get
			{
				return selectedMember;
			}
			set
			{
				selectedMember = value;
				RaisePropertyChanged("SelectedMember");
			}
		}

		public ICommand EditCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand AddCommand { get; set; }
		public ICommand OpenAddWindowCommand { get; set; }

		private void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public MainWindowViewModel()
		{
			memberDataService = new MemberDataService();
			LoadData();

			LoadCommands();

			Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
		}

		private void LoadCommands()
		{
			//EditCommand = new CustomCommand(EditMember, CanEditMember);
			DeleteCommand = new CustomCommand(DeleteMember, CanDeleteMember);
			//AddCommand = new CustomCommand(AddMember, CanAddMember);
			OpenAddWindowCommand = new CustomCommand(OpenAddWindow, CanAddMember);

		}

		private void OpenAddWindow(object obj)
		{
			Messenger.Default.Send<Member>(selectedMember);

			dialogService.ShowAddWindow();
		}

		private bool CanAddMember(object obj)
		{
			return true;
		}

		//private void AddMember(object obj)
		//{
		//	memberDataService.AddMember(selectedMember.MemberId);

		//	Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
		//}

		private void OnUpdateListMessageReceived(UpdateListMessage obj)
		{
			LoadData();
			dialogService.CloseDetailDialog();
		}



		private void EditMember(object obj)
		{
			//Messenger.Default.Send<Member>(selectedMember);

			//dialogService.ShowDetailDialog();
		}

		private bool CanEditMember(object obj)
		{
			if (SelectedMember != null)
			{
				return true;
			}
			return false;
		}

		private void LoadData()
		{
			Members = memberDataService.GetAllMembers().ToObservableCollection();
		}

		//private Member _userProp;

		//private readonly StackPanel _stkpnlProjectManager;
		//private readonly StackPanel _stkpnlProductOwner;
		//private readonly StackPanel _stkpnlScrumMaster;
		//private readonly StackPanel _stkpnlArchitect;
		//private readonly StackPanel _stkpnlDevTeam;
		//private readonly StackPanel _stkpnlTeamMembers;

		//public ICommand AddMemberCommand { get; private set; }
		//public ICommand ClearStkpnlProductOwner { get; private set; }
		//public ICommand ClearStkpnlProjectManager { get; private set; }
		//public ICommand MyCommand { get; set; }



		//public MainWindowViewModel(StackPanel stkpnlProductOwner, StackPanel stkpnlProjectManager, StackPanel stkpnlScrumMaster, StackPanel stkpnlArchitect, StackPanel stkpnlDevTeam, StackPanel stkpnlTeamMembers)
		//{
		//	Persons = new ObservableCollection<Person>()
		//	{
		//	new Person(){ Id=1, Name="Product Owner"}
		//		,new Person(){Id=2,Name="Project Manager"}
		//		,new Person(){Id=3 , Name="Scrum Master"}
		//		,new Person(){Id=4 , Name="Architect"}
		//		,new Person(){Id=5 , Name="Dev team"}
		//	};

		//	_stkpnlProjectManager = stkpnlProjectManager;
		//	_stkpnlProductOwner = stkpnlProductOwner;
		//	_stkpnlScrumMaster = stkpnlScrumMaster;
		//	_stkpnlArchitect = stkpnlArchitect;
		//	_stkpnlDevTeam = stkpnlDevTeam;
		//	_stkpnlTeamMembers = stkpnlTeamMembers;


		//	_userProp = new Member();
		//	//_userProp.stkPanel = stkpnlProjectManager;
		//	AddMemberCommand = new DelegateCommand(() => AddMemberToStackPanel(MemberName));
		//	ClearStkpnlProductOwner = new DelegateCommand(() => ClearStackPanel(stkpnlProductOwner));
		//	ClearStkpnlProjectManager = new DelegateCommand(() => ClearStackPanel(stkpnlProjectManager));


		//	//MyCommand = new DelegateCommand(executemethod, canexecutemethod);
		//}

		//private void ShowAddWindow()
		//{
		//	AddWindow objAddWindow = new AddWindow();
		//	objAddWindow.Show();
		//}

		//private string _memberName;

		//public string MemberName
		//{
		//	get { return _memberName; }
		//	set
		//	{
		//		_memberName = value;
		//		RaisePropertyChanged("MemberName");
		//	}
		//}

		//private void AddNewMember()
		//{

		//	_userProp.stkPanel = _stkpnlTeamMembers;
		//}
		//public Member UserProperties
		//{
		//	get { return _userProp; }
		//	set { SetProperty(ref _userProp, value); }
		//}

		//private void AddMemberToStackPanel(string memberName)
		//{
		//	MatchRoleWithStackPanel();

		//	TextBlock lbl = new TextBlock()
		//	{
		//		Text = memberName
		//	};
		//	_userProp.stkPanel.Children.Add(lbl);
		//	//_userProp.stkPanel.RegisterName(lbl.Name, lbl);
		//}

		//private void MatchRoleWithStackPanel()
		//{
		//	switch (SPerson.Name)
		//	{
		//		case "Project Manager":
		//			_userProp.stkPanel = _stkpnlProjectManager;
		//			break;
		//		case "Product Owner":
		//			_userProp.stkPanel = _stkpnlProductOwner;
		//			break;
		//		case "Scrum Master":
		//			_userProp.stkPanel = _stkpnlScrumMaster;
		//			break;
		//		case "Architect":
		//			_userProp.stkPanel = _stkpnlArchitect;
		//			break;
		//		case "Dev team":
		//			_userProp.stkPanel = _stkpnlDevTeam;
		//			break;
		//		default:
		//			_userProp.stkPanel = null;
		//			break;
		//	}
		//}

		//private void ClearStackPanel(StackPanel stkpnl)
		//{
		//	if (stkpnl.Children.Count > 0)
		//	{
		//		stkpnl.Children.RemoveAt(stkpnl.Children.Count - 1);
		//	}
		//}

		//private ObservableCollection<Person> _persons;

		//public ObservableCollection<Person> Persons
		//{
		//	get { return _persons; }
		//	set { _persons = value; }
		//}
		//private Person _sperson;

		//public Person SPerson
		//{
		//	get { return _sperson; }
		//	set { _sperson = value; RaisePropertyChanged("SPerson"); }
		//}
	}
}
