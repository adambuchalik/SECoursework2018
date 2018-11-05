using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SEcoursework.Classes;

namespace SEcoursework
{
    /// <summary>
    /// Interaction logic for SMSWindow.xaml
    /// </summary>
    public partial class SMSWindow : Window
    {
        private Sms sms = null;
        public SMSWindow()
        {
            InitializeComponent();
            CanvasEnd.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Validation: phone number
            string validatedSender = "";
            Regex emailRegex = new Regex(@"((?:\+|00)[17](?: |\-)?|(?:\+|00)[1-9]\d{0,2}(?: |\-)?|(?:\+|00)1\-\d{3}(?: |\-)?)?(0\d|\([0-9]{3}\)|[1-9]{0,3})(?:((?: |\-)[0-9]{2}){4}|((?:[0-9]{2}){4})|((?: |\-)[0-9]{3}(?: |\-)[0-9]{4})|([0-9]{7}))$",
                RegexOptions.IgnoreCase);
            Match emailMatch = emailRegex.Match(SMSSender_textBox.Text);
            if (emailMatch.Success)
            {
                validatedSender = emailMatch.ToString();
               }
            else
            {
                MessageBox.Show("Phone number is incorrect");
                return;
            }

            // Validation: Message length
            if (SMSMessage_textBox.Text.Length > 160)
            {
                MessageBox.Show("SMS cannot be longer than 160 characters");
                }
            else
            {
            CanvasEnd.Visibility = Visibility.Visible;
            sms = new Sms(MessageId_textBox.Text, validatedSender, SMSMessage_textBox.Text);
            CanvasEnd_textBlock.Text = sms.MessageText;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}