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
using WpfAppDriver.ServiceReference;
namespace WpfAppDriver
{
    /// <summary>
    /// Interaction logic for AllOrdersWindow.xaml
    /// </summary>
    public partial class AllOrdersWindow : Window
    {
        List<Order> orders;
        int i = 0;
        public AllOrdersWindow()
        {
            try
            {
                InitializeComponent();
                orders = MainWindow.driver.AllOrders().ToList();
                if(orders.Count == 0)
                {
                    MessageBox.Show("Empty list");
                }
                else
                Title = (i>0?i+1:i) + " from " + orders.Count;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Show()
        {
            Comment.Text = orders[i].Comment;
            Price.Text = orders[i].Money.ToString();
            KM.Text = orders[i].KM.ToString();
        }
        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (i - 1 >= 0)
                i--;
            Show();
            Title = (i > 0 ? i + 1 : i) + " from " + orders.Count;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if(i<orders.Count)
                i++;
            Show();
            Title = (i > 0 ? i + 1 : i) + " from " + orders.Count;
        }
    }
}
