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

//            Email email = new Email();
            NatureOfIncident_comboBox.ItemsSource = Email.noi;
            string dupa = Email.noi[3];

            Normal_radioButton.IsChecked = true;


        }

        private void SendEmail_button_Click(object sender, RoutedEventArgs e)
        {

            email.Subject = email.GetEmailSubject(EmailSubject_textBox.Text, Incident_radioButton.IsChecked.Value);
            MessageBox.Show("Subject = " + email.Subject);

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
