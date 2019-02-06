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
            get => members;
            set { members = value; RaisePropertyChanged("Members"); }
        }

        private Member selectedMember;

        public Member SelectedMember
        {
            get => selectedMember;
            set { selectedMember = value; RaisePropertyChanged("SelectedMember"); }
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

        private string _labelsVisibility2;
        public string LabelsVisibility2
        {
            get => _labelsVisibility2;
            set { _labelsVisibility2 = value; RaisePropertyChanged("LabelsVisibility2"); }
        }

        private string _textBoxesVisibility;
        public string TextBoxesVisibility
        {
            get => _textBoxesVisibility;
            set { _textBoxesVisibility = value; RaisePropertyChanged("TextBoxesVisibility"); }
        }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SaveCommand { get; set; }
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

            //NewDescription = selectedMember.Description;
            //NewPosition = selectedMember.Position;
            //NewExtraSkills = selectedMember.ExtraSkills;

            LoadCommands();

            TextBoxesVisibility = "Hidden";
            LabelsVisibility = "Visible";
            LabelsVisibility2 = "True";
            //selectedMember.MemberId = 1;

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditMember, CanEditMember);
            DeleteCommand = new CustomCommand(DeleteMember, CanDeleteMember);
            SaveCommand = new CustomCommand(SaveMember, CanDeleteMember);
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
            LabelsVisibility2 = "True";
            //Messenger.Default.Send<Member>(selectedMember);
        }

        private void EditMember(object obj)
        {
            NewDescription = selectedMember.Description;
            NewPosition = selectedMember.Position;
            NewExtraSkills = selectedMember.ExtraSkills;

            LabelsVisibility = "Hidden";
            TextBoxesVisibility = "Visible";
            LabelsVisibility2 = "False";
            //Messenger.Default.Send<Member>(selectedMember);
        }

        private bool CanEditMember(object obj)
        {
            return SelectedMember != null ? true : false;
        }

        private void LoadData()
        {
            Members = memberDataService.GetAllMembers().ToObservableCollection();
        }
    }
}
