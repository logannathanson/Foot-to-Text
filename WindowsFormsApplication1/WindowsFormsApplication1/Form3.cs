﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {

        public delegate void ClickButton();
        public event ClickButton ButtonWidthPlusWasClicked;
        public event ClickButton ButtonWidthMinusWasClicked;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonWidthPlus_Click(object sender, EventArgs e)
        {
            ButtonWidthPlusWasClicked();
        }

        private void buttonWidthMinus_Click(object sender, EventArgs e)
        {
            ButtonWidthMinusWasClicked();
        }

        private void textSizePlus_Click(object sender, EventArgs e)
        {

        }

        private void textSizeMinus_Click(object sender, EventArgs e)
        {

        }
    }
}