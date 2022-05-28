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
    /// Логика взаимодействия для Sotrudnik.xaml
    /// </summary>
    public partial class Sotrudnik : Window
    {
        public Sotrudnik()
        {
            InitializeComponent();
            UpdateSotrudniki();
            Pol();
            Voice();
            Doljnost();
        }

        private void Pol()
        {
            View_PolTableAdapter adapter
                = new View_PolTableAdapter();
            DataSet1.View_PolDataTable table
                = new DataSet1.View_PolDataTable();
            adapter.Fill(table);
            PolBox.ItemsSource = table;
            PolBox.DisplayMemberPath = "Наименование пола";
            PolBox.SelectedValuePath = "Код пола";
        }

        private void Voice()
        {
            View_VoiceTableAdapter adapter
                = new View_VoiceTableAdapter();
            DataSet1.View_VoiceDataTable table
                = new DataSet1.View_VoiceDataTable();
            adapter.Fill(table);
            VoiceBox.ItemsSource = table;
            VoiceBox.DisplayMemberPath = "Тембр голоса";
            VoiceBox.SelectedValuePath = "Код голоса";
        }

        private void Doljnost()
        {
            Doljnost_ViewTableAdapter adapter
                = new Doljnost_ViewTableAdapter();
            DataSet1.Doljnost_ViewDataTable table
                = new DataSet1.Doljnost_ViewDataTable();
            adapter.Fill(table);
            DoljnostBox.ItemsSource = table;
            DoljnostBox.DisplayMemberPath = "Наименование должности";
            DoljnostBox.SelectedValuePath = "Код должности";
        }


        private void UpdateSotrudniki()
        {
            View_SotrudnikTableAdapter adapter
                = new View_SotrudnikTableAdapter();
            DataSet1.View_SotrudnikDataTable table
                = new DataSet1.View_SotrudnikDataTable();
            adapter.Fill(table);
            SotrudnikDataGrid.ItemsSource = table;
        }

        private void SotrudnikDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (SotrudnikDataGrid.SelectedItem != null && SotrudnikDataGrid.SelectedItem as DataRowView != null)
            {

                Surname.Text = (SotrudnikDataGrid.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                Name.Text = (SotrudnikDataGrid.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                Otchestvo.Text = (SotrudnikDataGrid.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
            }
        }




    

    private void back_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }

        private void dobavit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new SotrudnikTableAdapter().InsertQuery(Surname.Text, Name.Text, Otchestvo.Text, Convert.ToInt32(PolBox.SelectedValue), Convert.ToInt32(VoiceBox.SelectedValue), Convert.ToInt32(DoljnostBox.SelectedValue));

                UpdateSotrudniki();
            }
            catch
            {

            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SotrudnikDataGrid.SelectedItem as DataRowView != null)
                {

                    new SotrudnikTableAdapter().DeleteQuery(Convert.ToInt32((SotrudnikDataGrid.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdateSotrudniki();
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

        private void change_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SotrudnikDataGrid.SelectedItem as DataRowView != null)
                {
                    new SotrudnikTableAdapter().UpdateQuery(Surname.Text, Name.Text, Otchestvo.Text, Convert.ToInt32(PolBox.SelectedValue), Convert.ToInt32(VoiceBox.SelectedValue), Convert.ToInt32(DoljnostBox.SelectedValue), Convert.ToInt32((SotrudnikDataGrid.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdateSotrudniki();
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

        private void SotrudnikDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Код сотрудника")
            {
                e.Cancel = true;
            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                    textBox.Text.Where(ch => ch >= 'а' && ch <= 'я' || ch >= 'А' && ch <= 'Я' || ch == ' ').ToArray());
            }
        }

        private void Surname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                    textBox.Text.Where(ch => ch >= 'а' && ch <= 'я' || ch >= 'А' && ch <= 'Я' || ch == ' ').ToArray());
            }
        }

        private void Otchestvo_TextChanged(object sender, TextChangedEventArgs e)
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
