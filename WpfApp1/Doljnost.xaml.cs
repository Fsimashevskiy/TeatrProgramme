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
    /// Логика взаимодействия для Doljnost.xaml
    /// </summary>
    public partial class Doljnost : Window
    {
        public Doljnost()
        {
            InitializeComponent();
            UpdateDoljnost();
        }

        private void UpdateDoljnost()
        {
            Doljnost_ViewTableAdapter adapter
                = new Doljnost_ViewTableAdapter();
            DataSet1.Doljnost_ViewDataTable table
                = new DataSet1.Doljnost_ViewDataTable();
            adapter.Fill(table);
            doljDataGreed.ItemsSource = table;
        }

       

      
        


        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }
    
   

        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new DoljnostTableAdapter().InsertQuery(dolj1.Text, Convert.ToInt32(dolj2.Text));

                UpdateDoljnost();
            }
            catch
            {

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (doljDataGreed.SelectedItem as DataRowView != null)
                {
                    new DoljnostTableAdapter().DeleteQuery(Convert.ToInt32((doljDataGreed.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdateDoljnost();
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
                if (doljDataGreed.SelectedItem as DataRowView != null)
                {
                    new DoljnostTableAdapter().UpdateQuery(dolj1.Text, Convert.ToInt32(dolj2.Text), Convert.ToInt32((doljDataGreed.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdateDoljnost();
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

        private void doljDataGreed_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Код должности")
            {
                e.Cancel = true;
            }
        }
    }
}
