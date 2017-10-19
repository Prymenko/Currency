using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Data
{
    
    public class Organizations : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        string name;
        public string Name {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        string region;
        public string Region {
            get
            {
                return region;
            }
            set
            {
                region = value;
                OnPropertyChanged();
            }
        }

        string city;
        public string City {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }

        string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }

        string adress;
        public string Adress {
            get
            {
                return adress;
            }
            set
            {
                adress = value;
                OnPropertyChanged();
            }
        }

        string link;
        public string Link {
            get
            {
                return link;
            }
            set
            {
                link = value;
                OnPropertyChanged();
            }
        }

        public List<Currencies> currencies { get; set; }

    }
}
