using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SpisokUchastnikovUser.xaml
    /// </summary>
    public partial class SpisokUchastnikovUser : Window
    {
        public SpisokUchastnikovUser()
        {
            InitializeComponent();
            UpdateSpisokUchastnikovUser();
        }

        private void UpdateSpisokUchastnikovUser()
        {
            View_Spisok_uchastnikovTableAdapter adapter
                = new View_Spisok_uchastnikovTableAdapter();
            DataSet1.View_Spisok_uchastnikovDataTable table
                = new DataSet1.View_Spisok_uchastnikovDataTable();
            adapter.Fill(table);
            SpisokSotrudnikDataGrid.ItemsSource = table;
        }

        

        private void Back_Click_1(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Show();
            this.Close();
        }
    }
}

