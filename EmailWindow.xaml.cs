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
using Newtonsoft.Json;
using SEcoursework.Classes;

namespace SEcoursework
{
    /// <summary>
    /// Interaction logic for EmailWindow.xaml
    /// </summary>
    public partial class EmailWindow : Window
    {
        
        
        

       

        public EmailWindow()
        {
            InitializeComponent();
           
            //ComboBox source 
            NatureOfIncident_comboBox.ItemsSource = Email.natureOfIncidentArr;

            //Initial RadioButton status
            Normal_radioButton.IsChecked = true;
          
//            email.MessageId = MessageId_textBox.Text;

        }

        private void SendEmail_button_Click(object sender, RoutedEventArgs e)
        {
            Email email = new Email();
            email.MessageId = MessageId_textBox.Text;

            #region Validate subject
            // Validate subject
            if (EmailSubject_textBox.Text.Length < 20)
            {
                email.Subject = email.SetEmailSubject(EmailSubject_textBox.Text, Incident_radioButton.IsChecked.Value);
                email.ReplaceUrl(EmailMessage_textBox.Text);

            }
            else
            {
                MessageBox.Show("Subject cannot be longer than 20 characters");
                return;
            }
            #endregion


            #region  Validate email
            // validate email
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
                RegexOptions.IgnoreCase);
            Match emailMatch = emailRegex.Match(EmailSender_textBox.Text);
            if (emailMatch.Success)
            {
                email.Sender = emailMatch.ToString();
            }
            else
            {
                MessageBox.Show("Email address incorrect");
                return;
             
            }
            #endregion


            #region Validate IncidentCode and IncidentType_comboBox
            // initial validation of incidentCode and incidentType combo
            if (Normal_radioButton.IsChecked.Value != true)
            {
                if (IncidentCode_textBox.Text == "" || NatureOfIncident_comboBox.SelectedIndex < 1)
                {
                    MessageBox.Show("Enter incident code and select incident type");
                    return;
                }
                else
                {
                    email.CreateMessage(email.MessageText, email.IsIncident, IncidentCode_textBox.Text,
                        NatureOfIncident_comboBox.SelectedValue.ToString());
                }
            }
            #endregion

            #region Validate Message text 
            if (EmailMessage_textBox.Text.Length > 1028)
            {
                MessageBox.Show("Message cannot be longer than 1028 characters");
                return;
            }
            #endregion


            string json = JsonConvert.SerializeObject(email);

        }

        private void Normal_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            IncidentCanvas.Visibility = Visibility.Hidden;
        }

        private void Incident_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            IncidentCanvas.Visibility = Visibility.Visible;
        }

    
    }
}