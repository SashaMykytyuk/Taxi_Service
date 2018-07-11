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
using WpfAppDriver.ServiceReference;
namespace WpfAppDriver
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            foreach(var elem in MainWindow.driver.AllCars())
            {
                Cars.Items.Add(elem.ClassOfCar + "\t" + elem.Marka);
            }
            Show();
        }
        void Show()
        {
            Email.Text = MainWindow.driver.AboutDriver().Email;
            FirstName.Text = MainWindow.driver.AboutDriver().FirstName;
            SecondName.Text = MainWindow.driver.AboutDriver().SecondName;
            Password.Password = MainWindow.driver.AboutDriver().Password;

            ClassOfCar.Text = MainWindow.driver.AboutDriver().Car.ClassOfCar.ToString();
            Volume.Text = MainWindow.driver.AboutDriver().Car.Volume.ToString();
            Age.Text = MainWindow.driver.AboutDriver().Car.Age.ToString();
            Marka.Text = MainWindow.driver.AboutDriver().Car.Marka;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveCar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
