using Currency.Data;
using Currency.Infrastructure;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Currency.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Organizations> CollectOrganizations { get; set; }

        private Organizations selected;
        public Organizations Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }       

        public MainViewModel()
        {
            try
            {
                IsActive = true;
                Thread.Sleep(5000);
                IsActive = false;
                CollectOrganizations = new ObservableCollection<Organizations>(CurData.getDataCurrency());
            }
            catch (Exception)
            {
            }            
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
