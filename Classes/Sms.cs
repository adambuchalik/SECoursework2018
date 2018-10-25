using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SEcoursework.Classes
{
    class Sms : Message
    {
        public Sms(string messageId_tbx , string sender, string messageText)
        : base()
        {
            
         // phone number validation method here 
            MessageId = messageId_tbx;
            MessageText = messageText;
            Sender = sender;

         

        }
    }
}