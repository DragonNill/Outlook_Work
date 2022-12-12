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
using Outlook_Work.Models.Entities;

namespace Outlook_Work.Windows.Infomation
{
    /// <summary>
    /// Логика взаимодействия для InfoAboutUser.xaml
    /// </summary>
    public partial class InfoAboutUser : Window
    {
        OutlookWorkDatabaseContext context;
        Users user;

        public InfoAboutUser(Users user)
        {
            InitializeComponent();
            context = OutlookWorkDatabaseContext.DbContext;
            this.user = user;
        }



        private void CheckCurrentUser()
        {
            nameTextBox.Text = user.UserName;
            loginTextBox.Text = user.UserLogin;
            emailTextBox.Text = user.UserEmail;
            patronomycTextBox.Text = user.UserPatronomyc;
            telephoneTextBox.Text = user.UserTelephone;
            surnameTextBox.Text = user.UserSurname;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CheckCurrentUser();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
