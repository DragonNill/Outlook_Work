using Outlook_Work.Models.Entities;
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

namespace Outlook_Work.Windows.InfoApplication
{
    /// <summary>
    /// Логика взаимодействия для InfoAboutApplication.xaml
    /// </summary>
    public partial class InfoAboutApplication : Window
    {
        Order order;

        OutlookWorkDatabaseContext context;

        public static Window creatingForm { get; set; }

        public InfoAboutApplication(Order onOrder)
        {
            context = OutlookWorkDatabaseContext.DbContext;
            order = onOrder;
            InitializeComponent();
        }



        private void CheckCurrentOrder()
        {
            Status status = context.Status.Where(w => w.Idstatus == order.CodeStatus).FirstOrDefault();
            statusLabel.Content = status.StatusName;

            TextRange richText = new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd);
            contentRichTextBox.AppendText(order.OrderContent.ToString());
        }

        private void editorinfoButton_TimeChanged(object sender, MaterialDesignThemes.Wpf.TimeChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CheckCurrentOrder();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
