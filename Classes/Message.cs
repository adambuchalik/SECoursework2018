using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEcoursework.Classes
{
    public class Message
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public string MessageId { get; set; }
        public string AbbreviationText { get; set; }
        public string SanitizedURL { get; set; }
        public string Hashtag { get; set; }
    }
}
