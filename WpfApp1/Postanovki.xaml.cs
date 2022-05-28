using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Логика взаимодействия для Postanovki.xaml
    /// </summary>
    public partial class Postanovki : Window
    {
        public Postanovki()
        {
            InitializeComponent();
            UpdatePostanovki();
            Data1.IsEnabled = false;

           
        }

        private void UpdatePostanovki()
        {
            View_PerformanceTableAdapter adapter
                = new View_PerformanceTableAdapter();
            DataSet1.View_PerformanceDataTable table
                = new DataSet1.View_PerformanceDataTable();
            adapter.Fill(table);
            PerformanceDataGrid.ItemsSource = table;
        }

        


        private void Date_pech_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = cboTP.Text;
            string d = Data_pech.Text;
            DateTime dt = DateTime.Parse(d + " " + t);
            Data1.Text = dt.ToString();
            //Data1.Text = Data_pech.SelectedDate.ToString().Split(' ')[0];
        }

       
        
        
    


        private void Back_Click(object sender, RoutedEventArgs e)
        {
         Admin admin = new Admin();
         admin.Show();
         this.Close();

        }

        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (Performance1.Text != "" && Data1.Text != "")
                {
                    new PerformanceTableAdapter().InsertQuery(Performance1.Text, Convert.ToDateTime(Data1.Text), Convert.ToDecimal(Price.Text));

                    UpdatePostanovki();
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            catch
            {

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PerformanceDataGrid.SelectedItem as DataRowView != null)
                {
                    new PerformanceTableAdapter().DeleteQuery(Convert.ToInt32((PerformanceDataGrid.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdatePostanovki();
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
            try
            {
                if (PerformanceDataGrid.SelectedItem as DataRowView != null)
                {
                    new PerformanceTableAdapter().UpdateQuery(Performance1.Text, Convert.ToDateTime(Data1.Text), Convert.ToDecimal(Price.Text), Convert.ToInt32((PerformanceDataGrid.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdatePostanovki();
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

        private void PerformanceDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Код постановки")
            {
                e.Cancel = true;
            }
        }

        private void Price_TextChanged(object sender, TextChangedEventArgs e)
        {
           if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                    textBox.Text.Where(  ch => ch>= '0' && ch <= '9' || ch == ',').ToArray());
            }
        }

        private void Performance1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                    textBox.Text.Where(ch => ch >= 'а' && ch <= 'я' || ch >= 'А' && ch <= 'Я' || ch == ' ').ToArray());
            }
        }
    }
}
