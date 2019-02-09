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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AgileApp.ViewModels
{
    public class AddWindowViewModel : INotifyPropertyChanged
    {
        #region Properties

        private Member selectedMember;
        public Member SelectedMember
        {
            get => selectedMember;
            set { selectedMember = value; RaisePropertyChanged("SelectedMember"); }
        }

        private int _newMemberId;
        public int NewMemberId
        {
            get => _newMemberId; set { _newMemberId = value; RaisePropertyChanged("NewMemberId"); }
        }

        private string _newMemberName;
        public string NewMemberName
        {
            get => _newMemberName; set { _newMemberName = value; RaisePropertyChanged("NewMemberName"); }
        }

        private string _newDescription;
        public string NewDescription
        {
            get => _newDescription;
            set { _newDescription = value; RaisePropertyChanged("NewDescription"); }
        }

        private string _newPosition;
        public string NewPosition
        {
            get => _newPosition;
            set { _newPosition = value; RaisePropertyChanged("NewPosition"); }
        }

        private List<string> _position;
        public List<string> Positions
        {
            get => new List<string>(){"Product owner",
            "Project manager",
            "Scrum master",
            "Architect",
            "Dev team" };
            set => _position = value;
        }

        private string _newExtraSkills;
        public string NewExtraSkills
        {
            get => _newExtraSkills; set { _newExtraSkills = value; RaisePropertyChanged("NewExtraSkills"); }
        }

        private string _newLabel;
        public string NewLabel
        {
            get => _newLabel; set { _newLabel = value; RaisePropertyChanged("NewLabel"); }
        }

        #endregion
        
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand Add2Command { get; set; }

        private MemberDataService memberDataService;
        public event PropertyChangedEventHandler PropertyChanged;

        public AddWindowViewModel()
        {
            Messenger.Default.Register<Member>(this, OnMemberReceived);

            DeleteCommand = new CustomCommand(DeleteMember, CanDeleteMember);
            AddCommand = new CustomCommand(AddMember, CanSaveMember);
            Add2Command = new CustomCommand(Add2Member, CanSaveMember);
            memberDataService = new MemberDataService();
        }

        private void Add2Member(object obj)
        {
            NewMemberId += 1;

            NewLabel = NewMemberId.ToString();
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

        private void AddMember(object obj)
        {
            memberDataService.AddMember(NewMemberId, NewMemberName, NewDescription, NewPosition, NewExtraSkills);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
