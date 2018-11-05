using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SEcoursework.Classes;

namespace SEcoursework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        private string messageIdPrefix = "";
        private string messageIdNumber = "";
        
        
       

        public MainWindow()
        {
            InitializeComponent(); Random rnd = new Random();
            // Fills MessageID number with random 9-digit int
            int myRandomNo = rnd.Next(100000000, 999999999);
           
            MessageId_textBox.Text = myRandomNo.ToString();

        }


        private void WriteMessage_btn_Click(object sender, RoutedEventArgs e)
        {
            messageIdPrefix = MessageId_comboBox.Text;


            string messageId = MessageId.ValidateMessageId(MessageId_comboBox.Text, MessageId_textBox.Text);
            Console.WriteLine(messageId);
            


            var abbreviation = "AAP";
            var extractedAbbreviation = "";

            
            #region Array containing abbreviations

            switch (abbreviation)
            {
                case "AAP":
                    extractedAbbreviation = "Always a pleasure";
                    break;
                case "AAR":
                    extractedAbbreviation = "At any rate";
                    break;
                case "AAS":
                    extractedAbbreviation = "Alive and smiling";
                    break;
                case "ADN":
                    extractedAbbreviation = "Any day now";
                    break;
                case "AEAP":
                    extractedAbbreviation = "As early as possible";
                    break;
                case "AFAIK":
                    extractedAbbreviation = "As far as I know";
                    break;
                case "AFK":
                    extractedAbbreviation = "Away from keyboard";
                    break;
                case "AKA":
                    extractedAbbreviation = "Also known as";
                    break;
                case "AISB":
                    extractedAbbreviation = "As it should be";
                    break;
                case "AOTA":
                    extractedAbbreviation = "All of the above";
                    break;
                case "ASAP":
                    extractedAbbreviation = "As soon as possible";
                    break;
                case "A/S/L":
                    extractedAbbreviation = "Age/sex/location";
                    break;
                case "AT":
                    extractedAbbreviation = "At your terminal";
                    break;
                case "ATM":
                    extractedAbbreviation = "At the moment";
                    break;
                case "AYEC":
                    extractedAbbreviation = "At your earliest convenience";
                    break;
                case "B/F":
                    extractedAbbreviation = "Boyfriend";
                    break;
                case "B4":
                    extractedAbbreviation = "Before";
                    break;
                case "B4N":
                    extractedAbbreviation = "Bye for now";
                    break;
                case "BAK":
                    extractedAbbreviation = "Back at keyboard";
                    break;
                case "BAU":
                    extractedAbbreviation = "Business as usual";
                    break;
                case "BBIAF":
                    extractedAbbreviation = "Be back in a few";
                    break;
                case "BBIAM":
                    extractedAbbreviation = "Be back in a minute";
                    break;
                case "BBL":
                    extractedAbbreviation = "Be back later";
                    break;
                case "BBS":
                    extractedAbbreviation = "Be back soon";
                    break;
                case "BC":
                    extractedAbbreviation = "Because";
                    break;
                case "BCNU":
                    extractedAbbreviation = "Be seein' you";
                    break;
                case "BF":
                    extractedAbbreviation = "Best friend";
                    break;
                case "BFN":
                    extractedAbbreviation = "Bye for now";
                    break;
                case "BLNT":
                    extractedAbbreviation = "Better luck next time";
                    break;
                case "BM&Y":
                    extractedAbbreviation = "Between me and you";
                    break;
                case "BOL":
                    extractedAbbreviation = "Best of luck";
                    break;
                case "BRB":
                    extractedAbbreviation = "Be right back";
                    break;
                case "BRT":
                    extractedAbbreviation = "Be right there";
                    break;
                case "BTA":
                    extractedAbbreviation = "But then again";
                    break;
                case "BTDT":
                    extractedAbbreviation = "Been there, done that";
                    break;
                case "BTW":
                    extractedAbbreviation = "By the way";
                    break;
                case "CMIIW":
                    extractedAbbreviation = "Correct me if I'm wrong";
                    break;
                case "CMON":
                    extractedAbbreviation = "Come on";
                    break;
                case "COB":
                    extractedAbbreviation = "Close of business";
                    break;
                case "CU":
                    extractedAbbreviation = "See you";
                    break;
                case "CUA":
                    extractedAbbreviation = "See you around";
                    break;
                case "CUL":
                    extractedAbbreviation = "See you later";
                    break;
                case "CUL8R":
                    extractedAbbreviation = "See you later";
                    break;
                case "CWYL":
                    extractedAbbreviation = "Chat with you later";
                    break;
                case "CYA":
                    extractedAbbreviation = "See ya";
                    break;
                case "CYO":
                    extractedAbbreviation = "See you online";
                    break;
                case "D/L":
                    extractedAbbreviation = "Download";
                    break;
                case "DEGT":
                    extractedAbbreviation = "Don't even go there";
                    break;
                case "DIKU":
                    extractedAbbreviation = "Do I know you?";
                    break;
                case "DQMOT":
                    extractedAbbreviation = "Don't quote me on this";
                    break;
                case "DTS":
                    extractedAbbreviation = "Don't think so";
                    break;
                case "EBKAC":
                    extractedAbbreviation = "Error between keyboard and chair";
                    break;
                case "EMA":
                    extractedAbbreviation = "E-mail address";
                    break;
                case "EOD":
                    extractedAbbreviation = "End of day";
                    break;
                case "EOM":
                    extractedAbbreviation = "End of message";
                    break;
                case "F2F":
                    extractedAbbreviation = "Face to face";
                    break;
                case "FBM":
                    extractedAbbreviation = "Fine by me";
                    break;
                case "FISH":
                    extractedAbbreviation = "First in, still here";
                    break;
                case "FOMCL":
                    extractedAbbreviation = "Falling off my chair laughing";
                    break;
                case "FITB":
                    extractedAbbreviation = "Fill in the blank";
                    break;
                case "FRT":
                    extractedAbbreviation = "For real though";
                    break;
                case "FWIW":
                    extractedAbbreviation = "For what it's worth";
                    break;
                case "FYEO":
                    extractedAbbreviation = "For your eyes only";
                    break;
                case "FYI":
                    extractedAbbreviation = "For your information";
                    break;
                case "G/F":
                    extractedAbbreviation = "Girlfriend";
                    break;
                case "G2G":
                    extractedAbbreviation = "Got to go";
                    break;
                case "G2R":
                    extractedAbbreviation = "Got to run";
                    break;
                case "GA":
                    extractedAbbreviation = "Go ahead";
                    break;
                case "GAL":
                    extractedAbbreviation = "Get a life";
                    break;
                case "GB":
                    extractedAbbreviation = "Goodbye";
                    break;
                case "GBU":
                    extractedAbbreviation = "God bless you";
                    break;
                case "GFI":
                    extractedAbbreviation = "Go for it";
                    break;
                case "GG":
                    extractedAbbreviation = "Gotta Go or Good Game";
                    break;
                case "GIAR":
                    extractedAbbreviation = "Give it a rest";
                    break;
                case "GIGO":
                    extractedAbbreviation = "Garbage in, garbage out";
                    break;
                case "GL":
                    extractedAbbreviation = "Good luck";
                    break;
                case "GL/HF":
                    extractedAbbreviation = "Good luck, have fun";
                    break;
                case "GLNG":
                    extractedAbbreviation = "Good luck next game";
                    break;
                case "GMTA":
                    extractedAbbreviation = "Great minds think alike";
                    break;
                case "GOI":
                    extractedAbbreviation = "Get over it";
                    break;
                case "GOL":
                    extractedAbbreviation = "Giggling out loud";
                    break;
                case "GR8":
                    extractedAbbreviation = "Great";
                    break;
                case "GR&D":
                    extractedAbbreviation = "Grinning, running and ducking";
                    break;
                case "GTG":
                    extractedAbbreviation = "Got to go";
                    break;
                case "GTRM":
                    extractedAbbreviation = "Going to read mail";
                    break;
                case "HAGN":
                    extractedAbbreviation = "Have a good night";
                    break;
                case "HAGO":
                    extractedAbbreviation = "Have a good one";
                    break;
                case "HAND":
                    extractedAbbreviation = "Have a nice day";
                    break;
                case "HF":
                    extractedAbbreviation = "Have fun";
                    break;
                case "HHIS":
                    extractedAbbreviation = "Head hanging in shame";
                    break;
                case "HOAS":
                    extractedAbbreviation = "Hold on a second";
                    break;
                case "HRU":
                    extractedAbbreviation = "How are you?";
                    break;
                case "HTH":
                    extractedAbbreviation = "Hope this helps";
                    break;
                case "IAC":
                    extractedAbbreviation = "In any case";
                    break;
                case "IANAL":
                    extractedAbbreviation = "I am not a lawyer";
                    break;
                case "IB":
                    extractedAbbreviation = "I'm back";
                    break;
                case "IC":
                    extractedAbbreviation = "I see";
                    break;
                case "ICBW":
                    extractedAbbreviation = "It could be worse";
                    break;
                case "IDK":
                    extractedAbbreviation = "I don't know";
                    break;
                case "IDTS":
                    extractedAbbreviation = "I don't think so";
                    break;
                case "IG2R":
                    extractedAbbreviation = "I got to run";
                    break;
                case "IIRC":
                    extractedAbbreviation = "If I remember correctly";
                    break;
                case "ILBL8":
                    extractedAbbreviation = "I'll be late";
                    break;
                case "ILU":
                    extractedAbbreviation = "I love you";
                    break;
                case "ILY":
                    extractedAbbreviation = "I love you";
                    break;
                case "IM":
                    extractedAbbreviation = "Instant message";
                    break;
                case "IMHO":
                    extractedAbbreviation = "In my humble opinion";
                    break;
                case "IMNSHO":
                    extractedAbbreviation = "In my not so humble opinion";
                    break;
                case "IMO":
                    extractedAbbreviation = "In my opinion";
                    break;
                case "INAL":
                    extractedAbbreviation = "I'm not a lawyer";
                    break;
                case "IOW":
                    extractedAbbreviation = "In other words";
                    break;
                case "IRL":
                    extractedAbbreviation = "In real life";
                    break;
                case "IRMC":
                    extractedAbbreviation = "I rest my case";
                    break;
                case "IUSS":
                    extractedAbbreviation = "If you say so";
                    break;
                case "IYKWIM":
                    extractedAbbreviation = "If you know what I mean";
                    break;
                case "IYO":
                    extractedAbbreviation = "In your opinion";
                    break;
                case "IYSS":
                    extractedAbbreviation = "If you say so";
                    break;
                case "JAC":
                    extractedAbbreviation = "Just a sec";
                    break;
                case "JIK":
                    extractedAbbreviation = "Just in case";
                    break;
                case "JJA":
                    extractedAbbreviation = "Just joking around";
                    break;
                case "JK":
                    extractedAbbreviation = "Just kidding";
                    break;
                case "JMO":
                    extractedAbbreviation = "Just my opinion";
                    break;
                case "JP":
                    extractedAbbreviation = "Just playing";
                    break;
                case "KISS":
                    extractedAbbreviation = "Keep it simple, stupid";
                    break;
                case "KIT":
                    extractedAbbreviation = "Keep in touch";
                    break;
                case "KOTC":
                    extractedAbbreviation = "Kiss on the cheek";
                    break;
                case "KNIM":
                    extractedAbbreviation = "Know what I mean?";
                    break;
                case "L8R":
                    extractedAbbreviation = "Later";
                    break;
                case "LD":
                    extractedAbbreviation = "Later, dude / Long distance";
                    break;
                case "LMAO":
                    extractedAbbreviation = "Laughing my a** off";
                    break;
                case "LOL":
                    extractedAbbreviation = "Laughing out loud";
                    break;
                case "LTM":
                    extractedAbbreviation = "Laugh to myself";
                    break;
                case "LTNS":
                    extractedAbbreviation = "Long time no see";
                    break;
                case "LYLAS":
                    extractedAbbreviation = "Love you like a sis";
                    break;
                case "M8":
                    extractedAbbreviation = "Mate";
                    break;
                case "MorF":
                    extractedAbbreviation = "Male or female?";
                    break;
                case "MoS":
                    extractedAbbreviation = "Mother over shoulder";
                    break;
                case "MUSM":
                    extractedAbbreviation = "Miss you so much";
                    break;
                case "MYOB":
                    extractedAbbreviation = "Mind your own business";
                    break;
                case "n00b":
                    extractedAbbreviation = "Newbie";
                    break;
                case "NBD":
                    extractedAbbreviation = "No big deal";
                    break;
                case "NFM":
                    extractedAbbreviation = "None for me / Not for me";
                    break;
                case "NIMBY":
                    extractedAbbreviation = "Not in my back yard";
                    break;
                case "NLT":
                    extractedAbbreviation = "No later than";
                    break;
                case "NM":
                    extractedAbbreviation = "Nothing much / Never mind";
                    break;
                case "NMH":
                    extractedAbbreviation = "Not much here";
                    break;
                case "NOYB":
                    extractedAbbreviation = "None of your business";
                    break;
                case "NP":
                    extractedAbbreviation = "No problem";
                    break;
                case "NRN":
                    extractedAbbreviation = "No response/reply necessary";
                    break;
                case "NW":
                    extractedAbbreviation = "No way";
                    break;
                case "OIC":
                    extractedAbbreviation = "Oh, I see";
                    break;
                case "OMG":
                    extractedAbbreviation = "Oh my God";
                    break;
                case "OMW":
                    extractedAbbreviation = "On my way";
                    break;
                case "OO":
                    extractedAbbreviation = "Over and out";
                    break;
                case "OOH":
                    extractedAbbreviation = "Out of here";
                    break;
                case "OOTD":
                    extractedAbbreviation = "One of these days";
                    break;
                case "OP":
                    extractedAbbreviation = "On phone";
                    break;
                case "OTB":
                    extractedAbbreviation = "Off to bed";
                    break;
                case "OTL":
                    extractedAbbreviation = "Out to lunch";
                    break;
                case "OTOH":
                    extractedAbbreviation = "On the other hand";
                    break;
                case "OTTOMH":
                    extractedAbbreviation = "Off the top of my head";
                    break;
                case "OTW":
                    extractedAbbreviation = "Off to work";
                    break;
                case "PDQ":
                    extractedAbbreviation = "Pretty darn quick ";
                    break;
                case "PITA":
                    extractedAbbreviation = "Pain In The A**";
                    break;
                case "PLMK":
                    extractedAbbreviation = "Please let me know";
                    break;
                case "PLZ":
                    extractedAbbreviation = "Please";
                    break;
                case "PMFI":
                    extractedAbbreviation = "Pardon me for interrupting";
                    break;
                case "PMFJI":
                    extractedAbbreviation = "Pardon me for jumping in";
                    break;
                case "POAHF":
                    extractedAbbreviation = "Put on a happy face";
                    break;
                case "POS":
                    extractedAbbreviation = "Parent over shoulder";
                    break;
                case "PPL":
                    extractedAbbreviation = "People";
                    break;
                case "PRW":
                    extractedAbbreviation = "People/parents are watching";
                    break;
                case "PTL":
                    extractedAbbreviation = "Praise the Lord";
                    break;
                case "PXT":
                    extractedAbbreviation = "Please explain that";
                    break;
                case "PU":
                    extractedAbbreviation = "That stinks!";
                    break;
                case "QIK":
                    extractedAbbreviation = "Quick";
                    break;
                case "RL":
                    extractedAbbreviation = "Real life";
                    break;
                case "RME":
                    extractedAbbreviation = "Rolling my eyes";
                    break;
                case "ROTFL":
                    extractedAbbreviation = "Rolling on the floor laughing";
                    break;
                case "RSN":
                    extractedAbbreviation = "Real soon now";
                    break;
                case "RTFM":
                    extractedAbbreviation = "Read the f****** manual";
                    break;
                case "SICNR":
                    extractedAbbreviation = "Sorry, I could not resist";
                    break;
                case "SIG2R":
                    extractedAbbreviation = "Sorry, I got to run";
                    break;
                case "SLAP":
                    extractedAbbreviation = "Sounds like a plan";
                    break;
                case "SMHID":
                    extractedAbbreviation = "Scratching my head in disbelief";
                    break;
                case "SIS":
                    extractedAbbreviation = "Snickering in silence";
                    break;
                case "SOMY":
                    extractedAbbreviation = "Sick of me yet?";
                    break;
                case "SOTMG":
                    extractedAbbreviation = "Short of time, must go";
                    break;
                case "SPK":
                    extractedAbbreviation = "Speak";
                    break;
                case "SPST":
                    extractedAbbreviation = "Same place, same time";
                    break;
                case "SRY":
                    extractedAbbreviation = "Sorry";
                    break;
                case "SS":
                    extractedAbbreviation = "So sorry";
                    break;
                case "SSDD":
                    extractedAbbreviation = "Same stuff, different day";
                    break;
                case "SSINF":
                    extractedAbbreviation = "So stupid it's not funny";
                    break;
                case "STR8":
                    extractedAbbreviation = "Straight";
                    break;
                case "STW":
                    extractedAbbreviation = "Search the Web";
                    break;
                case "SUITM":
                    extractedAbbreviation = "See you in the morning";
                    break;
                case "SUL":
                    extractedAbbreviation = "See you later";
                    break;
                case "SUP":
                    extractedAbbreviation = "What's up?";
                    break;
                case "SYL":
                    extractedAbbreviation = "See you later";
                    break;
                case "TA":
                    extractedAbbreviation = "Thanks a lot";
                    break;
                case "TAFN":
                    extractedAbbreviation = "That's all for now";
                    break;
                case "TAM":
                    extractedAbbreviation = "Tomorrow a.m.";
                    break;
                case "TBD":
                    extractedAbbreviation = "To be determined";
                    break;
                case "TBH":
                    extractedAbbreviation = "To be honest";
                    break;
                case "TC":
                    extractedAbbreviation = "Take care";
                    break;
                case "TGIF":
                    extractedAbbreviation = "Thank God it's Friday";
                    break;
                case "THX":
                    extractedAbbreviation = "Thanks";
                    break;
                case "TIA":
                    extractedAbbreviation = "Thanks in advance";
                    break;
                case "TIAD":
                    extractedAbbreviation = "Tomorrow is another day";
                    break;
                case "TLK2UL8R":
                    extractedAbbreviation = "Talk to you later";
                    break;
                case "TMI":
                    extractedAbbreviation = "Too much information";
                    break;
                case "TMWFI":
                    extractedAbbreviation = "Take my word for it";
                    break;
                case "TNSTAAFL":
                    extractedAbbreviation = "There's no such thing as a free lunch";
                    break;
                case "TPM":
                    extractedAbbreviation = "Tomorrow p.m.";
                    break;
                case "TPTB":
                    extractedAbbreviation = "The powers that be";
                    break;
                case "TSTB":
                    extractedAbbreviation = "The sooner, the better";
                    break;
                case "TTFN":
                    extractedAbbreviation = "Ta ta for now";
                    break;
                case "TTTT":
                    extractedAbbreviation = "These things take time";
                    break;
                case "TTYL":
                    extractedAbbreviation = "Talk to you later";
                    break;
                case "TTYS":
                    extractedAbbreviation = "Talk to you soon";
                    break;
                case "TU":
                    extractedAbbreviation = "Thank you";
                    break;
                case "TY":
                    extractedAbbreviation = "Thank you";
                    break;
                case "TYT":
                    extractedAbbreviation = "Take your time";
                    break;
                case "TYVM":
                    extractedAbbreviation = "Thank you very much";
                    break;
                case "UGTBK":
                    extractedAbbreviation = "You've got to be kidding";
                    break;
                case "UKTR":
                    extractedAbbreviation = "You know that's right";
                    break;
                case "UL":
                    extractedAbbreviation = "Upload";
                    break;
                case "UR":
                    extractedAbbreviation = "Your / You're";
                    break;
                case "UV":
                    extractedAbbreviation = "Unpleasant visual";
                    break;
                case "UW":
                    extractedAbbreviation = "You're welcome";
                    break;
                case "WAM":
                    extractedAbbreviation = "Wait a minute";
                    break;
                case "WAN2TLK":
                    extractedAbbreviation = "Want to talk";
                    break;
                case "WAYF":
                    extractedAbbreviation = "Where are you from?";
                    break;
                case "W/B":
                    extractedAbbreviation = "Write back";
                    break;
                case "WB":
                    extractedAbbreviation = "Welcome back";
                    break;
                case "WIIFM":
                    extractedAbbreviation = "What's in it for me?";
                    break;
                case "WK":
                    extractedAbbreviation = "Week";
                    break;
                case "WKD":
                    extractedAbbreviation = "Weekend";
                    break;
                case "WOMBAT":
                    extractedAbbreviation = "Waste of money, brains and time";
                    break;
                case "WRUD":
                    extractedAbbreviation = "What are you doing?";
                    break;
                case "WTF":
                    extractedAbbreviation = "What the f***";
                    break;
                case "WTG":
                    extractedAbbreviation = "Way to go";
                    break;
                case "WTH":
                    extractedAbbreviation = "What the heck?";
                    break;
                case "WU?":
                    extractedAbbreviation = "What's up?";
                    break;
                case "WUCIWUG":
                    extractedAbbreviation = "What you see is what you get";
                    break;
                case "WUF?":
                    extractedAbbreviation = "Where are you from?";
                    break;
                case "WWJD":
                    extractedAbbreviation = "What would Jesus do?";
                    break;
                case "WWYC":
                    extractedAbbreviation = "Write when you can";
                    break;
                case "WYLEI":
                    extractedAbbreviation = "When you least expect it";
                    break;
                case "WYSIWYG":
                    extractedAbbreviation = "What you see is what you get";
                    break;
                case "YBS":
                    extractedAbbreviation = "You'll be sorry";
                    break;
                case "YGBKM":
                    extractedAbbreviation = "You gotta be kidding me";
                    break;
                case "YMMV":
                    extractedAbbreviation = "Your mileage may vary";
                    break;
                case "YW":
                    extractedAbbreviation = "You're welcome";
                    break;
            }

            #endregion

//
//            MessageBox.Show(extractedAbbreviation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}