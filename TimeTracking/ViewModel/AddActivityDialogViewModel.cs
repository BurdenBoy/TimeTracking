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
    public class AddActivityDialogViewModel: ViewModelBase
    {

        private ObservableCollection<string> _allCategories;

        public ObservableCollection<string> AllCategories
        {
            get { return _allCategories; }
            set
            {
                _allCategories = value;
                RaisePropertyChanged("AllCategories");
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
        
        public AddActivityDialogViewModel()
        {
            AllCategories = DataBaseConnector.GetAllCategories();
            MessengerInstance.Register<string>(this, ProcessMessage);
        }

        public ICommand OkClicked { get { return new RelayCommand<Window>(Ok); } }

        private void Ok(Window window)
        {
            DataBaseConnector.AddActivity(SelectedValue, Name, MessengerInstance);
            window.Close();
        }

        public ICommand CancelClicked { get { return new RelayCommand<Window>(Cancel); } }

        private void Cancel(Window window)
        {
            window.Close();
        }

        public ICommand AddCategoryClicked { get { return new RelayCommand<Window>(AddCategory); } }

        private void AddCategory(Window window)
        {
            
        }

        private void ProcessMessage(string message)
        {
            if (message == "Update")
            {
                AllCategories = DataBaseConnector.GetAllCategories();
            }
        }
    }
}
