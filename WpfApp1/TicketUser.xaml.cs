using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для TicketUser.xaml
    /// </summary>
    public partial class TicketUser : Window
    {
        public TicketUser()
        {
            InitializeComponent();
            UpdateTicketUser();
            Predstavlenie1();
        }

        public decimal itog;

       


        private void Predstavlenie1()
        {
            View_PerformanceTableAdapter adapter
                = new View_PerformanceTableAdapter();
            DataSet1.View_PerformanceDataTable table
                = new DataSet1.View_PerformanceDataTable();
            adapter.Fill(table);
            Predstavlenie.ItemsSource = table;
            Predstavlenie.DisplayMemberPath = "Наименование постановки";
            Predstavlenie.SelectedValuePath = "Код постановки";
            
            
            
        }

        

        private void UpdateTicketUser()
        {
            View_UserCheckTableAdapter adapter = new View_UserCheckTableAdapter();
            DataSet1.View_UserCheckDataTable table = new DataSet1.View_UserCheckDataTable();
            adapter.Fill(table);
            TicketUserDataGrid.ItemsSource = table;
           
        }


       

        private void Kupit_Click(object sender, RoutedEventArgs e)
        {

            //DataRowView drv = TicketUserDataGrid.Items[12] as DataRowView;
            //Int32 str1 = Convert.ToInt32(KolichestvoBiletov.Text);
            //Int32 str2 = Convert.ToInt32(drv[6]);
            //int str3 = str1 * str2;
            //MessageBox.Show(str3.ToString());

            //Price.Text = Predstavlenie.SelectedValue.ToString();




          
             new CheckTableAdapter().InsertQuery(Convert.ToInt32(KolichestvoBiletov.Text), "Театр имени Simashevskiy", Convert.ToInt32("5"), 1, 1, Convert.ToInt32(Predstavlenie.SelectedValue), Convert.ToDecimal(itog));
            UpdateTicketUser();
           
        }

        private void Pochitat_Click(object sender, RoutedEventArgs e)
        {
            string connStr = "Server=DESKTOP-FI66D9D;Database=Teatr;Trusted_Connection=True;";
            // создаём объект для подключения к БД
            SqlConnection conn = new SqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            // string itog1 = 'SELECT Price FROM Performance WHERE Name_Performance = Predstavlenie.SelectedItem.ToString()';
            var example = new PerformanceTableAdapter().ScalarQuery(Predstavlenie.Text);


            //int itog1 = 'SELECTgfg price FROM Performance WHERE price = "Predstavlenie.SelectedItem.ToString()"' ;
            conn.Close();


            itog= Convert.ToDecimal(example) * Convert.ToDecimal(KolichestvoBiletov.Text);
            Oplata.Content = itog;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Show();
            this.Close();
        }
    }
}
