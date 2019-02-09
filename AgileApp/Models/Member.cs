using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System;

namespace AgileApp.Models
{
    public class Member : BindableBase, INotifyPropertyChanged
    {
        private int memberId;
        private string memberName;
        private string extraSkills;

        public int MemberId
        {
            get => memberId;
            set { memberId = value; RaisePropertyChanged("MemberId"); }
        }

        public string MemberName
        {
            get => memberName;
            set { memberName = value; RaisePropertyChanged("MemberName"); }
        }

        public string Description { get; set; }

        public string Position { get; set; }

        public string ExtraSkills
        {
            get => extraSkills;
            set { extraSkills = value; RaisePropertyChanged("ExtraSkills"); }
        }

        public int ImageId { get; set; }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////
        /// </summary>
        private StackPanel _stkPanel;
        public StackPanel stkPanel
        {
            get => _stkPanel;
            set { SetProperty(ref _stkPanel, value); }
        }

        private string _message;


        public string Message
        {
            get => _message;
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

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void RaisePropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

    }
}
