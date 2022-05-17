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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
        }

       

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

       


        

        private void Postanovki_Click(object sender, RoutedEventArgs e)
        {
            PostanovkiUser postanovkiUser = new PostanovkiUser();
            postanovkiUser.Show();
            this.Close();
        }

       

        private void Ticket_Click(object sender, RoutedEventArgs e)
        {
            TicketUser ticketUser = new TicketUser();
            ticketUser.Show();
            this.Close();
        }

        private void MyTickets_Click(object sender, RoutedEventArgs e)
        {
            MyTickets myTickets = new MyTickets();
            myTickets.Show();
            this.Close();
        }
    }
}
