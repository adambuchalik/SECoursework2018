using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Documents;
using SEcoursework;
using SEcoursework.Classes;


namespace SEcoursework.Classes
{
    

    public class Email : Message
    {
        
        public string Subject { get; set; }
        public bool IsIncident { get; set; }


        // array for incident type comboBox
        public static string[] natureOfIncidentArr =
        {
            "Theft", "Staff Attack", "ATM Theft", "Raid", "Customer Attack", "Staff Abuse", "Bomb Threat", "Terrorism",
            "Suspicious Incident", "Intelligence", "Cash Loss"
        };


        #region SetEmailSubject 
        // Set subject
        public string SetEmailSubject(string subjectTextBox, bool incidentRadioValue)
        {
            Subject = "";

            if (incidentRadioValue)
            {
                Subject = $"SIR {DateTime.Today.ToString("dd/MM/yy")}";
                IsIncident = true;
            }
            else
            {
                Subject = subjectTextBox;
                IsIncident = false;
            }


            return Subject;
        }
        #endregion


        #region Create Message
        // creates message after stripping URL. combo and incident code validated in window
        public void CreateMessage(string URLStrippedMessage, bool isIncident, string incidentCode,
            string natureOfIncident)
        {
            if (isIncident)
            {
                MessageText = incidentCode + "\n" + natureOfIncident + "\n" + MessageText;
                MessageBox.Show(MessageText);

            }
            else
            {
                MessageText = MessageText;
                MessageBox.Show(MessageText);
            }
        }
        #endregion


        public Email()
        {
        }
    }
}