﻿using DAL;
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
    /// Interaction logic for CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {
        public CreateOrderWindow()
        {
            InitializeComponent();
            ClassOfCar.Items.Add("For4Person");
            ClassOfCar.Items.Add("For8Person");
            ClassOfCar.Items.Add("ForVantazh");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.ClassOfCar = ClassOfCar.SelectedItem.ToString() == "For4Person" ? ClassesOfCar.For4Person : ClassOfCar.SelectedItem.ToString() == "For8Person" ? ClassesOfCar.For8Person : ClassesOfCar.ForVantazh;
            order.KM = Double.Parse(KM.Text);
            order.Money = Double.Parse(Price.Text);
            order.LocationFrom = new Location() { Place = From.Text };
            order.LocationTo = new Location() { Place = To.Text };

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
            if (e.Key == Key.Enter && From.Text != "" && To.Text!= "" && ClassOfCar.SelectedIndex!=-1)
            {
                ClassesOfCar classesOfCar = ClassOfCar.SelectedItem.ToString() == "For4Person" ? ClassesOfCar.For4Person : ClassOfCar.SelectedItem.ToString() == "ForPerson" ? ClassesOfCar.For8Person : ClassesOfCar.ForVantazh;
                Random r = new Random();
                KM.Text = r.Next(1, 100).ToString();
                Price.Text = MainWindow.client.GetPrice(Double.Parse(KM.Text), classesOfCar).ToString();
            }
        }

    
    }
}