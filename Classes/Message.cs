using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace SEcoursework.Classes
{
    public class Message
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public string MessageId { get; set; }

        public bool IsIncident { get; set; }

        // array for incident type comboBox
        public static string[] natureOfIncidentArr =
        {
            "Theft", "Staff Attack", "ATM Theft", "Raid", "Customer Attack", "Staff Abuse", "Bomb Threat", "Terrorism",
            "Suspicious Incident", "Intelligence", "Cash Loss"
        };


        public List<string> UrlQuarantineList = new List<string>();

        [JsonIgnore]
        public IEnumerable<string> UrlsContent
        {
            get { return UrlQuarantineList; }
        }

        public void AddUrlToList(string s)
        {
            UrlQuarantineList.Add(s);
        }




        public List<string> AbbreviationList = new List<string>();

        [JsonIgnore]
        public IEnumerable<string> AbreviationsContent
        {
            get { return AbbreviationList; }
        }

        public void AddAbbreviationToList(string s)
        {
            AbbreviationList.Add(s);
        }

        #region ReplaceUrl + setting MessageText

        // Sets at the same time value for MessageText property
        public void ReplaceUrl(string emailMessage_tbx)
        {
            //instantiate with this pattern 
            Regex emailRegex = new Regex(@"(https?:\/\/(?:www\.|(?!www))[^\s\.]+\.[^\s]{2,}|www\.[^\s]+\.[^\s]{2,})",
                RegexOptions.IgnoreCase);
            //find items that matches with our pattern
            MatchCollection emailMatches = emailRegex.Matches(emailMessage_tbx);

//            List<string> urlQuarantineList = new List<string>();

            foreach (Match emailMatch in emailMatches)
            {
                AddUrlToList(emailMatch.Value);
                emailMessage_tbx = emailMessage_tbx.Replace(emailMatch.Value, " < URL Quarantinened>");
            }

            MessageText = emailMessage_tbx;
        }

        #endregion

        #region ReplaceAbbreviations

        // Changed MessageText property must be passed in that method
        public void ReplaceAbbreviation(string smsMessage_tbx)
        {
            int x = 1;

            IDictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"AT", "<At your terminal>"},
                {"B4", "<Before>"},
                {"BC", "<Because>"},
                {"BF", "<Best friend>"},
                {"CU", "<See you>"},
                {"GB", "<Goodbye>"},
                {"GL", "<Good luck>"},
                {"HF", "<Have fun>"},
                {"IB", "<I'm back>"},
                {"IC", "<I see>"},
                {"IM", "<Instant message>"},
                {"JK", "<Just kidding>"},
                {"JP", "<Just playing>"},
                {"LD", "<Later, dude / Long distance>"},
                {"M8", "<Mate>"},
                {"NM", "<Nothing much / Never mind>"},
                {"NP", "<No problem>"},
                {"NW", "<No way>"},
                {"OO", "<Over and out>"},
                {"OP", "<On phone>"},
                {"PU", "<That stinks!>"},
                {"RL", "<Real life>"},
                {"SS", "<So sorry>"},
                {"TA", "<Thanks a lot>"},
                {"TC", "<Take care>"},
                {"TU", "<Thank you>"},
                {"TY", "<Thank you>"},
                {"UL", "<Upload>"},
                {"UR", "<Your / You're>"},
                {"UV", "<Unpleasant visual>"},
                {"UW", "<You're welcome>"},
                {"WB", "<Welcome back>"},
                {"WK", "<Week>"},
                {"YW", "<You're welcome>"},
                {"AAP", "<Always a pleasure>"},
                {"AAR", "<At any rate>"},
                {"AAS", "<Alive and smiling>"},
                {"ADN", "<Any day now>"},
                {"AFK", "<Away from keyboard>"},
                {"AKA", "<Also known as>"},
                {"ATM", "<At the moment>"},
                {"B/F", "<Boyfriend>"},
                {"BAK", "<Back at keyboard>"},
                {"BAU", "<Business as usual>"},
                {"BBL", "<Be back later>"},
                {"BBS", "<Be back soon>"},
                {"BFN", "<Bye for now>"},
                {"BOL", "<Best of luck>"},
                {"BRB", "<Be right back>"},
                {"BRT", "<Be right there>"},
                {"BTA", "<But then again>"},
                {"BTW", "<By the way>"},
                {"COB", "<Close of business>"},
                {"CUA", "<See you around>"},
                {"CUL", "<See you later>"},
                {"CYA", "<See ya>"},
                {"CYO", "<See you online>"},
                {"D/L", "<Download>"},
                {"DTS", "<Don't think so>"},
                {"EMA", "<E-mail address>"},
                {"EOD", "<End of day>"},
                {"EOM", "<End of message>"},
                {"F2F", "<Face to face>"},
                {"FBM", "<Fine by me>"},
                {"FRT", "<For real though>"},
                {"FYI", "<For your information>"},
                {"G/F", "<Girlfriend>"},
                {"GA ", "<Go ahead>"},
                {"GAL", "<Get a life>"},
                {"GBU", "<God bless you>"},
                {"GFI", "<Go for it>"},
                {"GG ", "<Gotta Go or Good Game>"},
                {"GOI", "<Get over it>"},
                {"GOL", "<Giggling out loud>"},
                {"GR8", "<Great>"},
                {"GTG", "<Got to go>"},
                {"HRU", "<How are you?>"},
                {"HTH", "<Hope this helps>"},
                {"IAC", "<In any case>"},
                {"IDK", "<I don't know>"},
                {"ILU", "<I love you>"},
                {"ILY", "<I love you>"},
                {"IMO", "<In my opinion>"},
                {"IOW", "<In other words>"},
                {"IRL", "<In real life>"},
                {"IYO", "<In your opinion>"},
                {"JAC", "<Just a sec>"},
                {"JIK", "<Just in case>"},
                {"JMO", "<Just my opinion>"},
                {"KIT", "<Keep in touch>"},
                {"L8R", "<Later>"},
                {"LOL", "<Laughing out loud>"},
                {"LTM", "<Laugh to myself>"},
                {"MoS", "<Mother over shoulder>"},
                {"NBD", "<No big deal>"},
                {"NFM", "<None for me / Not for me>"},
                {"NLT", "<No later than>"},
                {"NMH", "<Not much here>"},
                {"NRN", "<No response/reply necessary>"},
                {"OIC", "<Oh, I see>"},
                {"OMG", "<Oh my God>"},
                {"OMW", "<On my way>"},
                {"OOH", "<Out of here>"},
                {"OTB", "<Off to bed>"},
                {"OTL", "<Out to lunch>"},
                {"OTW", "<Off to work>"},
                {"PDQ", "<Pretty darn quick >"},
                {"PLZ", "<Please>"},
                {"POS", "<Parent over shoulder>"},
                {"PPL", "<People>"},
                {"PRW", "<People/parents are watching>"},
                {"PTL", "<Praise the Lord>"},
                {"PXT", "<Please explain that>"},
                {"QIK", "<Quick>"},
                {"RME", "<Rolling my eyes>"},
                {"RSN", "<Real soon now>"},
                {"SIS", "<Snickering in silence>"},
                {"SPK", "<Speak>"},
                {"SRY", "<Sorry>"},
                {"STW", "<Search the Web>"},
                {"SUL", "<See you later>"},
                {"SUP", "<What's up?>"},
                {"SYL", "<See you later>"},
                {"TAM", "<Tomorrow a.m.>"},
                {"TBD", "<To be determined>"},
                {"TBH", "<To be honest>"},
                {"THX", "<Thanks>"},
                {"TIA", "<Thanks in advance>"},
                {"TMI", "<Too much information>"},
                {"TPM", "<Tomorrow p.m.>"},
                {"WAM", "<Wait a minute>"},
                {"W/B", "<Write back>"},
                {"WKD", "<Weekend>"},
                {"WTF", "<What the f***>"},
                {"WTG", "<Way to go>"},
                {"WTH", "<What the heck?>"},
                {"WU", "<What's up?>"},
                {"YBS", "<You'll be sorry>"},
                {"AEAP", "<As early as possible>"},
                {"AISB", "<As it should be>"},
                {"AOTA", "<All of the above>"},
                {"ASAP", "<As soon as possible>"},
                {"AYEC", "<At your earliest convenience>"},
                {"B4N ", "<Bye for now>"},
                {"BCNU", "<Be seein' you>"},
                {"BLNT", "<Better luck next time>"},
                {"BM&Y", "<Between me and you>"},
                {"BTDT", "<Been there, done that>"},
                {"CMON", "<Come on>"},
                {"CWYL", "<Chat with you later>"},
                {"DEGT", "<Don't even go there>"},
                {"DIKU", "<Do I know you?>"},
                {"FISH", "<First in, still here>"},
                {"FITB", "<Fill in the blank>"},
                {"FWIW", "<For what it's worth>"},
                {"FYEO", "<For your eyes only>"},
                {"G2G ", "<Got to go>"},
                {"G2R ", "<Got to run>"},
                {"GIAR", "<Give it a rest>"},
                {"GIGO", "<Garbage in, garbage out>"},
                {"GLNG", "<Good luck next game>"},
                {"GMTA", "<Great minds think alike>"},
                {"GR&D", "<Grinning, running and ducking>"},
                {"GTRM", "<Going to read mail>"},
                {"HAGN", "<Have a good night>"},
                {"HAGO", "<Have a good one>"},
                {"HAND", "<Have a nice day>"},
                {"HHIS", "<Head hanging in shame>"},
                {"HOAS", "<Hold on a second>"},
                {"ICBW", "<It could be worse>"},
                {"IDTS", "<I don't think so>"},
                {"IIRC", "<If I remember correctly>"},
                {"IMHO", "<In my humble opinion>"},
                {"INAL", "<I'm not a lawyer>"},
                {"IRMC", "<I rest my case>"},
                {"IUSS", "<If you say so>"},
                {"IYSS", "<If you say so>"},
                {"JJA ", "<Just joking around>"},
                {"KISS", "<Keep it simple, stupid>"},
                {"KOTC", "<Kiss on the cheek>"},
                {"KNIM", "<Know what I mean?>"},
                {"LMAO", "<Laughing my a** off>"},
                {"LTNS", "<Long time no see>"},
                {"MorF", "<Male or female?>"},
                {"MUSM", "<Miss you so much>"},
                {"MYOB", "<Mind your own business>"},
                {"n00b", "<Newbie>"},
                {"NOYB", "<None of your business>"},
                {"OOTD", "<One of these days>"},
                {"OTOH", "<On the other hand>"},
                {"PITA", "<Pain In The A**>"},
                {"PLMK", "<Please let me know>"},
                {"PMFI", "<Pardon me for interrupting>"},
                {"RTFM", "<Read the f****** manual>"},
                {"SLAP", "<Sounds like a plan>"},
                {"SOMY", "<Sick of me yet?>"},
                {"SPST", "<Same place, same time>"},
                {"SSDD", "<Same stuff, different day>"},
                {"STR8", "<Straight>"},
                {"TAFN", "<That's all for now>"},
                {"TGIF", "<Thank God it's Friday>"},
                {"TIAD", "<Tomorrow is another day>"},
                {"TPTB", "<The powers that be>"},
                {"TSTB", "<The sooner, the better>"},
                {"TTFN", "<Ta ta for now>"},
                {"TTTT", "<These things take time>"},
                {"TTYL", "<Talk to you later>"},
                {"TTYS", "<Talk to you soon>"},
                {"TYT ", "<Take your time>"},
                {"TYVM", "<Thank you very much>"},
                {"UKTR", "<You know that's right>"},
                {"WAYF", "<Where are you from?>"},
                {"WRUD", "<What are you doing?>"},
                {"WUF?", "<Where are you from?>"},
                {"WWJD", "<What would Jesus do?>"},
                {"WWYC", "<Write when you can>"},
                {"YMMV", "<Your mileage may vary>"},
                {"AFAIK", "<As far as I know>"},
                {"A/S/L", "<Age/sex/location>"},
                {"BBIAF", "<Be back in a few>"},
                {"BBIAM", "<Be back in a minute>"},
                {"CMIIW", "<Correct me if I'm wrong>"},
                {"CUL8R", "<See you later>"},
                {"DQMOT", "<Don't quote me on this>"},
                {"EBKAC", "<Error between keyboard and chair>"},
                {"FOMCL", "<Falling off my chair laughing>"},
                {"GL/HF", "<Good luck, have fun>"},
                {"IANAL", "<I am not a lawyer>"},
                {"IG2R ", "<I got to run>"},
                {"ILBL8", "<I'll be late>"},
                {"LYLAS", "<Love you like a sis>"},
                {"NIMBY", "<Not in my back yard>"},
                {"PMFJI", "<Pardon me for jumping in>"},
                {"POAHF", "<Put on a happy face>"},
                {"ROTFL", "<Rolling on the floor laughing>"},
                {"SICNR", "<Sorry, I could not resist>"},
                {"SMHID", "<Scratching my head in disbelief>"},
                {"SOTMG", "<Short of time, must go>"},
                {"SSINF", "<So stupid it's not funny>"},
                {"SUITM", "<See you in the morning>"},
                {"TMWFI", "<Take my word for it>"},
                {"UGTBK", "<You've got to be kidding>"},
                {"WIIFM", "<What's in it for me?>"},
                {"WYLEI", "<When you least expect it>"},
                {"YGBKM", "<You gotta be kidding me>"},
                {"IMNSHO", "<In my not so humble opinion>"},
                {"IYKWIM", "<If you know what I mean>"},
                {"OTTOMH", "<Off the top of my head>"},
                {"SIG2R ", "<Sorry, I got to run>"},
                {"WOMBAT", "<Waste of money, brains and time>"},
                {"WAN2TLK", "<Want to talk>"},
                {"WUCIWUG", "<What you see is what you get>"},
                {"WYSIWYG", "<What you see is what you get>"},
                {"TLK2UL8R", "<Talk to you later>"},
                {"TNSTAAFL", "<There's no such thing as a free lunch>"}
            };


            foreach (KeyValuePair<string, string> item in dict)
            {
               
                //instantiate with this pattern 
                Regex urlRegex = new Regex(item.Key, RegexOptions.IgnorePatternWhitespace);
                //find items that matches with our pattern
                MatchCollection urlMatches = urlRegex.Matches($"+{smsMessage_tbx}+");


                foreach (Match urlMatch in urlMatches)
                {
                    smsMessage_tbx = item.Key + " " + smsMessage_tbx.Replace(urlMatch.Value, item.Value);
                    AddAbbreviationToList(x++ + ". " + item.Key);
                }
            }

            MessageText = smsMessage_tbx;
        }

        #endregion

        #region SetEmailSubject

        // Set subject
        public void SetEmailSubject(string emailSubject_tbx, bool incident_radioValue)
        {
            // Validate subject
            if (incident_radioValue)
            {
                Subject = $"SIR {DateTime.Today.ToString("dd/MM/yy")}";
                IsIncident = true;
            }
            else
            {
                Subject = emailSubject_tbx;
                IsIncident = false;
            }
        }

        #endregion


        #region Validate IncidentCode and IncidentType_comboBox

        public void ValidateIncidentTxb_cbx(bool iSincident_radioValue, string incidentCode_tbx,
            string natureOfIncident_cbx)
        {
            // initial validation of incidentCode and incidentType combo
            if (iSincident_radioValue == true)
            {
                if (incidentCode_tbx == "" || natureOfIncident_cbx == "")
                {
                    MessageBox.Show("Enter incident code and select incident type");
                    return;
                }
            }
        }

        #endregion

        #region Create message

        // creates message after stripping URL. combo and incident code validated in window
        public void CreateMessage(string MessageText, bool incident_radioValue, string incidentCode_tbx,
            string natureOfIncident_cbx)
        {
            if (MessageText.Length > 1028)
            {
                MessageBox.Show("Message cannot be longer than 1028 characters");
                return;
            }


            if (incident_radioValue)
            {
                this.MessageText = incidentCode_tbx + "\n" + natureOfIncident_cbx + "\n" + this.MessageText;
                MessageBox.Show(this.MessageText);
            }
            else
            {
                this.MessageText = this.MessageText;
                MessageBox.Show(this.MessageText);
            }
        }

        #endregion


        public void SetSender(string emailSender_tbx)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
                RegexOptions.IgnoreCase);
            Match emailMatch = emailRegex.Match(emailSender_tbx);
            if (emailMatch.Success)
            {
                Sender = emailMatch.ToString();
            }
            else
            {
                MessageBox.Show("Email address incorrect");
                return;
            }
        }

        /// <summary>
        /// Writes to json file. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToWrite">The object to write.</param>
        /// <param name="fileName">Name of the file. Fixed output path: <Project folder></Project>\bin\Debug</param>
        /// <param name="append">if set to <c>true</c> [append].</param>
        public void WriteToJsonFile<T>(T objectToWrite, string fileName, bool append = false) where T : new()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\" + fileName + ".json";
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }


        public static T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }


        public Message()
        {
        }
    }
}