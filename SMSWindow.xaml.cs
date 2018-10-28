﻿using System;
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
using System.Windows.Shapes;
using SEcoursework.Classes;

namespace SEcoursework
{
    /// <summary>
    /// Interaction logic for SMSWindow.xaml
    /// </summary>
    public partial class SMSWindow : Window
    {
        private Sms sms = null;
        public SMSWindow()
        {
            InitializeComponent();
            CanvasEnd.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageId_textBox.Text.Length > 160)
            {
                MessageBox.Show("SMS cannot be longer than 160 characters");
                return;
            }
            else
            {
                CanvasEnd.Visibility = Visibility.Visible;
            sms = new Sms(MessageId_textBox.Text, SMSSender_textBox.Text, SMSMessage_textBox.Text);
            //            Abbrieviations_listBox.ItemsSource = 
            CanvasEnd_textBlock.Text = sms.MessageText;

           
                Abbrieviations_listBox.ItemsSource = sms.AbbreviationList;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}