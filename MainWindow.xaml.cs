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
using System.Security.Cryptography;

namespace HashingOpg
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbi.SelectedIndex == 0)
            {
                
                using (SHA1 sha1 = SHA1.Create())
                {
                    byte[] hashBytes = sha1.ComputeHash(Encoding.ASCII.GetBytes(plaintext.Text));

                    // Convert the byte array to hexadecimal string
                    StringBuilder sbhex = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sbhex.Append(hashBytes[i].ToString("X2"));
                    }

                    hmacTxt.Text = plaintext.Text;
                    hex.Text = sbhex.ToString();
                }

            }
            else if (cbi.SelectedIndex == 1)
            {

                using (SHA256 sha2 = SHA256.Create())
                {
                    byte[] hashBytes = sha2.ComputeHash(Encoding.ASCII.GetBytes(plaintext.Text));

                    // Convert the byte array to hexadecimal string
                    StringBuilder sbhex = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sbhex.Append(hashBytes[i].ToString("X2"));
                    }

                    hmacTxt.Text = plaintext.Text;
                    hex.Text = sbhex.ToString();
                }


            }
            else if (cbi.SelectedIndex == 2)
            {
                string inputText = plaintext.Text;
                
                using (MD5 md5 = MD5.Create())
                {
                    byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputText));

                    // Convert the byte array to hexadecimal string
                    StringBuilder sbhex = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sbhex.Append(hashBytes[i].ToString("X2"));
                    }

                    hmacTxt.Text = inputText.ToString();
                    hex.Text = sbhex.ToString();
                }

            }
            else if (cbi.SelectedIndex == 3)
            {







                plaintext.Text = "HMAC";
            }
        }

        private void key_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void hmacTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MACHandler MacHandler = new MACHandler(cbi.Text);

            //MacHandler.ComputeMAC(s,key.Text);
        }


    }


}
