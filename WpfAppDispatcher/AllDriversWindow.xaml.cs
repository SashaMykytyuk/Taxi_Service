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
        List<Driver> drivers;
        int i;
        public AllDriversWindow()
        {
            InitializeComponent();
            try
            {
                drivers = MainWindow.dispatcher.AllDrivers().ToList();
                if (drivers.Count == 0)
                {
                    MessageBox.Show("Empty list or drivers");
                }
                else
                {
                    i = 0;
                    Show();

                }
            }
            catch(Exception  ex) { MessageBox.Show(ex.Message); }
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

        private void ShowOrders_Click(object sender, RoutedEventArgs e)
        {
            AllOrdersWindow window = new AllOrdersWindow(drivers[i].Id, true);
            window.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateCarWindow window = new CreateCarWindow(drivers[i].Car.Id);
            window.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AllReportsWindow window = new AllReportsWindow(drivers[i].Id);
            window.ShowDialog();
        }
    }
}
