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

namespace WpfAppDispatcher
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string str = MainWindow.dispatcher.Registration(new ServiceReference.Dispatcher()
            {
                Email = Email.Text,
                FirstName = FirstName.Text,
                SecondName = SecondName.Text,
                Password = Password.Password
            });
            if (str == "")
                this.Close();
            else MessageBox.Show(str);
        }
    }
}
