using DAL;
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
using WpfAppClient.ServiceReference;
namespace WpfAppClient
{
    /// <summary>
    /// Interaction logic for AllOrdersWindow.xaml
    /// </summary>
    public partial class AllOrdersWindow : Window
    {
        int i;
        List<Order> ListOfOrders;

        public AllOrdersWindow()
        {
            InitializeComponent();
            i = 0;
            ListOfOrders = MainWindow.client.AllOrders().ToList();
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
            try
            {
                ClassOfCar.Text = ListOfOrders[i].ClassOfCar.ToString();
                Comment.Text = ListOfOrders[i].Comment;
                Price.Text = ListOfOrders[i].Money.ToString();
                KM.Text = ListOfOrders[i].KM.ToString();
                Title = (i+1) + " from " + ListOfOrders.Count;
                Done.IsChecked = ListOfOrders[i].Done;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if(i+1<ListOfOrders.Count)
            i++;
            Show();
        }
    }
}
