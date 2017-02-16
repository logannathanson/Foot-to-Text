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
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
struct COPYDATASTRUCT
{
    public IntPtr dwData;
    public int cbData;
    public IntPtr lpData;
}

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        private Process main_proc;

        private const int WM_COPYDATA = 0x004A;



        private enum MessageType
        {
            option1Text,
            option2Text,
            option3Text,
            option4Text
        };

        private Form3 frm3;


        public Form1()
        {
            InitializeComponent();
            Shown += new EventHandler(Form_Shown);
            FormClosing += new FormClosingEventHandler(Form_Closing);
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
                button1.Height = (this.Height / 5) - 20;
                button2.Height = (this.Height / 5) - 20;
                button3.Height = (this.Height / 5) - 20;
                button4.Height = (this.Height / 5) - 20;
                button5.Height = (this.Height / 5) - 20;

            button1.Location = new Point(15, 10);

            int height = this.Height;

            button2.Location = new Point(button1.Location.X, button1.Location.Y + button1.Height + 10);
            button3.Location = new Point(button1.Location.X, button2.Location.Y + button1.Height + 10);
            button4.Location = new Point(button1.Location.X, button3.Location.Y + button1.Height + 10);
            button5.Location = new Point(button1.Location.X, button4.Location.Y + button1.Height + 10);
        }

        void formB_ButtonWidthPlusWasClicked()
        {
            this.Width += 10;
            
        }

        void formB_ButtonWidthMinusWasClicked()
        {
            this.Width -= 10;
        }

        void formB_TextSizePlusWasClicked()
        {
            float currentSize = button1.Font.Size;
            int nextSize = (int)currentSize + 1;
            button1.Font = new Font("Microsoft Sans Serif", nextSize, FontStyle.Regular);
            button2.Font = button1.Font;
            button3.Font = button1.Font;
            button4.Font = button1.Font;
            button5.Font = button1.Font;

        }

        void formB_TextSizeMinusWasClicked()
        {
            float currentSize = button1.Font.Size;
            int nextSize = (int)currentSize - 1;
            if (nextSize < 1) nextSize = 1;
            button1.Font = new Font("Microsoft Sans Serif", nextSize, FontStyle.Regular);
            button2.Font = button1.Font;
            button3.Font = button1.Font;
            button4.Font = button1.Font;
            button5.Font = button1.Font;

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

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    // Need to marshall the data into a useable form
                    var data = Marshal.PtrToStructure<COPYDATASTRUCT>(m.LParam);
                    var msg = data.dwData;
                    var str = Marshal.PtrToStringAnsi(data.lpData);

                    switch ((MessageType) msg)
                    {
                        case MessageType.option1Text:
                            button1.Text = str;
                            break;
                        case MessageType.option2Text:
                            button2.Text = str;
                            break;
                        case MessageType.option3Text:
                            button3.Text = str;
                            break;
                        case MessageType.option4Text:
                            button4.Text = str;
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
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

        private void button5_Click(object sender, EventArgs e)
        {
            frm3 = new Form3();
            frm3.ButtonWidthPlusWasClicked += new Form3.ClickButton(formB_ButtonWidthPlusWasClicked);
            frm3.ButtonWidthMinusWasClicked += new Form3.ClickButton(formB_ButtonWidthMinusWasClicked);
            frm3.TextSizePlusWasClicked += new Form3.ClickButton(formB_TextSizePlusWasClicked);
            frm3.TextSizeMinusWasClicked += new Form3.ClickButton(formB_TextSizeMinusWasClicked);

            frm3.Show();
        }
    }
}
