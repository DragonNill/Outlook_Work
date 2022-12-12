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
using Outlook_Work.Windows.Lists;
using Outlook_Work.Windows.Menus;
using Outlook_Work.Windows.Create;
using Outlook_Work.Windows.CreateApplication;
using Outlook_Work.Windows.Infomation;

namespace Outlook_Work.Windows.Menus
{
    /// <summary>
    /// Логика взаимодействия для MenuForAll.xaml
    /// </summary>
    public partial class MenuForAll : Window
    {
        int whichIsUser = 0;
        public OutlookWorkDatabaseContext context;
        public Users user;

        public MenuForAll(int id, Users liveUser)
        {
            context = OutlookWorkDatabaseContext.DbContext;
            user = liveUser;
            whichIsUser = id;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            nameSurnamecLabel.Content = user.UserName + " " + user.UserSurname;
            if(whichIsUser == 1)
            {
                listofapplicationsButton.Content = "Просмотреть список заявок";
                workingwithapplicationButton.Content = "Просмотреть список пользователей";
            }
            else
            {
                if (whichIsUser == 3)
                {
                    listofapplicationsButton.Content = "Просмотреть список своих заявок";
                    workingwithapplicationButton.Content = "Сформировать отчет";
                }
                else
                {
                    if (whichIsUser == 4)
                    {
                        listofapplicationsButton.Content = "Просмотреть список заявок";
                        workingwithapplicationButton.Content = "Сформировать отчет";
                    }
                }
            }
        }

        private void listofapplicationsButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Window nextWindow = new ShowListOfApplications(user.UserCodeRole,user);
            nextWindow.ShowDialog();
            Show();
        }

        private void workingwithapplicationButton_Click(object sender, RoutedEventArgs e)
        {
            if (whichIsUser == 2)
            {
                Window nextWindow = new CreateApplicationWindow(user);
                nextWindow.ShowDialog();
            }
        }

        private void personalinformationButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (whichIsUser == 2)
            {
                Window nextWindow = new InfoAboutUser(user);
                nextWindow.ShowDialog();
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
