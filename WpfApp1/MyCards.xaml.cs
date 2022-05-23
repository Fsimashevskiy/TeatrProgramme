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
            string path = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\Cards\{loginMyCardsBox.Text}";
            if (Directory.Exists(path) == true)
            {
               
                if(File.Exists(path + @"\" + Naimenovanie_bank_Text.Text)==false)
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
                MessageBox.Show("Здесь вы можете добавлять карты и пополнять их");
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
            
            
            string path = $@"C:\Users\Fsima\Desktop\WpfApp1-master\WpfApp1-master\Cards\{loginMyCardsBox.Text}\{CardBox.SelectedItem.ToString()}";

            string nomer="";
            string srok="";
            string cvv="";
            string balance="";

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                var count = reader.BaseStream.Length / sizeof(int);
                for (var i = 0; i < count; i++)
                {
                    nomer = reader.ReadString();
                    srok = reader.ReadString();
                    cvv = reader.ReadString();
                    balance = reader.ReadString();
                    decimal itog = Convert.ToDecimal(balance)+Convert.ToDecimal(PopolnitText.Text);



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
                    Balans.Content = itog.ToString();
                    break;
                    
                }                   
            }








        }


            



            //int z = Convert.ToInt32(Vvod.Text);
            //int x = Convert.ToInt32(BS.Content);
            //int y = z + x;


        }

       
    }

    

