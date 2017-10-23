using Currency.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Currency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
            IsVisibleChanged += new DependencyPropertyChangedEventHandler(MainWindow_IsVisibleChanged);
        }        

        void MainWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation()
            {
                From = (IsVisible) ? 0 : 3,
                To = (IsVisible) ? 3 : 0,
                Duration = TimeSpan.FromSeconds(3)
            };

            BeginAnimation(Window.OpacityProperty, da);
        }

        
    }
}
