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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

       





        

        private void back_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Postanovki_Click(object sender, RoutedEventArgs e)
        {
            Postanovki postanovki = new Postanovki();
            postanovki.Show();
            this.Close();
        }

        private void Genre_Click(object sender, RoutedEventArgs e)
        {
            Genre genre = new Genre();
            genre.Show();
            this.Close();
        }

        private void Doljnost_Click(object sender, RoutedEventArgs e)
        {
            Doljnost doljnost = new Doljnost();
            doljnost.Show();
            this.Close();
        }

        private void Sotrudniki_Click(object sender, RoutedEventArgs e)
        {
            Sotrudnik sotrudnik = new Sotrudnik();
            sotrudnik.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Spisokuchastnikov1 spisokuchastnikov1 = new Spisokuchastnikov1();
            spisokuchastnikov1.Show();
            this.Close();
        }

        private void Tickets_Click(object sender, RoutedEventArgs e)
        {
            TicketAdmin ticketAdmin = new TicketAdmin();
            ticketAdmin.Show();
            this.Close();
        }
    }
}
