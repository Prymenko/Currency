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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Currency.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Location CurrentLocation { get; set; } = new Location(50.44313043, 30.49511254);
        public double Zoom { get; set; } = 14;

        public string State
        {
            get
            {
                if (this.CollectCities == null && this.Sel_org == null)
                    return "Отсутствует подключение";

                return "Выберите банк";
            }
        }

        private bool isProgressVisible;
        public bool IsProgressVisible
        {
            get { return isProgressVisible; }
            set
            {
                isProgressVisible = value;
                OnPropertyChanged();
            }
        }

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

        private Organizations sel_org;
        public Organizations Sel_org
        {
            get { return sel_org; }
            set
            {
                sel_org = value;
                OnPropertyChanged("Sel_org");
                OnPropertyChanged("State");
            }
        }

        public MainViewModel()
        {
            try
            {
                //CollectCities = CurData.getCitiesCurrency();
                OnPropertyChanged("State");
                IsProgressVisible = true;
            }
            catch (Exception)
            { }
        }

        private RelayCommand refreshCommand;
        public RelayCommand RefreshCommand
        {
            get
            {
                return refreshCommand ??
            (refreshCommand = new RelayCommand(obj =>
            {
                IsProgressVisible = true;
                try
                {
                    this.Selected = null;
                    this.Sel_org = null;
                    this.CollectCities = CurData.getCitiesCurrency();
                }
                catch (Exception)
                {
                    this.CollectCities = null;
                }
                finally
                {
                    OnPropertyChanged("State");
                    OnPropertyChanged("CollectCities");
                }
                IsProgressVisible = false;

                
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
