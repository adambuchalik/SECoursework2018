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
    /// Interaction logic for TwitterWindow.xaml
    /// </summary>
    public partial class TwitterWindow : Window
    {
        private Twitter twitter = null;

        public TwitterWindow()
        {
            InitializeComponent();
            CanvasEnd_tweet.Visibility = Visibility.Hidden;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CanvasEnd_tweet.Visibility = Visibility.Visible;
            string validatedSender = "";
            Regex twitterRegex = new Regex(@"(?<![^@]\w+\s+)(@\w+)",
                RegexOptions.IgnoreCase);
            Match twitterMatch = twitterRegex.Match(TwitterSender_textBox.Text);

            // Sender format validation
            if (twitterMatch.Success)
            {
                validatedSender = twitterMatch.ToString();
                TwitterSender_textBox.Text = validatedSender;
            }
            else
            {
                MessageBox.Show("Twitter address is incorrect");
                return;
            }

            //Sender lenght validation 
            if (TwitterSender_textBox.Text.Length > 16)
            {
                MessageBox.Show("Twitter address is incorrect");
                return;
            }

            //Message validation
            if (TwitterMessage_textBox.Text.Length > 140)
            {
                MessageBox.Show("Twitter message cannot be longer than 140 characters");
                return;
            }


            twitter = new Twitter(TwitterMessage_textBox.Text, TwitterSender_textBox.Text, MessageId_textBox.Text);
            Abbreviation_lbx.ItemsSource = twitter.AbbreviationList;
            HashTag_lbx.ItemsSource = twitter.HashtagList;
            MessageText_txb.Text = twitter.MessageText;
            Sender_txb.Text = twitter.Sender;



        }
    }
}