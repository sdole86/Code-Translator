﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Translator
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        public string MakeUpper()
        {
            string upperString = "";
            return upperString;
        }

        public char[,,,,] BuildMatrix()
        {
            char[,,,,] matrix = new char[,,,,] { };
            return matrix;

        }


        private void translateButton_Click(object sender, EventArgs e)
        {
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            secretBox.Text = "";
            inputBox.Text = "";
            outputBox.Text = "";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
