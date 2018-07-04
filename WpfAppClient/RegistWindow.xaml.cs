using DAL;
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
using WpfAppClient.ServiceReference;
namespace WpfAppClient
{
    /// <summary>
    /// Interaction logic for RegistWindow.xaml
    /// </summary>
    public partial class RegistWindow : Window
    {
        bool ChangedEmail;
        bool ChangedFirstName;
        bool ChangedSecondName;
        bool ChangedPassword;
        bool r;
        public RegistWindow(bool registr)
        {
            InitializeComponent();
            r = registr;
            if(r==false)
            {
                ShowInfo();
            }
        }

        void ShowInfo()
        {
            try
            {
               
                Email.Text = MainWindow.client.AboutClient().Email;
                Password.Password = MainWindow.client.AboutClient().Password;
                FirstName.Text = MainWindow.client.AboutClient().FirstName;
                SecondName.Text = MainWindow.client.AboutClient().SecondName;

                ChangedEmail = false;
                ChangedFirstName = false;
                ChangedPassword = false;
                ChangedSecondName = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (r == false && (ChangedSecondName == true || ChangedFirstName == true || ChangedEmail == true || ChangedPassword == true))
            {
                if (MessageBox.Show("Are you really want to save changes?", "Save changes?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string res = "";
                    if (ChangedEmail == true)
                        res += MainWindow.client.ChangeInfoAboutClient(Changes.Email, Email.Text);
                    if (ChangedPassword == true)
                        res += MainWindow.client.ChangeInfoAboutClient(Changes.Password, Password.Password);
                    if (ChangedFirstName == true)
                        res += MainWindow.client.ChangeInfoAboutClient(Changes.FirstName, FirstName.Text);
                    if (ChangedSecondName == true)
                        res += MainWindow.client.ChangeInfoAboutClient(Changes.SecondName, SecondName.Text);
                    if (res == "")
                        MessageBox.Show("All changes are save");
                    else MessageBox.Show(res);
                    ShowInfo();
                }

            }
            else if (r == true)
            {
                string str = MainWindow.client.Registration(new Client() { Email = Email.Text, FirstName = FirstName.Text, SecondName = SecondName.Text, Password = Password.Password });
                if (str == "")
                    this.Close();
                else MessageBox.Show(str);
            }
            else this.Close();
        }

        private void SN_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangedSecondName = true;
        }

        private void FN_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangedFirstName = true;
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangedEmail = true;
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ChangedPassword = true;
        }
    }
}
