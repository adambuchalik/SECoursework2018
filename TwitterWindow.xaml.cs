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
    public partial class TwitterWindow : Window
    {
        Twitter twitter = null;

        public TwitterWindow()
        {
            InitializeComponent();
            CanvasEnd_tweet.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string validatedSender = "";
            Regex twitterRegex = new Regex(@"(?<![^@]\w+\s+)(@\w+)",
                RegexOptions.IgnoreCase);
            Match twitterMatch = twitterRegex.Match(TwitterSender_textBox.Text);

            // Validation: Sender format
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

            // Validation: Sender length 
            if (TwitterSender_textBox.Text.Length > 16)
            {
                MessageBox.Show("Twitter address is incorrect");
                return;
            }

            // Validation: Message length
            if (TwitterMessage_textBox.Text.Length > 140)
            {
                MessageBox.Show("Twitter message cannot be longer than 140 characters");
                return;
            }

            twitter = new Twitter(TwitterMessage_textBox.Text, TwitterSender_textBox.Text, MessageId_textBox.Text);

            HashTag_lbx.ItemsSource = twitter.HashtagList;
            Mention_lbx.ItemsSource = twitter.MentionList;
            MessageText_txb.Text = twitter.MessageText;
            // Make canvas visible on the end
            CanvasEnd_tweet.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}