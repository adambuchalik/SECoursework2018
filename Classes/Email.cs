using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;

namespace SEcoursework.Classes
{
    public class Email: Message
    {
        public bool SignificantIncidentReport { get; set; }


        public string SortCode { get; set; }
        public string Subject { get; set; }

      

        // array for incident type comboBox
        public static string[] noi = { "Theft", "Staff Attack", "ATM Theft", "Raid", "Customer Attack", "Staff Abuse", "Bomb Threat", "Terrorism", "Suspicious Incident", "Intelligence", "Cash Loss" };


        
        // Getting subject
        public string GetEmailSubject(string subjectTextBox, bool incidentRadioValue)
        {
            Subject = "";

            if (incidentRadioValue)
            {
                Subject = $"SIR {DateTime.Today.ToString("dd/MM/yy")}";

            }
            else
            {
                Subject = subjectTextBox;
            }

            
            return Subject;
        }

       

        public Email()
        {
            

        }

        


    }
}