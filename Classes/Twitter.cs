using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEcoursework.Classes
{
    class Twitter :Message
    {

        public Twitter()
        {
            
        }

        public Twitter(string message_tbx, string sender)
        :base()
        {
            CollectHashtag(message_tbx);
            ReplaceAbbreviation(message_tbx);
            WriteToJsonFile(this, "twitter");
        }

    }


}