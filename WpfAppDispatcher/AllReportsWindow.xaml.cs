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
    /// Логика взаимодействия для AllReportsWindow.xaml
    /// </summary>
    public partial class AllReportsWindow : Window
    {
        List<Report> reports;
        public AllReportsWindow()
        {
            InitializeComponent();
            reports = MainWindow.dispatcher.AllReports().ToList();
            calendar.SelectedDate = DateTime.Now;
            foreach(var elem in MainWindow.dispatcher.AllDrivers())
            {
                Drivers.Children.Add(new CheckBox() { Content = (elem.FirstName + " " + elem.SecondName) });
            }
        }
        public AllReportsWindow(int idDriver)
        {
            reports = reports.Where(elem => elem.Driver.Id == idDriver).ToList();
            Prev.Visibility = Visibility.Hidden;
            Next.Visibility = Visibility.Hidden;
            foreach(var elem in Drivers.Children)
            {
                if(elem is CheckBox && (elem as CheckBox).Content.ToString() == reports[0].Driver.FirstName + " "+reports[0].Driver.SecondName)
                {
                    (elem as CheckBox).IsChecked = true;
                }
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Prev_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DateTime date = calendar.SelectedDate.Value;
                Report report = reports.First(elem => elem.Date == date);
                KM.Text = report.KM.ToString();
                Money.Text = report.Money.ToString();
                Driver.Text = report.Driver.FirstName + " " + report.Driver.SecondName;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
