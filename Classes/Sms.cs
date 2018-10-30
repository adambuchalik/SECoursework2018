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

            MessageId = messageId_tbx;
            Sender = sender;
            ReplaceAbbreviation(messageText);
            MessageText = MessageId + " " + Sender + " " + MessageText;
            WriteToJsonFile(this, "sms");


        }
    }
}