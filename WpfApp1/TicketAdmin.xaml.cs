using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.DataSet1TableAdapters;
using System.Data.SqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для TicketAdmin.xaml
    /// </summary>
    public partial class TicketAdmin : Window
    {
        public TicketAdmin()
        {
            InitializeComponent();
            UpdateTicketAdmin();
            
        }


        

        private void UpdateTicketAdmin()
        {
            View_UserCheckTableAdapter adapter
                = new View_UserCheckTableAdapter();
           DataSet1.View_UserCheckDataTable table
                = new DataSet1.View_UserCheckDataTable();
            adapter.Fill(table);
            AdminTicketDataGrid.ItemsSource = table;
        }



        



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }

        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AdminTicketDataGrid.SelectedItem as DataRowView != null)
                {
                    new CheckTableAdapter().UpdateQuery(Convert.ToInt32(Status.Text), Convert.ToInt32((AdminTicketDataGrid.SelectedItem as DataRowView).Row.ItemArray[0]));
            UpdateTicketAdmin();
                }
                else
                {
                    MessageBox.Show("Выберите строку!");
                }
            }
            catch
            {

            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
