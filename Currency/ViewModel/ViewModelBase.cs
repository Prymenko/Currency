using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.ViewModel
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Organization _selectedOrganization;
        public Organization SelectedOrganization
        {
            get { return _selectedOrganization; }
            set
            {
                if (_selectedOrganization == value)
                    return;
                _selectedOrganization = value;
                OnPropChanged("SelectedOrganization");
            }
        }
        ObservableCollection<Organization> _organization;
        public ObservableCollection<Organization> Organizations
        {
            get
            {
                if (_organization == null)
                    _organization = AutoSalon.GetCars();
                return _cars;
            }
            set
            {
                _cars = value;
                OnPropChanged("Cars");
            }
        }

    }
}
