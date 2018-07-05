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
    /// Interaction logic for RegistrDriver.xaml
    /// </summary>
    public partial class RegistrDriver : Window
    {
        List<Car> ListCars;
        public RegistrDriver()
        {
            InitializeComponent();
            ListCars = MainWindow.dispatcher.AllCars().ToList();
            foreach(var elem in ListCars)
            {
                Cars.Items.Add(elem.Marka + "\t" + elem.ClassOfCar.ToString());
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string str = MainWindow.dispatcher.CreateDriver(new ServiceReference.Driver()
            {
                Email = Email.Text,
                FirstName = FirstName.Text,
                Password = Password.Password,
                SecondName = SecondName.Text,
            }, ListCars[Cars.SelectedIndex].Id+1);
            if (str == "")
                this.Close();
            else MessageBox.Show(str);
        }

        private void ChooseCar_Changed(object sender, SelectionChangedEventArgs e)
        {
            Age.Text = ListCars[Cars.SelectedIndex].Age.ToString();
            Marka.Text = ListCars[Cars.SelectedIndex].Marka;
            ClassOfCar.Text = ListCars[Cars.SelectedIndex].ClassOfCar.ToString();
            Volume.Text = ListCars[Cars.SelectedIndex].Volume.ToString();
        }
    }
}
