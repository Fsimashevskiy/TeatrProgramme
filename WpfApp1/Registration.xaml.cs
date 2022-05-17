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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

       

        private void Zareg_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Pass.Text == PassPov.Text)
                {
                    if (Pass.Text != "" && PassPov.Text != "" && Log.Text != "" && Imya.Text != "" && Fam.Text != "" && Otch.Text != "")
                    {
                        new UserTableAdapter().InsertQuery(Fam.Text, Imya.Text, Otch.Text, Log.Text, Pass.Text);
                        MessageBox.Show("Регистрация прошла успешно!");
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error 901");
            }
        }

        private void Back_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

       
    }
}
