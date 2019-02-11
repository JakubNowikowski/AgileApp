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
using System.Collections.Generic;

namespace AgileApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DialogService dialogService = new DialogService();

        private ObservableCollection<Member> members;
        private Member selectedMember;
        private ObservableCollection<Member> productOwnerMembers;
        private Member selectedProductOwner;

        #region Properties
        public ObservableCollection<Member> Members
        {
            get => members;
            set { members = value; RaisePropertyChanged("Members"); }
        }

        public Member SelectedMember
        {
            get => selectedMember;
            set { selectedMember = value; RaisePropertyChanged("SelectedMember"); }
        }

        public ObservableCollection<Member> ProductOwnerMembers
        {
            get => productOwnerMembers;
            set { productOwnerMembers = value; RaisePropertyChanged("ProductOwnerMembers"); }
        }

        public Member SelectedProductOwner
        {
            get => selectedProductOwner;
            set { selectedProductOwner = value; RaisePropertyChanged("SelectedProductOwner"); }
        }

        private string _newDescription;
        public string NewDescription
        {
            get => _newDescription;
            set { _newDescription = value; RaisePropertyChanged("NewDescription"); }
        }

        private List<string> _position;
        public List<string> Positions
        {
            get => new List<string>()
            {
            "None",
            "Product owner",
            "Project manager",
            "Scrum master",
            "Architect",
            "Dev team"
            };
            set => _position = value;
        }

        private string _newPosition = "None";
        public string NewPosition
        {
            get => _newPosition;
            set { _newPosition = value; RaisePropertyChanged("NewPosition"); }
        }

        private string _newExtraSkills;
        public string NewExtraSkills
        {
            get => _newExtraSkills;
            set { _newExtraSkills = value; RaisePropertyChanged("NewExtraSkills"); }
        }

        private string _labelsVisibility;
        public string LabelsVisibility
        {
            get => _labelsVisibility;
            set { _labelsVisibility = value; RaisePropertyChanged("LabelsVisibility"); }
        }

        private string _listViewVisibility;
        public string ListViewVisibility
        {
            get => _listViewVisibility;
            set { _listViewVisibility = value; RaisePropertyChanged("ListViewVisibility"); }
        }

        private string _textBoxesVisibility;
        public string TextBoxesVisibility
        {
            get => _textBoxesVisibility;
            set { _textBoxesVisibility = value; RaisePropertyChanged("TextBoxesVisibility"); }
        }
        #endregion

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

        private void ChangePositionToNone(object member)
        {
            memberDataService.UpdateMember(selectedProductOwner, NewDescription, "None", NewExtraSkills);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private MemberDataService memberDataService;

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand OpenAddWindowCommand { get; set; }
        public ICommand ClearProductOwner { get; set; }

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

            TextBoxesVisibility = "Hidden";
            LabelsVisibility = "Visible";
            ListViewVisibility = "True";

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditMember, CanEditMember);
            DeleteCommand = new CustomCommand(DeleteMember, CanDeleteMember);
            SaveCommand = new CustomCommand(SaveMember, CanDeleteMember);
            ClearProductOwner = new CustomCommand(ChangePositionToNone, CanDeleteMember);
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

        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
        }

        private void SaveMember(object member)
        {
            memberDataService.UpdateMember(selectedMember, NewDescription, NewPosition, NewExtraSkills);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());

            TextBoxesVisibility = "Hidden";
            LabelsVisibility = "Visible";
            ListViewVisibility = "True";
        }

        private void EditMember(object obj)
        {
            NewDescription = selectedMember.Description;
            NewPosition = selectedMember.Position;
            NewExtraSkills = selectedMember.ExtraSkills;

            LabelsVisibility = "Hidden";
            TextBoxesVisibility = "Visible";
            ListViewVisibility = "False";
        }

        private bool CanEditMember(object obj)
        {
            return SelectedMember != null ? true : false;
        }

        private void LoadData()
        {
            ProductOwnerMembers = memberDataService.GetMembersByPosition("Product owner").ToObservableCollection();
            Members = memberDataService.GetAllMembers().ToObservableCollection();
        }
    }
}
