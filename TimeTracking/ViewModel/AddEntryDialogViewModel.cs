using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TimeTracking.Controls;

namespace TimeTracking.ViewModel
{
    public class AddEntryDialogViewModel : ViewModelBase
    {
        private ObservableCollection<string> _allActivities;

        public ObservableCollection<string> AllActivities
        {
            get { return _allActivities; }
            set
            {
                _allActivities = value;
                RaisePropertyChanged("AllActivities");
            }
        }

        private string _selectedValue;

        public string SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                _selectedValue = value;
                RaisePropertyChanged("SelectedValue");
            }
        }

        private string _duration;

        public string Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                RaisePropertyChanged("Duration");
            }
        }

        private string _comment;

        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                RaisePropertyChanged("Comment");
            }
        }

        DateTime _selectedDayDate;
        public AddEntryDialogViewModel(DateTime selectedDayDate)
        {
            AllActivities = DataBaseConnector.GetAllActivities();
            _selectedDayDate = selectedDayDate;

            MessengerInstance.Register<string>(this, ProcessMessage);
        }

        public ICommand OkClicked { get { return new RelayCommand<Window>(Ok); } }

        private void Ok(Window window)
        {
            DataBaseConnector.AddEntry(SelectedValue, Comment, Duration, _selectedDayDate, MessengerInstance);
            window.Close();
        }

        public ICommand CancelClicked { get { return new RelayCommand<Window>(Cancel); } }

        private void Cancel(Window window)
        {
            window.Close();
        }

        public ICommand AddActivityClicked { get { return new RelayCommand<Window>(AddActivity); } }

        private void AddActivity(Window window)
        {
            var addActivityDialog = new AddActivityDialog();
            addActivityDialog.ShowDialog();
        }

        private void ProcessMessage(string message)
        {
            if (message == "Update")
            {
                AllActivities = DataBaseConnector.GetAllActivities();
            }
        }

    }
}
