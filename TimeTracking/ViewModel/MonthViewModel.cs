using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TimeTracking.Controls;

namespace TimeTracking.ViewModel
{
    public class MonthViewModel : ViewModelBase
    {

        private ObservableCollection<DayViewModel> _days;
        
        public ObservableCollection<DayViewModel> Days
        {
            get { return _days; }
            set
            {
                _days = value;
                RaisePropertyChanged("Days");
            }
        }

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
        
        public MonthViewModel(DateTime time)
        {
            _time = time;
            Update();
        }

        public ICommand SelectionChanged { get { return new RelayCommand<SelectionChangedEventArgs>(ZoomInOnSelection); } }

        private void ZoomInOnSelection(SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                MessengerInstance.Send(((DayViewModel)e.AddedItems[0]).Time, "DayView");
            }
        }
        
        private void Update()
        {
            _days = new ObservableCollection<DayViewModel>();
            int numberOfDays = DateTime.DaysInMonth(_time.Year, _time.Month);
            Days.Clear();
            for (int i = 1; i <= numberOfDays; i++)
            {
                Days.Add(new DayViewModel(new DateTime(_time.Year,_time.Month,i)));
            }
        }
    }
}
