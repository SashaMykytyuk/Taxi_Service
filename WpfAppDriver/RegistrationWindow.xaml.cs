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
        bool FNChange, SNChange, PSWChange, EMAILChange;
        public List<Car> AllCars = new List<Car>();
        public RegistrationWindow()
        {
            InitializeComponent();
            foreach(var elem in MainWindow.driver.AllCars())
            {
                AllCars.Add(elem);
                Cars.Items.Add(elem.ClassOfCar + "\t" + elem.Marka);
            }
            Button button = new Button();
            button.Content = "List not contain my car";
            button.Click += Button_Click;
            Cars.Items.Add(button);
            Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WriteEmailWindow window = new WriteEmailWindow("List not contain my car"," Hello. I can't find my car in list.\n Marka: \n Class of car: \n Volume: \n Year: \n Hope, you help me");
            window.ShowDialog();
        }

        void Show()
        {
            Email.Text = MainWindow.driver.AboutDriver().Email;
            FirstName.Text = MainWindow.driver.AboutDriver().FirstName;
            SecondName.Text = MainWindow.driver.AboutDriver().SecondName;
            Password.Password = MainWindow.driver.AboutDriver().Password;

            Cars.SelectedItem = MainWindow.driver.AboutDriver().Car.ClassOfCar.ToString() + "\t" + MainWindow.driver.AboutDriver().Car.Marka;
            EMAILChange = false;
            FNChange = false;
            SNChange = false;
            PSWChange = false;
        }

        private void SN_Change(object sender, TextChangedEventArgs e)
        {
            SNChange = true;
        }

        private void FN_Change(object sender, TextChangedEventArgs e)
        {
            FNChange = true;
        }

        private void Email_Change(object sender, TextChangedEventArgs e)
        {
            EMAILChange = true;
        }

        private void PSW_Change(object sender, RoutedEventArgs e)
        {
            PSWChange = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (PSWChange == true || EMAILChange == true || FNChange == true || SNChange == true)
            {
               if( MessageBox.Show("Are you realle want to save personal changes?", "Save changes?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string res = "";
                    if (EMAILChange == true)
                        res += MainWindow.driver.ChangeInfo(Changes.Email, Email.Text);
                    if (PSWChange == true)
                        res += MainWindow.driver.ChangeInfo(Changes.Password, Password.Password);
                    if (FNChange == true)
                        res += MainWindow.driver.ChangeInfo(Changes.FirstName, FirstName.Text);
                    if (SNChange == true)
                        res += MainWindow.driver.ChangeInfo(Changes.SecondName, SecondName.Text);
                    if (res == "")
                        MessageBox.Show("All changes are save");
                    else MessageBox.Show(res);
                    Show();
                }
            }
            else this.Close();
        }

        private void SaveCar_Click(object sender, RoutedEventArgs e)
        {
            if (Cars.SelectedItem.ToString() == MainWindow.driver.AboutDriver().Car.ClassOfCar.ToString() + "\t" + MainWindow.driver.AboutDriver().Car.Marka)
                this.Close();
            else
            {
                if (MessageBox.Show("Are you really want to save changes car?", "Save changes?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string str = MainWindow.driver.ChangeCar(AllCars[Cars.SelectedIndex].Id);
                    if (str == "")
                        Show();
                    else MessageBox.Show(str);
                }
                else this.Close();
         
            }
        }

        private void Cars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClassOfCar.Text = AllCars[Cars.SelectedIndex].ClassOfCar.ToString();
            Volume.Text = AllCars[Cars.SelectedIndex].Volume.ToString();
            Age.Text = AllCars[Cars.SelectedIndex].Age.ToString();
            Marka.Text = AllCars[Cars.SelectedIndex].Marka;
        }
    }
}
