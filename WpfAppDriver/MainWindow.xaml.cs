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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppDriver.ServiceReference;
namespace WpfAppDriver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ServiceDriverClient driver;
        public MainWindow()
        {
            InitializeComponent();
            driver = new ServiceDriverClient();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string str = driver.Authorization(Email.Text, Password.Password);
            if(str == "")
            {
                MenuWindow window = new MenuWindow();
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show(str);
            }
            Email.Text = "";
            Password.Password = "";
        }
    }
}
