using AgileApp.Helpers;
using System;
using Prism;
using System.Windows.Input;
using Prism.Mvvm;
using System.ComponentModel;
using AgileApp.Services;
using AgileApp.Models;
using AgileApp.Utility;
using AgileApp.Messages;

namespace AgileApp.ViewModels
{
	public class AddWindowViewModel : INotifyPropertyChanged
	{
		private MemberDataService memberDataService;
		public event PropertyChangedEventHandler PropertyChanged;


		private void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public ICommand SaveCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand AddCommand { get; set; }
		public ICommand Add2Command { get; set; }

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

		private int _newMemberId;
		public int NewMemberId
		{
			get
			{
				return _newMemberId;
			}
			set
			{
				_newMemberId = value;
				RaisePropertyChanged("NewMemberId");
			}
		}

		private string _newMemberName;
		public string NewMemberName
		{
			get
			{
				return _newMemberName;
			}
			set
			{
				_newMemberName = value;
				RaisePropertyChanged("NewMemberName");
			}
		}

		private string _newDescription;
		public string NewDescription
		{
			get
			{
				return _newDescription;
			}
			set
			{
				_newDescription = value;
				RaisePropertyChanged("NewDescription");
			}
		}

		private string _newPosition;
		public string NewPosition
		{
			get
			{
				return _newPosition;
			}
			set
			{
				_newPosition = value;
				RaisePropertyChanged("NewPosition");
			}
		}

		private string _newExtraSkills;
		public string NewExtraSkills
		{
			get
			{
				return _newExtraSkills;
			}
			set
			{
				_newExtraSkills = value;
				RaisePropertyChanged("NewExtraSkills");
			}
		}
		
		private string _newLabel;
		public string NewLabel
		{
			get
			{
				return _newLabel;
			}
			set
			{
				_newLabel = value;
				RaisePropertyChanged("NewLabel");
			}
		}

		public AddWindowViewModel()
		{
			Messenger.Default.Register<Member>(this, OnMemberReceived);

			//SaveCommand = new CustomCommand(SaveMember, CanSaveMember);
			DeleteCommand = new CustomCommand(DeleteMember, CanDeleteMember);
			AddCommand = new CustomCommand(AddMember, CanSaveMember);
			//new DelegateCommand(() => AddMemberToStackPanel(MemberName));
			Add2Command = new CustomCommand(Add2Member, CanSaveMember);

			memberDataService = new MemberDataService();
		}

		private void Add2Member(object obj)
		{
			NewMemberId += 1;

			NewLabel=NewMemberId.ToString();
		}

		public void OnMemberReceived(Member member)
		{
			SelectedMember = member;
		}

		private bool CanDeleteMember(object obj)
		{
			return true;
		}

		private void DeleteMember(object memberId)
		{
			memberDataService.DeleteMember(selectedMember.MemberId);

			Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
		}

		private bool CanSaveMember(object obj)
		{
			return true;
		}

		//private void SaveMember(object member)
		//{
		//	memberDataService.UpdateMember(selectedMember);
		//	Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
		//}

		private void AddMember(object obj)
		{
			memberDataService.AddMember(NewMemberId, NewMemberName, NewDescription,NewPosition,NewExtraSkills);
			//memberDataService.AddMember(NewMemberId);

			Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
		}
	}
}
