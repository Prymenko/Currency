using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Data
{
    public class Currencies : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private string id;
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private double br;
        public double BR
        {
            get
            {
                return br;
            }
            set
            {
                br = value;
                OnPropertyChanged();
            }
        }

        private double ar;
        public double AR{
            get
            {
                return ar;
            }
            set
            {
                ar = value;
                OnPropertyChanged();
            }
        }

    }
}
