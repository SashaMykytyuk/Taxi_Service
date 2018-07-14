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
using DAL;

namespace WpfAppClient
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private SearchByPoint searchByPoint;
        private SearchByAdress searchByAdress;
        private string providerKey;
        
        public MenuWindow()
        {
            InitializeComponent();
            providerKey = "Asf63QojxGRORzyVIbsUtSn6DxVR42K_FbNb-Gbsjtc34OWQBx9byU3WkCXtgqsC";
            searchByAdress = new SearchByAdress(providerKey);
            searchByPoint = new SearchByPoint(providerKey);

            ClassOfCarAdress.Items.Add("For4Person");
            ClassOfCarAdress.Items.Add("For8Person");
            ClassOfCarAdress.Items.Add("ForVantazh");

            ClassOfCarPoint.Items.Add("For4Person");
            ClassOfCarPoint.Items.Add("For8Person");
            ClassOfCarPoint.Items.Add("ForVantazh");
        }

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            RegistWindow window = new RegistWindow(false);
            window.ShowDialog();
        }

        //private void CreateOrder_Click(object sender, RoutedEventArgs e)
        //{
        //    CreateOrderWindow window = new CreateOrderWindow();
        //    window.ShowDialog();
        //}

        private void AllOrders_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AllOrdersWindow window = new AllOrdersWindow();
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WriteEmail_Click(object sender, RoutedEventArgs e)
        {
            WriteEmailWindow window = new WriteEmailWindow();
            window.ShowDialog();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        ///////////////////////////   Left menu //////////////////////////



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.ClassOfCar = (sender as ComboBox).SelectedItem.ToString() == "For4Person" ? ClassesOfCar.For4Person :
                (sender as ComboBox).SelectedItem.ToString() == "For8Person" ? ClassesOfCar.For8Person : ClassesOfCar.ForVantazh;
            order.KM = Double.Parse(KM.Text);
            order.Money = Double.Parse(Price.Text);
            order.LocationFrom = new Location() {Place = From.Text};
            order.LocationTo = new Location() {Place = To.Text};

            string str = MainWindow.client.CreateOrder(order);
            if (str == "")
            {
                MessageBox.Show("Order is create");
                this.Close();
            }
            else MessageBox.Show(str);

            this.Close();
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && From.Text != "" && To.Text != "" && (sender as ComboBox).SelectedIndex != -1)
            {
                ClassesOfCar classesOfCar = (sender as ComboBox).SelectedItem.ToString() == "For4Person"
                    ? ClassesOfCar.For4Person
                    : (sender as ComboBox).SelectedItem.ToString() == "ForPerson"
                        ? ClassesOfCar.For8Person
                        : ClassesOfCar.ForVantazh;
                Random r = new Random();
                KM.Text = r.Next(1, 100).ToString();
                Price.Text = MainWindow.client.GetPrice(Double.Parse(KM.Text), classesOfCar).ToString();
            }
        }

        private void MenuPointOrAdress(object sender, RoutedEventArgs e)
        {
            if (RadioButtonPoint.IsChecked == true)
            {
                GroupBoxByPoints.Visibility = Visibility.Visible;
                GroupBoxByAdress.Visibility = Visibility.Collapsed;
            }
            else
            {
                GroupBoxByPoints.Visibility = Visibility.Collapsed;
                searchByPoint.ClearMap(MyMap);
                GroupBoxByAdress.Visibility = Visibility.Visible;
            }
        }

        private void MyMap_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(RadioButtonPoint.IsChecked == false)
                return;
            searchByPoint.OnMouseDoubleClick(MyMap,sender,e);
        }

        private void ShowRouteByPoint(object sender, RoutedEventArgs e)
        {
            searchByPoint.MapGetRoud(MyMap);
        }

        private void ClearAllOnMap(object sender, RoutedEventArgs e)
        {
            if(RadioButtonPoint.IsChecked == true)
                searchByPoint.ClearMap(MyMap);
        }

        private void SelectCar(object sender, RoutedEventArgs e)
        {
        //    (sender as ComboBox).SelectedItem.ToString() == "For4Person" ? ClassesOfCar.For4Person : ClassOfCar.SelectedItem.ToString() == "For8Person" ? ClassesOfCar.For8Person : ClassesOfCar.ForVantazh;
        //    LabelMoney.Content = MainWindow.client.GetPrice(searchByPoint.Distance,(sender as ComboBox).SelectedItem)
        }
    }
}

