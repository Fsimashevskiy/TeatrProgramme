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
            MyTicketId();
            Box.Text += log;


            //string path = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\loginbin/{Box.Text}";
            //using (BinaryReader binwr1 = new BinaryReader(File.Open(path, FileMode.Open)))
            //{
            //    var a = new UserTableAdapter().FillBy(Box.Text);



            //        MessageBox.Show(a.ToString());
            //    View_UserCheckTableAdapter adapter = new View_UserCheckTableAdapter();
            //    DataSet1.View_UserCheckDataTable table = new DataSet1.View_UserCheckDataTable();
            //    adapter.Fill(table);




            //        MyTicketDataGreed.ItemsSource = table;







            //}
            string path = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\loginbin/{Box.Text}";
            using (BinaryReader binwr1 = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                var a = new UserTableAdapter().FillBy(Box.Text);

                

                
                View_UserCheckTableAdapter adapter = new View_UserCheckTableAdapter();
                DataSet1.View_UserCheckDataTable table = new DataSet1.View_UserCheckDataTable();
                adapter.Fill(table);

                var query =
                    from login in table
                    where login.Логин == Box.Text
                    select new
                    {
                        login.Организация,
                        login.Представление,
                        login.Адрес,
                        login.Дата,
                        login.Билеты,
                        login.Цена,
                        login.Статус,
                        login.Логин
                       
                    };
                
                         

                

                MyTicketDataGreed.ItemsSource = query.ToList();


               





            }


        }

       

        


        UserTableAdapter user = new UserTableAdapter();
        List<string> listLog = new List<string>();

        private void UpdateMyTicket()
        {


            

        }

        private void MyTicketId()
        {
            
            



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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //string path = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\loginbin/{Box.Text}";
            //using (BinaryReader binwr1 = new BinaryReader(File.Open(path, FileMode.Open)))
            //{
            //    var a = new UserTableAdapter().FillBy(Box.Text);



            //    MessageBox.Show(a.ToString());
            //    View_UserCheckTableAdapter adapter = new View_UserCheckTableAdapter();
            //    DataSet1.View_UserCheckDataTable table = new DataSet1.View_UserCheckDataTable();
            //    adapter.Fill(table);

            //    var query =
            //        from login in table
            //        where login.Логин == a.ToString()
            //        select new
            //        {
            //            login.Наименование_организации,
            //            login.Название_представления,
            //            login.Адрес_зала,
            //            login.Дата,
            //            login.Количество_билетов,
            //            login.Итого,
            //            login.Статус,
            //            login.Логин


            //        };

            //    MyTicketDataGreed.ItemsSource = query;

                







            }

        

        private void MyTicketDataGreed_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Логин")
            {
                e.Cancel = true;
            }
        }
    }
    }

