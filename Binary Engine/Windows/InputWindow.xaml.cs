﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Binary_Engine.Windows
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        public enum Results
        {
            OK = 1,
            Cancel = 2
        }

        public string Prompt { get; private set; }

        public string Response { get; private set; }

        public Results Result { get; private set; } 

        public InputWindow()
        {
            InitializeComponent();
        }

        public static string InputBox(string prompt, string title = "", string defaultResponse = "")
        {
            InputWindow inputWindow = new InputWindow
            {
                Title = title,
                Prompt = prompt,
                Response = defaultResponse,
                Result = Results.Cancel
            };

            inputWindow.ShowDialog();

            return inputWindow.Result == Results.OK ? inputWindow.Response : string.Empty; 
        }

        private void inputWindow_Loaded(object sender, RoutedEventArgs e)
        {
            textBlock.Text = Prompt;
            textBox.Text = Response;
            textBox.Focus();
        }

        private void textBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                okButton_Click(sender, null);
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Result = Results.OK;
            Response = textBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Result = Results.Cancel;
            Response = null;
            Close();
        }
    }
}
