using Currency.Data;
using Currency.Infrastructure;
using MahApps.Metro.Controls;
using Microsoft.Maps.MapControl.WPF;
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
using System.Windows.Input;

namespace Currency.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Location CurrentLocation { get; set; } = new Location(50.44313043, 30.49511254);
        public double Zoom { get; set; } = 14;


        public ObservableCollection<Cities> CollectCities { get; set; }

        private Cities selected;
        public Cities Selected
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
                CollectCities = new ObservableCollection<Cities>(CurData.getCitiesCurrency());
            }
            catch (Exception)
            {
            }
        }

        private RelayCommand refreshCommand;
        public RelayCommand RefreshCommand
        {
            get
            {
                return refreshCommand ??
            (refreshCommand = new RelayCommand(obj =>
            {
                Thread.Sleep(5000);
                this.CollectCities = CurData.getCitiesCurrency();
            }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
