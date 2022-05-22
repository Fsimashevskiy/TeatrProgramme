using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
using WpfApp1.DataSet1TableAdapters;
using System.IO;
using System.Globalization;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MyTickets.xaml
    /// </summary>
    public partial class MyTickets : Window
    {
        public MyTickets(string log)
        {
            InitializeComponent();


            UpdateMyTicket();

            Box.Text += log;
            



            
            



        }

       

        


        UserTableAdapter user = new UserTableAdapter();
        List<string> listLog = new List<string>();

        private void UpdateMyTicket()
        {
            //string path = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\loginbin/{login}";
            //using (BinaryReader binwr1 = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            //{
            //    int a = binwr1.ReadInt32();

            //    MessageBox.Show(a.ToString());
            //}
            


        }

        


        private void back_Click(object sender, RoutedEventArgs e)
        {
            string log = Box.Text;
            User user = new User(log);
            user.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }


        


    }
}
