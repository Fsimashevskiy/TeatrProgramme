﻿using System;
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
    /// Логика взаимодействия для PostanovkiUser.xaml
    /// </summary>
    public partial class PostanovkiUser : Window
    {
        public PostanovkiUser()
        {
            InitializeComponent();
            UpdatePostanovkiUser();
        }

        private void UpdatePostanovkiUser()
        {
            View_PerformanceTableAdapter adapter
                = new View_PerformanceTableAdapter();
            DataSet1.View_PerformanceDataTable table
                = new DataSet1.View_PerformanceDataTable();
            adapter.Fill(table);
            PerformanceDataGrid.ItemsSource = table;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Show();
            this.Close();
        }
    }
}
