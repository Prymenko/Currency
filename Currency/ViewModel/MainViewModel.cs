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

        //Currency c1 = new Currency
        //{
        //    Name = "USD",
        //    Buy = 26.6,
        //    Sell = 12.5
        //};

        //Currency c2 = new Currency
        //{
        //    Name = "RUB",
        //    Buy = 90.6,
        //    Sell = 16.1
        //};

        //Currency c3 = new Currency
        //{
        //    Name = "POL",
        //    Buy = 21.1,
        //    Sell = 53.3
        //};

        //Currency c4 = new Currency
        //{
        //    Name = "ZAY",
        //    Buy = 10.6,
        //    Sell = 0.109
        //};
        

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
