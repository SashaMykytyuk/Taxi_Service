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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        bool ChangedEmail;
        bool ChangedFirstName;
        bool ChangedSecondName;
        bool ChangedPassword;
        bool r;
        public Registration(bool registration)
        {
            InitializeComponent();
            r = registration;
            if (r == false)
            {
                Show();
            }
        }
        void Show()
        {
            Email.Text = MainWindow.dispatcher.AboutDispatcher().Email;
            FN.Text = MainWindow.dispatcher.AboutDispatcher().FirstName;
            SN.Text = MainWindow.dispatcher.AboutDispatcher().SecondName;
            Password.Password = MainWindow.dispatcher.AboutDispatcher().Password;
            ChangedEmail = false;
            ChangedFirstName = false;
            ChangedSecondName = false;
            ChangedPassword = false;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (r == true)
            {
                string str = MainWindow.dispatcher.Registration(new ServiceReference.Dispatcher()
                {
                    Email = Email.Text,
                    FirstName = FN.Text,
                    SecondName = SN.Text,
                    Password = Password.Password
                });
                if (str == "")
                    this.Close();
                else MessageBox.Show(str);
            }
            else if (r == false && (ChangedSecondName == true || ChangedFirstName == true || ChangedEmail == true || ChangedPassword == true))
            {
                if (MessageBox.Show("Are you really want to save changes?", "Save changes?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string res = "";
                    if (ChangedEmail == true)
                        res += MainWindow.dispatcher.ChangeInfo(Changes.Email, Email.Text);
                    if (ChangedPassword == true)
                        res += MainWindow.dispatcher.ChangeInfo(Changes.Password, Password.Password);
                    if (ChangedFirstName == true)
                        res += MainWindow.dispatcher.ChangeInfo(Changes.FirstName, FN.Text) ;
                    if (ChangedSecondName == true)
                        res += MainWindow.dispatcher.ChangeInfo(Changes.SecondName, SN.Text) ;
                    if (res == "")
                        MessageBox.Show("All changes are save");
                    else MessageBox.Show(res);
                    Show();
                }

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
