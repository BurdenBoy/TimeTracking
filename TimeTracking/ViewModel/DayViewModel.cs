using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TimeTracking.Controls;

namespace TimeTracking.ViewModel
{
    public class DayViewModel : ViewModelBase
    {
        private DateTime _time;

        public DateTime Time
        {
            get { return _time; }
            set
            {
                _time = value;
                RaisePropertyChanged("Time");
            }
        }

        private string _date;

        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                RaisePropertyChanged("Date");
            }
        }

        private ObservableCollection<EntryViewModel> _entries;

        public ObservableCollection<EntryViewModel> Entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                RaisePropertyChanged("Entries");
            }
        }

        public DayViewModel(DateTime time)
        {
            _time = time;
            Date = _time.ToString("dd-MM-yyyy");

            MessengerInstance.Register<string>(this, ProcessMessage);
            Entries = DataBaseConnector.GetTimeEntriesFromDate(Time);
        }

        public ICommand AddEntryPressed { get { return new RelayCommand(AddEntry); } }

        private void AddEntry()
        {
            var addEntryWindow = new AddEntryDialog();
            var addEntryWindowVM = new AddEntryDialogViewModel(Time);
            addEntryWindow.DataContext = addEntryWindowVM;
            addEntryWindow.ShowDialog();
        }

        private void ProcessMessage(string message)
        {
            if(message=="Update")
            {
                Entries = DataBaseConnector.GetTimeEntriesFromDate(Time);
            }
        }

    }
}
