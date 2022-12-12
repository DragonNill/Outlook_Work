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
using Outlook_Work.UserControls;
using Outlook_Work.Windows.InfoApplication;
using Outlook_Work.Windows.Menus;

namespace Outlook_Work.Windows.Lists
{
    /// <summary>
    /// Логика взаимодействия для ShowListOfApplications.xaml
    /// </summary>
    public partial class ShowListOfApplications : Window
    {
        public OutlookWorkDatabaseContext context;
        public Users user;
        public int whichIsRole;

        public ShowListOfApplications(int id, Users onUser)
        {
            context = OutlookWorkDatabaseContext.DbContext;
            user = onUser;
            whichIsRole = id;
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FullList()
        {
            applicationListView.Items.Clear();
            List<Order> ordersList = new List<Order>();
            ordersList = context.Order.Where(u => u.CodeEmployeer == user.Iduser).ToList();
            if(!string.IsNullOrWhiteSpace(searchTextBox.Text.ToLower()))
            {
                ordersList = ordersList.Where(x => x.OrderName.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            }

            switch(filterComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    ordersList = ordersList.Where(u => u.CodeStatus == 1).ToList();
                    break;
                case 2:
                    ordersList = ordersList.Where(u => u.CodeStatus == 2).ToList();
                    break;
                case 3:
                    ordersList = ordersList.Where(u => u.CodeStatus == 3).ToList();
                    break;
            }
            switch(sortingComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    ordersList = ordersList.OrderBy(u => u.OrderDate).ToList();
                    break;
                case 2:
                    ordersList = ordersList.OrderByDescending(u => u.OrderDate).ToList();
                    break;
            }
            foreach(Order order in ordersList)
            {
                applicationListView.Items.Add(new ApplicationControl(order));
            }
        }

        private void FullComboBoxes()
        {
            filterComboBox.Items.Add("Все");
            filterComboBox.Items.Add("Готово");
            filterComboBox.Items.Add("Не готово");
            filterComboBox.Items.Add("В процессе");

            sortingComboBox.Items.Add("Без сортировки");
            sortingComboBox.Items.Add("По дате ↑");
            sortingComboBox.Items.Add("По дате ↓");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FullComboBoxes();
            FullList();
        }

        private void filterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FullList();
        }

        private void sortingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FullList();
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            FullList();
        }

        private void applicationListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Order order = ((ApplicationControl)applicationListView.SelectedItem).order;
            InfoAboutApplication.creatingForm = this;
            new InfoAboutApplication(order).ShowDialog();
        }

        private void editorinfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (applicationListView.SelectedItem != null)
            {
                Order order = ((ApplicationControl)applicationListView.SelectedItem).order;
                InfoAboutApplication.creatingForm = this;
                new InfoAboutApplication(order).ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите пожалуйста заявку");
            }
        }
    }
}
