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
using WpfAppDispatcher.ServiceReference;
namespace WpfAppDispatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ServiceDispatcherClient dispatcher;
        public MainWindow()
        {
            dispatcher = new ServiceDispatcherClient();
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string str = dispatcher.Authorization(Email.Text, Password.Password);
            if (str == "")
            {
                MenuWindow window = new MenuWindow();
                window.ShowDialog();
                Email.Text = "";
                Password.Password = "";
            }
            else MessageBox.Show(str);
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration window = new Registration(true);
            window.ShowDialog();
        }
    }
}
