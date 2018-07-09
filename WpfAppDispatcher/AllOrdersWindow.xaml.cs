﻿using System;
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
    /// Логика взаимодействия для AllOrdersWindow.xaml
    /// </summary>
    public partial class AllOrdersWindow : Window
    {
        int? idDriver;
        List<Order> orders;
        int i = 0;
        public AllOrdersWindow()
        {
            InitializeComponent();
            orders = MainWindow.dispatcher.AllOrders().ToList();
            idDriver = null;
            foreach(var elem in MainWindow.dispatcher.AllDrivers())
            {
                Drivers.Items.Add(elem.FirstName + "  " + elem.SecondName);
            }

            Show();
        }
        public AllOrdersWindow(int idDriver) 
        {
            try
            {
                this.idDriver = idDriver;
                orders = MainWindow.dispatcher.AllOrders().Where(elem => elem.Driver.Id == idDriver).ToList();
                Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (i + 1 < orders.Count)
                i++;
            Show();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (i - 1 >= 0)
                i--;
            Show();

        }
        void Show()
        {
            ClassOfCar.Text = orders[i].ClassOfCar.ToString();
            KM.Text = orders[i].KM.ToString();
            Price.Text = orders[i].Money.ToString();
            Comment.Text = orders[i].Comment;
            Done.IsChecked = orders[i].Done;
            //try
            //{
            //    Drivers.SelectedItem = (orders[i].Driver.FirstName + "  " + orders[i].Driver.SecondName);
            //}
            //catch { }
        }

        private void Drivers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string str = MainWindow.dispatcher.ChangeDriver(orders[i].Id, MainWindow.dispatcher.AllDrivers()[Drivers.SelectedIndex].Id);
            if (str == "")
            {
                if(idDriver == null)
                {
                    orders = MainWindow.dispatcher.AllOrders().ToList();
                }
                else
                    orders = MainWindow.dispatcher.AllOrders().Where(elem => elem.Driver.Id == idDriver).ToList();
                MessageBox.Show("Driver is change");
            }
            else MessageBox.Show(str);
        }
    }
}
