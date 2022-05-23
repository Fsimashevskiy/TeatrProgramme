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
        public User(string log)
        {
            InitializeComponent();
            BoxUser.Text += log;
        }

        

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

       


        

        private void Postanovki_Click(object sender, RoutedEventArgs e)
        {
            string log = BoxUser.Text;

            PostanovkiUser postanovkiUser = new PostanovkiUser(log);
            postanovkiUser.Show();
            this.Close();
        }

       

        private void Ticket_Click(object sender, RoutedEventArgs e)
        {
            string log = BoxUser.Text;
            TicketUser ticketUser = new TicketUser(log);
            ticketUser.Show();
            this.Close();
        }

        private void MyTickets_Click(object sender, RoutedEventArgs e)
        {
            string log = BoxUser.Text;

            MyTickets myTickets = new MyTickets(log);
            myTickets.Show();
            this.Close();
        }

        private void MyCards_Click(object sender, RoutedEventArgs e)
        {
            string log = BoxUser.Text;

            MyCards myCards = new MyCards(log);
            myCards.Show();
            this.Close();
        }
    }
}
