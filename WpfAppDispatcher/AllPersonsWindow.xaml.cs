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
    /// Interaction logic for AllPersonsWindow.xaml
    /// </summary>
    public partial class AllPersonsWindow : Window
    {
        List<Client> clients;
        int i = 0;
        public AllPersonsWindow()
        {
            InitializeComponent();
            clients = MainWindow.dispatcher.AllClients().ToList();
            if(clients.Count == 0)
            {
                MessageBox.Show("Empty list of clients");
                this.Close();
            }
            else
            {
                Show();
            }
        }

        void Show()
        {
            FirstName.Text = clients[i].FirstName;
            SecondName.Text = clients[i].SecondName;
            Email.Text = clients[i].Email;
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (i + 1 < clients.Count)
                i++;
            Show();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (i - 1 >= 0)
                i--;
            Show();
        }

        private void ShowOrders_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AllOrdersWindow window = new AllOrdersWindow(clients[i].Id, false);
                window.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FN_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
