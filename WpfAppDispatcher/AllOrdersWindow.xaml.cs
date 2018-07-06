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
            Show();
        }
        public AllOrdersWindow(int idClient) : this()
        {
            orders = MainWindow.dispatcher.AllOrders().Where(elem => elem.Client.Id == idClient).ToList();
            Show();
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
        }
    }
}
