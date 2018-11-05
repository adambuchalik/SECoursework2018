using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SEcoursework.Classes
{
    public class MessageId
    {
        // Validates MessageID controls, creates appropriate windows, passess variables to appropriate window controls
        public static string ValidateMessageId(string messageIdPref, string messageId)
        {
            if (int.TryParse(messageId, out var messageIdNumber))
            {
                if (String.IsNullOrWhiteSpace(messageIdPref) || messageId.Length != 9)
                {
                    MessageBox.Show("Select Message Id type and input 9-digit number", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {   
                    // Create appropriate window and passes MessageId variables to screen controls
                    switch (messageIdPref)
                    {
                        case "S":
                            SMSWindow smsWindow = new SMSWindow();
                            smsWindow.MessageId_textBox.Text = messageIdPref + messageIdNumber.ToString();
                            smsWindow.ShowDialog();
                            break;
                        case "E":
                            EmailWindow emailWindow = new EmailWindow();
                            // Passing MessageId to new window textbox
                            emailWindow.MessageId_textBox.Text = messageIdPref + messageIdNumber.ToString();
                            emailWindow.ShowDialog();
                            break;
                        case "T":
                            TwitterWindow twitterWindow = new TwitterWindow();
                            twitterWindow.MessageId_textBox.Text = messageIdPref + messageIdNumber.ToString();
                            twitterWindow.ShowDialog();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("MessageId needs to be numeric", "Input Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            return messageIdPref + messageIdNumber.ToString();
        }
    }
}