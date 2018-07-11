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

namespace WpfAppClient
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            RegistWindow window = new RegistWindow(false);
            window.ShowDialog();
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            CreateOrderWindow window = new CreateOrderWindow();
            window.ShowDialog();
        }

        private void AllOrders_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AllOrdersWindow window = new AllOrdersWindow();
                window.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WriteEmail_Click(object sender, RoutedEventArgs e)
        {
            WriteEmailWindow window = new WriteEmailWindow();
            window.ShowDialog();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
