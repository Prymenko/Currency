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
                From = (IsVisible) ? 0 : 2,
                To = (IsVisible) ? 2 : 0,
                Duration = TimeSpan.FromSeconds(2)
            };

            BeginAnimation(Window.OpacityProperty, da);
        }

        //public void FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var flipview = ((FlipView)sender);
        //    switch (flipview.SelectedIndex)
        //    {
        //        case 0:
        //            break;
        //        case 1:
        //            break;
        //        case 2:
        //            break;
        //    }
        //}
    }
}
