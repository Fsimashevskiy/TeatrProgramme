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
    /// Логика взаимодействия для Spisokuchastnikov1.xaml
    /// </summary>
    public partial class Spisokuchastnikov1 : Window
    {
        public Spisokuchastnikov1()
        {
            InitializeComponent();
            UpdateSpisokUchastnikov();
            Performance();
            Sotrudnik();
        }

        private void Performance()
        {
            View_PerformanceTableAdapter adapter
                = new View_PerformanceTableAdapter();
            DataSet1.View_PerformanceDataTable table
                = new DataSet1.View_PerformanceDataTable();
            adapter.Fill(table);
            PerformanceBox.ItemsSource = table;
            PerformanceBox.DisplayMemberPath = "Наименование постановки";
            PerformanceBox.SelectedValuePath = "Код постановки";
        }

        private void Sotrudnik()
        {
            View_SotrudnikTableAdapter adapter
                = new View_SotrudnikTableAdapter();
            DataSet1.View_SotrudnikDataTable table
                = new DataSet1.View_SotrudnikDataTable();
            adapter.Fill(table);
            SotrudnikBox.ItemsSource = table;
            SotrudnikBox.DisplayMemberPath = "Фамилия";
            SotrudnikBox.SelectedValuePath = "Код сотрудника";
        }


        private void UpdateSpisokUchastnikov()
        {
            View_Spisok_uchastnikovTableAdapter adapter
                = new View_Spisok_uchastnikovTableAdapter();
            DataSet1.View_Spisok_uchastnikovDataTable table
                = new DataSet1.View_Spisok_uchastnikovDataTable();
            adapter.Fill(table);
            SpisokSotrudnikDataGrid.ItemsSource = table;
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
                new Spisok_uchastnikovTableAdapter().InsertQuery(Character.Text, Convert.ToInt32(PerformanceBox.SelectedValue), Convert.ToInt32(SotrudnikBox.SelectedValue));

                UpdateSpisokUchastnikov();
            }
            catch
            {

            }
        }



        private void Change_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SpisokSotrudnikDataGrid.SelectedItem as DataRowView != null)
                {

                    new Spisok_uchastnikovTableAdapter().UpdateQuery(Character.Text, Convert.ToInt32(PerformanceBox.SelectedValue), Convert.ToInt32(SotrudnikBox.SelectedValue), Convert.ToInt32((SpisokSotrudnikDataGrid.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdateSpisokUchastnikov();
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SpisokSotrudnikDataGrid.SelectedItem as DataRowView != null)
                {
                    new Spisok_uchastnikovTableAdapter().DeleteQuery(Convert.ToInt32((SpisokSotrudnikDataGrid.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdateSpisokUchastnikov();
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

        private void SpisokSotrudnikDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Код списка участников")
            {
                e.Cancel = true;
            }
        }
    }
}
