using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.ViewModel
{
    public class EntryViewModel : ViewModelBase
    {
        private string _activity;

        public string Activity
        {
            get { return _activity; }
            set
            {
                _activity = value;
                RaisePropertyChanged("Activity");
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


        public EntryViewModel()
        {

        }
    }
}
