using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Currency.ViewModel
{
    public class Org : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Currency> curr { get; set; } = new ObservableCollection<Currency>();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Currency : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private double buy;
        public double Buy
        {
            get { return buy; }
            set
            {
                buy = value;
                OnPropertyChanged();
            }
        }
        private double sell;
        public double Sell
        {
            get { return sell; }
            set
            {
                sell = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return Name;
        }
    }


    public class MainViewModel : INotifyPropertyChanged
    {
        public string NN { get; set; } = "Strings";

        private Org selected;
        public Org Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }

        Currency c1 = new Currency
        {
            Name = "USD",
            Buy = 26.6,
            Sell = 12.5
        };

        Currency c2 = new Currency
        {
            Name = "RUB",
            Buy = 90.6,
            Sell = 16.1
        };

        Currency c3 = new Currency
        {
            Name = "POL",
            Buy = 21.1,
            Sell = 53.3
        };

        public ObservableCollection<Org> og { get; set; } = new ObservableCollection<Org>();

        public MainViewModel()
        {
            Org oo = new Org();
            oo.Name = "Privat";
            oo.curr.Add(c1);
            oo.curr.Add(c2);
            oo.curr.Add(c3);

            og.Add(oo);
            
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
