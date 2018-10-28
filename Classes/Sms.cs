using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SEcoursework.Classes;

namespace SEcoursework.Classes
{
    class Sms : Message
    {

        public Sms()
        {
            
        }

        public Sms(string messageId_tbx , string sender, string messageText)
        : base()
        {

            //  ((?:\+|00)[17](?: |\-)?|(?:\+|00)[1-9]\d{0,2}(?: |\-)?|(?:\+|00)1\-\d{3}(?: |\-)?)?(0\d|\([0-9]{3}\)|[1-9]{0,3})(?:((?: |\-)[0-9]{2}){4}|((?:[0-9]{2}){4})|((?: |\-)[0-9]{3}(?: |\-)[0-9]{4})|([0-9]{7}))
            // phone number validation method here 
            MessageId = messageId_tbx;
            Sender = sender;
            ReplaceAbbreviation(messageText);
            WriteToJsonFile(this, "sms");


        }
    }
}