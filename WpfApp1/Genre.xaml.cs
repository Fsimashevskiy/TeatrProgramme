using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Genre.xaml
    /// </summary>
    public partial class Genre : Window
    {
        public Genre()
        {
            InitializeComponent();
            UpdateGenre();
        }

        private void UpdateGenre()
        {
            View_GenreTableAdapter adapter
                = new View_GenreTableAdapter();
            DataSet1.View_GenreDataTable table
                = new DataSet1.View_GenreDataTable();
            adapter.Fill(table);
            GenreDataGreed.ItemsSource = table;
        }

       

        

       

        
    

    private void back_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }

        private void Dovabit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new GenreTableAdapter().InsertQuery(Genre1.Text);
                UpdateGenre();
            }
            catch
            {
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (GenreDataGreed.SelectedItem as DataRowView != null)
                {
                    new GenreTableAdapter().DeleteQuery(Convert.ToInt32((GenreDataGreed.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdateGenre();
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
                if (GenreDataGreed.SelectedItem as DataRowView != null)
                {
                    new GenreTableAdapter().UpdateQuery(Genre1.Text, Convert.ToInt32((GenreDataGreed.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdateGenre();
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
    }
}
