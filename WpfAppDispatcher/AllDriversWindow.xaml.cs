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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppDispatcher.ServiceReference;

namespace WpfAppDispatcher
{
    /// <summary>
    /// Interaction logic for AllDriversWindow.xaml
    /// </summary>
    public partial class AllDriversWindow : Window
    {
        public List<Driver> drivers;
        int i;
        public AllDriversWindow()
        {
            InitializeComponent();
            drivers = MainWindow.dispatcher.AllDrivers().ToList();
            i = 0;
        }

        void Show()
        {
            FirstName.Text = drivers[i].FirstName;
            SecondName.Text = drivers[i].SecondName;
            Email.Text = drivers[i].Email;
        }


        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (i - 1 >= 0)
                i--;
            Show();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (i + 1 < drivers.Count)
                i++;
            Show();
        }
    }
}
