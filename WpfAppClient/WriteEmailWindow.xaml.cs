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
    /// Interaction logic for WriteEmailWindow.xaml
    /// </summary>
    public partial class WriteEmailWindow : Window
    {
        public WriteEmailWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(MainWindow.client.SendMessageToDispatcher(Theme.Text, Message.Text));
            this.Close();
        }
    }
}
