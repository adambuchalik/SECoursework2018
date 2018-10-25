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
            // canvas with end message visible
            CanvasEnd.Visibility = Visibility.Visible;
            email = new Email(MessageId_textBox.Text, EmailSender_textBox.Text, EmailSubject_textBox.Text, EmailMessage_textBox.Text, IncidentCode_textBox.Text, NatureOfIncident_comboBox.Text, Incident_radioButton.IsChecked.Value);
            // final message put on canvas
            CanvasEnd_textBlock.Text = email.MessageText;
            urls_listbox.ItemsSource = email.UrlQuarantineList;
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