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
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MyCards.xaml
    /// </summary>
    public partial class MyCards : Window
    {
        public MyCards( string log)
        {
            InitializeComponent();
            loginMyCardsBox.Text += log;
            UpdateBox();

            
        }

       
    
        private void Pochitat_Click(object sender, RoutedEventArgs e)
        {

            if (Nomer_Card_Text.Text.Length < 16 || Srok_Text.Text.Length < 5 || CVV_Text.Text.Length < 3)
            {

                MessageBox.Show("Введите корректные данные вашей карты!");
                Nomer_Card_Text.Clear();
                Nomer_Card_Text.Focus();
                Srok_Text.Clear();
                Srok_Text.Focus();
                CVV_Text.Clear();
                CVV_Text.Focus();
            }

            //if (Srok_Text.Text.Length < 5)
            //{
            //    MessageBox.Show("Введите корректный срок действия карточки!");
            //    Srok_Text.Clear();
            //    Srok_Text.Focus();
            //}

            //if(CVV_Text.Text.Length < 3)
            //{
            //    MessageBox.Show("Введите корректный CVV!");
            //    CVV_Text.Clear();
            //    CVV_Text.Focus();
            //}

            else
            {
                string path = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\Cards\{loginMyCardsBox.Text}";
                if (Directory.Exists(path) == true)
                {

                    if (File.Exists(path + @"\" + Naimenovanie_bank_Text.Text) == false)
                    {
                        using (BinaryWriter binwr1 = new BinaryWriter(File.Create(path + @"\" + Naimenovanie_bank_Text.Text)))
                        {
                            string nomerkarty = Nomer_Card_Text.Text;
                            string srok = Srok_Text.Text;
                            string cvv = CVV_Text.Text;

                            binwr1.Write(nomerkarty);
                            binwr1.Write(srok);
                            binwr1.Write(cvv);
                            binwr1.Write("0");
                            MessageBox.Show("Ваша карта оформлена!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы уже добавляли такую карту");
                    }
                }
                else
                {
                    Directory.CreateDirectory(path);
                    if (File.Exists(path + @"\" + Naimenovanie_bank_Text.Text) == false)
                    {
                        using (BinaryWriter binwr1 = new BinaryWriter(File.Create(path + @"\" + Naimenovanie_bank_Text.Text)))
                        {
                            string nomerkarty = Nomer_Card_Text.Text;
                            string srok = Srok_Text.Text;
                            string cvv = CVV_Text.Text;

                            binwr1.Write(nomerkarty);
                            binwr1.Write(srok);
                            binwr1.Write(cvv);
                            binwr1.Write("0");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы уже добавляли такую карту");
                    }
                }
                UpdateBox();


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string log = loginMyCardsBox.Text;
            User user = new User(log);
            user.Show();
            this.Close();
        }
        private void UpdateBox()
        {
            string path = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\Cards\{loginMyCardsBox.Text}";
            int i = 0;
            if (Directory.Exists(path) == false )
            {
                
            }
            else {
                while (i < Directory.GetFiles(path).Count())
                {
                    string filename = Directory.GetFiles(path)[i];
                    var replacement = filename.Replace($@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\Cards\{loginMyCardsBox.Text}\", "");
                    if (CardBox.Items.Contains(replacement) == false)
                    {
                        CardBox.Items.Add(replacement);
                    }
                    i++;
                }
            }

        }


        private void Popolnit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (PopolnitText.Text.Contains("-") == false)
                {
                    



                    string path = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\Cards\{loginMyCardsBox.Text}\{CardBox.SelectedItem.ToString()}";
                    string nomer = "";
                    string srok = "";
                    string cvv = "";
                    string balance = "";

                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        var count = reader.BaseStream.Length / sizeof(int);
                        for (var i = 0; i < count; i++)
                        {
                            nomer = reader.ReadString();
                            srok = reader.ReadString();
                            cvv = reader.ReadString();
                            balance = reader.ReadString();
                            decimal itog = Convert.ToDecimal(balance) + Convert.ToDecimal(PopolnitText.Text);



                            reader.Close();

                            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Open)))
                            {
                                var countt = writer.BaseStream.Length / sizeof(int);
                                for (var j = 0; j < countt; j++)
                                {
                                    writer.Write(nomer);
                                    writer.Write(srok);
                                    writer.Write(cvv);
                                    writer.Write(itog.ToString());
                                    break;
                                }
                            }
                            Balans.Content = itog.ToString() + "₽";
                            break;

                        }
                    }

                }
            }

            catch
            {
                MessageBox.Show("Выберите карту!");
            }

           

        }

        private void Naimenovanie_bank_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                    textBox.Text.Where(ch => ch >= 'а' && ch <= 'я' || ch >= 'А' && ch <= 'Я' || ch == ' ' || ch >= 'a' && ch <= 'z' ||
                    ch >= 'A' && ch <= 'Z').ToArray());
            }
        }

        private void Nomer_Card_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                    textBox.Text.Where(ch => ch >= '0' && ch <= '9').ToArray());


                

            }


        }

        private void Srok_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                    textBox.Text.Where(ch => ch >= '0' && ch <= '9' || ch == '/').ToArray());




            }
        }

        private void CVV_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                    textBox.Text.Where(ch => ch >= '0' && ch <= '9').ToArray());




            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string path = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\Cards\{loginMyCardsBox.Text}\{CardBox.SelectedItem.ToString()}";
                FileInfo fileinf = new FileInfo(path);
                if (fileinf.Exists)
                {
                    fileinf.Delete();
                    CardBox.Items.Remove(fileinf.Name);
                    
                }
            }

            catch 
            {
                MessageBox.Show("Выберите карту!");
            }

           
           
            
        }

        private void PopolnitText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                    textBox.Text.Where(ch => ch >= '0' && ch <= '9').ToArray());




            }
        }






        //int z = Convert.ToInt32(Vvod.Text);
        //int x = Convert.ToInt32(BS.Content);
        //int y = z + x;


    }

       
    }

    

