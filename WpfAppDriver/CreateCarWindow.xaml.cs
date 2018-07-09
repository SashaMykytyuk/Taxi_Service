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
    /// Interaction logic for CreateCarWindow.xaml
    /// </summary>
    public partial class CreateCarWindow : Window
    {
        public CreateCarWindow()
        {
            InitializeComponent();
            ClassOfCar.Items.Add(ClassesOfCar.For4Person.ToString());
            ClassOfCar.Items.Add(ClassesOfCar.For8Person.ToString());
            ClassOfCar.Items.Add(ClassesOfCar.ForVantazh.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            car.Age = Int32.Parse(Age.Text);
            car.ClassOfCar = ClassOfCar.SelectedItem.ToString() == "For4Person" ? ClassesOfCar.For4Person : ClassOfCar.SelectedItem.ToString() == "For8Person" ? ClassesOfCar.For8Person : ClassesOfCar.ForVantazh;
            car.Marka = Marka.Text;
            car.Volume = Int32.Parse(Volume.Text);

            string str = MainWindow.driver.CreateCar(car);
            if (str == "")
                this.Close();
            else MessageBox.Show(str);
        }
    }
}
