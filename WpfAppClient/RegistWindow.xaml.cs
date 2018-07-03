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
    /// Interaction logic for RegistWindow.xaml
    /// </summary>
    public partial class RegistWindow : Window
    {
        bool r;
        public RegistWindow(bool registr)
        {
            InitializeComponent();
            r = registr;
            if(r==false)
            {
                // do something
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(r==false)
            {
                MessageBox.Show("Are you really want to save changes?", "Save changes?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                //
            }
            else
            {
                //
            }
            this.Close();
        }
    }
}
