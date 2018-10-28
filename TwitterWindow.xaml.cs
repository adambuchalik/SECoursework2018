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
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string validatedSender = "";
            Regex twitterRegex = new Regex(@"(?<![^@]\w+\s+)(@\w+)",
                RegexOptions.IgnoreCase);
            Match twitterMatch = twitterRegex.Match(TwitterSender_textBox.Text);
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

            twitter = new Twitter(TwitterMessage_textBox.Text, TwitterSender_textBox.Text);
            
        }
    }
}