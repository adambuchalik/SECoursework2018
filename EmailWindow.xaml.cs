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

    public partial class EmailWindow : Window
    {
        Email email = null;


        public EmailWindow()
        {
            InitializeComponent();

            // Canvas containing final message is hidden at start
            CanvasEnd.Visibility = Visibility.Hidden;

            //ComboBox source 
            NatureOfIncident_comboBox.ItemsSource = Email.natureOfIncidentArr;

            //Initial RadioButton status
            Normal_radioButton.IsChecked = true;
        }

        private void SendEmail_button_Click(object sender, RoutedEventArgs e)
        {
            // Validation: incidentCode and incidentType combo
            if (Incident_radioButton.IsChecked.Value == true)
            {
                // Validation: Source code length
                if (IncidentCode_textBox.Text.Length != 6)
                {
                    MessageBox.Show("Please enter 6 characters sort code");
                    return;
                }

                // Validation: length and if int
                int x;
                if (!Int32.TryParse(IncidentCode_textBox.Text, out x))
                {
                    MessageBox.Show("Please enter 6-digits sort code");
                    return;
                }

                if (x < 0)
                {
                    MessageBox.Show("Please enter 6-digits sort code");
                    return;
                }


                if (IncidentCode_textBox.Text == "" || NatureOfIncident_comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Enter incident code and select incident type");
                    return;
                }
            }

            // Validation: Sender
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
                RegexOptions.IgnoreCase);
            Match emailMatch = emailRegex.Match(EmailSender_textBox.Text);
            if (!emailMatch.Success)
            {
                MessageBox.Show("Email address incorrect");
                return;
            }

            // Validation: Message text 
            if (EmailMessage_textBox.Text.Length > 1028)
            {
                MessageBox.Show("Message cannot be longer than 1028 characters");
                return;
            }


            // Validation: Subject length
            if (EmailSubject_textBox.Text.Length > 20)
            {
                MessageBox.Show("Subject cannot be longer than 20 characters");
                return;
            }


            // canvas with end message visible
            CanvasEnd.Visibility = Visibility.Visible;
            email = new Email(MessageId_textBox.Text, EmailSender_textBox.Text, EmailSubject_textBox.Text,
                EmailMessage_textBox.Text, IncidentCode_textBox.Text, NatureOfIncident_comboBox.Text,
                Incident_radioButton.IsChecked.Value);
            // final message put on canvas
            CanvasEnd_textBlock.Text = email.MessageText;
        }

        private void Normal_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            // incident canvas hidden when normal message
            IncidentCanvas.Visibility = Visibility.Hidden;
        }

        private void Incident_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            // incident canvas visible when incident message
            IncidentCanvas.Visibility = Visibility.Visible;
        }

        private void EmailMessageClose_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}