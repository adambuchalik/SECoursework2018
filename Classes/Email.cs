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