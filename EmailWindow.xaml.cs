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
using SEcoursework.Classes;

namespace SEcoursework
{
    /// <summary>
    /// Interaction logic for EmailWindow.xaml
    /// </summary>
    public partial class EmailWindow : Window
    {
        Email email = new Email();

        public EmailWindow()
        {
            InitializeComponent();

            // ComboBox source
            NatureOfIncident_comboBox.ItemsSource = Email.noi;
            string messageType = Email.noi[3];
            MessageBox.Show("XXXXXXXXXXXXXXXXXXX" + messageType);

            //Initial RadioButton status
            Normal_radioButton.IsChecked = true;

            
            

        }

        private void SendEmail_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("XXX Show me fucking ");
            email.Subject = email.GetEmailSubject(EmailSubject_textBox.Text, Incident_radioButton.IsChecked.Value);
            
            MessageBox.Show("XXX Subject = " + email.Subject);

            email.ReplaceUrl(EmailMessage_textBox.Text);
            MessageBox.Show("XXX komunikat z okna" + email.MessageText);

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
