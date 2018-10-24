using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SEcoursework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static string folderPath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        public static string folderPath = Directory.GetCurrentDirectory() + "\\email.json";
    }
}
