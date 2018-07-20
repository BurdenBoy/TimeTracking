using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Linq;

namespace TimeTracking.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private Visibility _dayViewOpen;
        public Visibility DayViewOpen
        {
            get { return _dayViewOpen; }
            set
            {
                _dayViewOpen = value;
                RaisePropertyChanged("DayViewOpen");
            }
        }

        private Visibility _monthViewOpen;

        public Visibility MonthViewOpen
        {
            get { return _monthViewOpen; }
            set
            {
                _monthViewOpen = value;
                RaisePropertyChanged("MonthViewOpen");
            }
        }

        private DayViewModel _day;

        public DayViewModel Day
        {
            get { return _day; }
            set
            {
                _day = value;
                RaisePropertyChanged("Day");
            }
        }

        private MonthViewModel _month;

        public MonthViewModel Month
        {
            get { return _month; }
            set
            {
                _month = value;
                RaisePropertyChanged("Month");
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ChangeToMonth(DateTime.Now);

            MessengerInstance.Register<DateTime>(this, "DayView", ChangeToDay);
            MessengerInstance.Register<DateTime>(this, "MonthView", ChangeToMonth);

            using (TimeTrackingDBEntities context = new TimeTrackingDBEntities())
            {
                //Category category = new Category { Name = "Gaming" };
                //context.Categories.Add(category);

                //Activity activity = new Activity { Name = "Playing League", Category = category };
                //context.Activities.Add(activity);

                //TimeEntry timeEntry = new TimeEntry { Activity = activity, Comment = "Lost every fucking game", Date = DateTime.Now, CreationDate = DateTime.Now, Duration = 2.25 };
                //context.TimeEntries.Add(timeEntry);
                //context.SaveChanges();
            }

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private void ChangeToDay(DateTime time)
        {
            DayViewOpen = Visibility.Visible;
            MonthViewOpen = Visibility.Collapsed;
            Day = new DayViewModel(time);
        }

        private void ChangeToMonth(DateTime time)
        {
            DayViewOpen = Visibility.Collapsed;
            MonthViewOpen = Visibility.Visible;
            Month = new MonthViewModel(time);
        }


        public ICommand KeyPressed { get { return new RelayCommand<KeyEventArgs>(KeyPressedExecute); } }

        private void KeyPressedExecute(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (DayViewOpen == Visibility.Visible)
                {
                    ChangeToMonth(Day.Time);
                }
            }
        }
    }
}