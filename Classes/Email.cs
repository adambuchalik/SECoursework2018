using System;
using System.Windows.Documents;

namespace SEcoursework.Classes
{
    public class Email: Message
    {
        public bool SignificantIncidentReport { get; set; }


        public string SortCode { get; set; }


       
        public static string[] noi = { "Theft", "Staff Attack", "ATM Theft", "Raid", "Customer Attack", "Staff Abuse", "Bomb Threat", "Terrorism", "Suspicious Incident", "Intelligence", "Cash Loss" };
        
        

        

        public Email()
        {
            

        }

        


    }
}