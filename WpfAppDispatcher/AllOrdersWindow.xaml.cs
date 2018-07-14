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
    /// Логика взаимодействия для AllOrdersWindow.xaml
    /// </summary>
    public partial class AllOrdersWindow : Window
    {
        List<Order> orders;
        int i = 0;
        public AllOrdersWindow()
        {
            InitializeComponent();
            orders = MainWindow.dispatcher.AllOrders().ToList();
            foreach(var elem in MainWindow.dispatcher.AllDrivers())
            {
                Drivers.Items.Add(elem.FirstName + "  " + elem.SecondName);
            }

            Show();
        }
        public AllOrdersWindow(int idPerson, bool isDriver) : this() 
        {
            try
            {
                if(isDriver == true)
                    orders = MainWindow.dispatcher.AllOrders().Where(elem => elem.Client.Id == idPerson).ToList();
                else
                    orders = MainWindow.dispatcher.AllOrders().Where(elem => elem.Driver.Id == idPerson).ToList();
                Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (i + 1 < orders.Count)
                i++;
            Show();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (i - 1 >= 0)
                i--;
            Show();

        }
        void Show()
        {
            ClassOfCar.Text = orders[i].ClassOfCar.ToString();
            KM.Text = orders[i].KM.ToString();
            Price.Text = orders[i].Money.ToString();
            Comment.Text = orders[i].Comment;
            Done.IsChecked = orders[i].Done;
            //try
            //{
            //    Drivers.SelectedItem = (orders[i].Driver.FirstName + "  " + orders[i].Driver.SecondName);
            //}
            //catch { }
        }

        private void Drivers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MessageBox.Show("Are you really want to change driver?", "Change order?" , MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                string str = MainWindow.dispatcher.ChangeDriver(orders[i].Id, MainWindow.dispatcher.AllDrivers()[Drivers.SelectedIndex].Id);
                if (str == "")
                {
                    MessageBox.Show("Driver is change");
                }
                else MessageBox.Show(str);
            }
        }

        private void Done_Checked(object sender, RoutedEventArgs e)
        {
            if(Done.IsChecked == true)
            {
                if(MessageBox.Show("Is this order Done?", "Done", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
                {
                    string str = MainWindow.dispatcher.OrderDone(orders[i].Id);
                    if (str != "")
                        MessageBox.Show(str);
                }
            }
        }
    }
}
