﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string contactsTxtDir = "..\\..\\Contacts.txt";
        private Contact[] phoneBook = new Contact[1];
        private Process main_proc;

        private const int WM_USER = 0x0400;

        private enum MessageType
        {
            Test = WM_USER,
            Test1
        };

        public Form1()
        {
            InitializeComponent();
            Shown += new EventHandler(Form_Shown);
            FormClosing += new FormClosingEventHandler(Form_Closing);
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            ProcessStartInfo objProcess = new ProcessStartInfo(@"..\..\..\..\KeyboardInterface\main.exe");
            objProcess.UseShellExecute = false;
            objProcess.RedirectStandardOutput = true;
            //objProcess.CreateNoWindow = true; // Uncomment for release mode

            main_proc = Process.Start(objProcess);
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            main_proc.Kill(); // Dam son
        }

        private void Write(Contact obj)
        {
            StreamWriter sw = new StreamWriter(contactsTxtDir);
            sw.WriteLine(phoneBook.Length + 1);
            sw.WriteLine(obj.FirstName);
            sw.WriteLine(obj.LastName);
            sw.WriteLine(obj.Phone);

            for (int i = 0; i < phoneBook.Length; ++i)
            {
                sw.WriteLine(phoneBook[i].FirstName);
                sw.WriteLine(phoneBook[i].LastName);
                sw.WriteLine(phoneBook[i].Phone);
            }

            sw.Close();
        }

        private void Read()
        {
            StreamReader sr = new StreamReader(contactsTxtDir);
            phoneBook = new Contact[Convert.ToInt32(sr.ReadLine())];

            for (int i = 0; i < phoneBook.Length; ++i)
            {
                phoneBook[i] = new Contact();
                phoneBook[i].FirstName = sr.ReadLine();
                phoneBook[i].LastName = sr.ReadLine();
                phoneBook[i].Phone = sr.ReadLine();
            }

            sr.Close();
        }

        private void Display()
        {
            lstContacts.Items.Clear();

            for (int i = 0; i < phoneBook.Length; ++i)
            {
                lstContacts.Items.Add(phoneBook[i].ToString());
            }
            button1.Text = phoneBook[0].FirstName;
            button2.Text = phoneBook[1].FirstName;
            button3.Text = phoneBook[2].FirstName;
            button4.Text = phoneBook[3].FirstName;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
            Display();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            Contact obj = new Contact();

            Write(obj);
            Read();
            Display();
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            switch ((MessageType) m.Msg)
            {
                case MessageType.Test:
                    button1.Text = "OH shit!";
                    break;
                case MessageType.Test1:
                    button2.Text = "Whaddup!";
                    break;
            }
            base.WndProc(ref m);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
