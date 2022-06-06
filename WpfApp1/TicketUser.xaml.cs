using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        public TicketUser(string log)
        {
            InitializeComponent();
            UpdateTicketUser();
            Predstavlenie1();
            TicketBox.Text += log;

            string pu = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\Cards\{TicketBox.Text}";
            int i = 0;
            if (Directory.Exists(pu) == false)
            {
                MessageBox.Show("Здесь вы можете добавлять карты и пополнять их");
            }
            else
            {
                while (i < Directory.GetFiles(pu).Count())
                {
                    string filename = Directory.GetFiles(pu)[i];
                    var replacement = filename.Replace($@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\Cards\{TicketBox.Text}\", "");
                    if (CardBox.Items.Contains(replacement) == false)
                    {
                        CardBox.Items.Add(replacement);
                    }
                    i++;
                }
            }

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
            //TicketUserDataGrid.ItemsSource = table;
           
        }


       

        private void Kupit_Click(object sender, RoutedEventArgs e)
        {

            if (Oplata.Content != null)
            {
                //DataRowView drv = TicketUserDataGrid.Items[12] as DataRowView;
                //Int32 str1 = Convert.ToInt32(KolichestvoBiletov.Text);
                //Int32 str2 = Convert.ToInt32(drv[6]);
                //int str3 = str1 * str2;
                //MessageBox.Show(str3.ToString());

                //Price.Text = Predstavlenie.SelectedValue.ToString();

                try
                {
                    string path = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\loginbin/{TicketBox.Text}";
                    using (BinaryReader binwr1 = new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        var a = new UserTableAdapter().FillBy(TicketBox.Text);

                        



                        string pu = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\Cards\{TicketBox.Text}\{CardBox.SelectedItem.ToString()}";

                        string nomer = "";
                        string srok = "";
                        string cvv = "";
                        string balance = "";

                        using (BinaryReader reader = new BinaryReader(File.Open(pu, FileMode.Open)))
                        {
                            var count = reader.BaseStream.Length / sizeof(int);
                            for (var i = 0; i < count; i++)
                            {
                                nomer = reader.ReadString();
                                srok = reader.ReadString();
                                cvv = reader.ReadString();
                                balance = reader.ReadString();
                                reader.Close();
                                break;
                            }
                        }
                       
                        if (Convert.ToDecimal(balance) > Convert.ToDecimal(Oplata.Content))
                        {
                            if (Oplata.Content.ToString() != "0")
                            {
                                new CheckTableAdapter().InsertQuery(Convert.ToInt32(KolichestvoBiletov.Text), "Театр имени Simashevskiy", Convert.ToInt32("0"), Convert.ToInt32(a), 1, Convert.ToInt32(Predstavlenie.SelectedValue), Convert.ToDecimal(itog));
                                UpdateTicketUser();

                                using (BinaryWriter writer = new BinaryWriter(File.Open(pu, FileMode.Open)))
                                {
                                    var countt = writer.BaseStream.Length / sizeof(int);
                                    for (var j = 0; j < countt; j++)
                                    {
                                        writer.Write(nomer);
                                        writer.Write(srok);
                                        writer.Write(cvv);
                                        writer.Write((Convert.ToDecimal(balance) - Convert.ToDecimal(Oplata.Content)).ToString());
                                        break;
                                    }
                                    MessageBox.Show("Спасибо за покупку, ожидайте подтверждения операции!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Выберите количество билетов не равное 0");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Не хватает средств на балансе, пополните карточку!");
                        }
                    }

                }

                catch
                {
                    MessageBox.Show("Выберите представление или способ оплаты, возможно необходимо пополнить карточку!");
                }
            }
            else
            {

            }
        }

        private void Pochitat_Click(object sender, RoutedEventArgs e)
        {
            try
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


                itog = Convert.ToDecimal(example) * Convert.ToDecimal(KolichestvoBiletov.Text);
                Oplata.Content = itog;
            }
            catch
            {
                MessageBox.Show("Выберите представление или количество билетов!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string log = TicketBox.Text;
            User user = new User(log);
            user.Show();
            this.Close();
        }

        private void TicketUserDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Код билета" || propertyDescriptor.DisplayName == "Логин")
            {
                e.Cancel = true;
            }
        }

        private void KolichestvoBiletov_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                    textBox.Text.Where(ch => ch >= '0' && ch <= '9').ToArray());
            }
        }
    }
}
