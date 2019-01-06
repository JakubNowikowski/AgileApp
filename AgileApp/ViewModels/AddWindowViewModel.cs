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

		public AddWindowViewModel()
		{
			Messenger.Default.Register<Member>(this, OnMemberReceived);

			SaveCommand = new CustomCommand(SaveMember, CanSaveMember);
			DeleteCommand = new CustomCommand(DeleteMember, CanDeleteMember);

			memberDataService = new MemberDataService();
		}

		public void OnMemberReceived(Member member)
		{
			SelectedMember = member;
		}

		private bool CanDeleteMember(object obj)
		{
			return true;
		}

		private void DeleteMember(object member)
		{
			memberDataService.DeleteMember(selectedMember);

			Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
		}

		private bool CanSaveMember(object obj)
		{
			return true;
		}

		private void SaveMember(object member)
		{
			memberDataService.UpdateMember(selectedMember);
			Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
		}

	}
}
