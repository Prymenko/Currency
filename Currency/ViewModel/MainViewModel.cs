using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Currency.ViewModel
{
    public class Org
    {
        public string Name { get; set; }
        public List<Currency> curr { get; set; } = new List<Currency>();

        public override string ToString()
        {
            return Name;
        }
    }

    public class Currency
    {
        public string Name { get; set; }
        public double buy { get; set; }
        public double sell { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }


    public class MainViewModel : INotifyPropertyChanged
    {
        public Org Selected { get; set; } = new Org();

        Currency c1 = new Currency
        {
            Name = "USD",
            buy = 26.6,
            sell = 12.5
        };

        Currency c2 = new Currency
        {
            Name = "RUB",
            buy = 90.6,
            sell = 16.1
        };

        Currency c3 = new Currency
        {
            Name = "POL",
            buy = 21.1,
            sell = 53.3
        };

        public List<Org> og { get; set; } = new List<Org>();

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
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
