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
    /// Interaction logic for AllReportsWindow.xaml
    /// </summary>
    public partial class AllReportsWindow : Window
    {
        public AllReportsWindow()
        {
            InitializeComponent();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DateTime date = calendar.SelectedDate.Value;
                Report report = MainWindow.driver.AllReports().First(elem => elem.Date == date);
                KM.Text = report.KM.ToString();
                Money.Text = report.Money.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
