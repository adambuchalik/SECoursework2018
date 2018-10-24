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
        
//        public string Subject { get; set; }
//        public bool IsIncident { get; set; }


//        // array for incident type comboBox
//        public static string[] natureOfIncidentArr =
//        {
//            "Theft", "Staff Attack", "ATM Theft", "Raid", "Customer Attack", "Staff Abuse", "Bomb Threat", "Terrorism",
//            "Suspicious Incident", "Intelligence", "Cash Loss"
//        };
//
//
//        #region SetEmailSubject 
//        // Set subject
//        public string SetEmailSubject(string subjectTextBox, bool incidentRadioValue)
//        {
//            Subject = "";
//
//            if (incidentRadioValue)
//            {
//                Subject = $"SIR {DateTime.Today.ToString("dd/MM/yy")}";
//                IsIncident = true;
//            }
//            else
//            {
//                Subject = subjectTextBox;
//                IsIncident = false;
//            }
//
//
//            return Subject;
//        }
//        #endregion
//
//
//        #region Create Message
//        // creates message after stripping URL. combo and incident code validated in window
//        public void CreateMessage(string URLStrippedMessage, bool isIncident, string incidentCode,
//            string natureOfIncident)
//        {
//            if (isIncident)
//            {
//                MessageText = incidentCode + "\n" + natureOfIncident + "\n" + MessageText;
//                MessageBox.Show(MessageText);
//
//            }
//            else
//            {
//                MessageText = MessageText;
//                MessageBox.Show(MessageText);
//            }
//        }
//        #endregion


        public Email()
        {
        }

        /// <summary>
        /// This constructor takes all controls values from Message Window. 
        /// </summary>
        /// <param name="messageId_tbx"></param>
        /// <param name="emailSender_tbx"></param>
        /// <param name="emailSubject_tbx"></param>
        /// <param name="emailMessage_tbx"></param>
        /// <param name="incidentCnv"></param>
        /// <param name="incidentCode_tbx"></param>
        /// <param name="natureOfIncident_cbx"></param>
        /// <param name="incident_radioValue"></param>
        public Email(string messageId_tbx, string emailSender_tbx, string emailSubject_tbx, string emailMessage_tbx,
            string incidentCode_tbx, string natureOfIncident_cbx, bool incident_radioValue)
        : base()
        {
            MessageId = messageId_tbx;
            ValidateIncidentTxb_cbx(incident_radioValue, incidentCode_tbx, natureOfIncident_cbx);
            SetEmailSubject( emailSubject_tbx, incident_radioValue);
            SetSender(emailSender_tbx);
            ReplaceUrl(emailMessage_tbx);
            CreateMessage(MessageText, incident_radioValue, incidentCode_tbx, natureOfIncident_cbx);
            WriteToJsonFile(this, "emalja");
           
        }
    }
}