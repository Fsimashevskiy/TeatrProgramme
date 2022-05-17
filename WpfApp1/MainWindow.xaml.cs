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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using WpfApp1.DataSet1TableAdapters;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        UserTableAdapter user = new UserTableAdapter();
        List<string> listLog = new List<string>();

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User();
                for (int i = 0; i < listLog.Count; i++)
                {

                    if (login.Text + password.Text == listLog[i])
                    {
                        User profile = new User();
                        profile.Show();
                        this.Close();
                    }
                }
                if (password.Text != "" && login.Text != "")
                {
                    if (login.Text == "admin" && password.Text == "admin")
                    {
                        Admin admin = new Admin();
                        admin.Show();
                        this.Close();
                    }
                }
            }
            catch
            {

            }


        }

        public void User()
        {
            for (int i = 0; i < user.GetData().Count(); i++)
            {

                listLog.Add(user.GetData().Rows[i][4].ToString() + user.GetData().Rows[i][5].ToString());

            }
        }

        private void regin_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void password_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            var stringData = (string)e.DataObject.GetData(typeof(string));
            if (stringData == null || !stringData.All(IsGood))
                e.CancelCommand();
        }

        private void login_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            var stringData = (string)e.DataObject.GetData(typeof(string));
            if (stringData == null || !stringData.All(IsGood))
                e.CancelCommand();
        }

        private void login_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(IsGood);
        }

        private void password_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(IsGood);
        }

        bool IsGood(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            if (c >= 'a' && c <= 'z')
                return true;
            if (c >= 'A' && c <= 'Z')
                return true;
            if (c == '@' || c == '%' || c == '$' || c == '#' || c == '*' || c == '!' || c == '&' || c == '?' || c == '_')
                return true;
            return false;
        }

        

    }
}
