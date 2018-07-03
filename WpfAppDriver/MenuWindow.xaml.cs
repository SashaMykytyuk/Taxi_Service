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

namespace WpfAppDriver
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
            RegistrationWindow window = new RegistrationWindow();
            window.ShowDialog();
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Report is send");
        }

        private void AllOrders(object sender, RoutedEventArgs e)
        {
            AllOrdersWindow window = new AllOrdersWindow();
            window.ShowDialog();
        }

        private void WriteEmail_Click(object sender, RoutedEventArgs e)
        {
            WriteEmailWindow window = new WriteEmailWindow();
            window.ShowDialog();
        }

        private void CreateCar_Click(object sender, RoutedEventArgs e)
        {
            CreateCarWindow window = new CreateCarWindow();
            window.ShowDialog();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
