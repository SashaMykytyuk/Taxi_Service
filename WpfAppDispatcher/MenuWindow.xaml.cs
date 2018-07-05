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
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void CreateDriver_Click(object sender, RoutedEventArgs e)
        {
            RegistrDriver window = new RegistrDriver();
            window.ShowDialog();
        }

        private void CreateCar_Click(object sender, RoutedEventArgs e)
        {
            CreateCarWindow window = new CreateCarWindow();
            window.ShowDialog();
        }

        private void AllDrivers_Click(object sender, RoutedEventArgs e)
        {
            AllDriversWindow window = new AllDriversWindow();
            window.ShowDialog();
        }
    }
}
