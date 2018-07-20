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

namespace TimeTracking.ViewModel
{
    public class AddCategoryDialogViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public AddCategoryDialogViewModel()
        {

        }

        public ICommand OkClicked { get { return new RelayCommand<Window>(Ok); } }

        private void Ok(Window window)
        {
            DataBaseConnector.AddCategory(Name, MessengerInstance);
            window.Close();
        }

        public ICommand CancelClicked { get { return new RelayCommand<Window>(Cancel); } }

        private void Cancel(Window window)
        {
            window.Close();
        }
    }
}
