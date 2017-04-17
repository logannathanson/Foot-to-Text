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

        Color defaultColor = Color.Transparent;
        Color highlightedColor = Color.Cyan;

        string currentHighlightedButton = "1";



        private enum MessageType
        {
            option1Text,
            option2Text,
            option3Text,
            option4Text,
            option5Text
        };

        private Form3 frm3;

        public object ApplicationFormStatus { get; private set; }

        public Form1()
        {
            this.TopLevel = true;
            this.TopMost = true;
            

            InitializeComponent();
            Shown += new EventHandler(Form_Shown);
            FormClosing += new FormClosingEventHandler(Form_Closing);

        }

        void resizeAll()
        {
            //Decrease size if too large
            while (button1.PreferredSize.Width > button1.Width || button1.PreferredSize.Height > button1.Height && button1.Font.Size > 1)
            {
                button1.Font = new Font("Franklin Gothic Medium", button1.Font.Size - 1, FontStyle.Bold);
            }
            while (button2.PreferredSize.Width > button2.Width || button2.PreferredSize.Height > button2.Height && button2.Font.Size > 1)
            {
                button2.Font = new Font("Franklin Gothic Medium", button2.Font.Size - 1, FontStyle.Bold);
            }
            while (button3.PreferredSize.Width > button3.Width || button3.PreferredSize.Height > button3.Height && button3.Font.Size > 1)
            {
                button3.Font = new Font("Franklin Gothic Medium", button3.Font.Size - 1, FontStyle.Bold);
            }
            while (button4.PreferredSize.Width > button4.Width || button4.PreferredSize.Height > button4.Height && button4.Font.Size > 1)
            {
                button4.Font = new Font("Franklin Gothic Medium", button4.Font.Size - 1, FontStyle.Bold);
            }
            while (button5.PreferredSize.Width > button5.Width || button5.PreferredSize.Height > button5.Height && button5.Font.Size > 1)
            {
                button5.Font = new Font("Franklin Gothic Medium", button5.Font.Size - 1, FontStyle.Bold);
            }

            //Increase size if too small
            while (button1.PreferredSize.Width + 10 < button1.Width && button1.PreferredSize.Height + 10 < button1.Height)
            {
                button1.Font = new Font("Franklin Gothic Medium", button1.Font.Size + 1, FontStyle.Bold);
            }
            while (button2.PreferredSize.Width + 10 < button2.Width && button2.PreferredSize.Height + 10 < button2.Height)
            {
                button2.Font = new Font("Franklin Gothic Medium", button2.Font.Size + 1, FontStyle.Bold);
            }
            while (button3.PreferredSize.Width + 10 < button3.Width && button3.PreferredSize.Height + 10 < button3.Height)
            {
                button3.Font = new Font("Franklin Gothic Medium", button3.Font.Size + 1, FontStyle.Bold);
            }
            while (button4.PreferredSize.Width + 10 < button4.Width && button4.PreferredSize.Height + 10 < button4.Height)
            {
                button4.Font = new Font("Franklin Gothic Medium", button4.Font.Size + 1, FontStyle.Bold);
            }
            while (button5.PreferredSize.Width + 10 < button5.Width && button5.PreferredSize.Height + 10 < button5.Height)
            {
                button5.Font = new Font("Franklin Gothic Medium", button5.Font.Size + 1, FontStyle.Bold);
            }
            label1.Height = button4.Height + 20;
            label1.Width = button4.Width / 4;

        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
                button1.Height = (this.Height / 5) - 20;
                button2.Height = (this.Height / 5) - 20;
                button3.Height = (this.Height / 5) - 20;
                button4.Height = (this.Height / 5) - 20;
                button5.Height = (this.Height / 5) - 20;
            label1.Height = (this.Height / 5) ;


            button1.Location = new Point(15, 10);

            int height = this.Height;

            button2.Location = new Point(button1.Location.X, button1.Location.Y + button1.Height + 10);
            button3.Location = new Point(button1.Location.X, button2.Location.Y + button1.Height + 10);
            button4.Location = new Point(button1.Location.X, button3.Location.Y + button1.Height + 10);
            button5.Location = new Point(button1.Location.X, button4.Location.Y + button1.Height + 10);
            label1.Location = new Point(button4.Location.X + button4.Width - 70, button3.Location.Y + button1.Height + 15);

            resizeAll();
        }

        void formB_ButtonWidthPlusWasClicked()
        {
            this.Width += 10;
            resizeAll();
            
        }

        void formB_ButtonWidthMinusWasClicked()
        {
            this.Width -= 10;
            resizeAll();
        }

        void formB_ButtonHeightPlusWasClicked()
        {
            this.Height += 10;
            resizeAll();

        }

        void formB_ButtonHeightMinusWasClicked()
        {
            this.Height -= 10;
            resizeAll();
        }

        void formB_ChangeColor(Color newColor)
        {
            defaultColor = newColor;
            button1.BackColor = defaultColor;
            button2.BackColor = defaultColor;
            button3.BackColor = defaultColor;
            button4.BackColor = defaultColor;
            button5.BackColor = defaultColor;

            switch(currentHighlightedButton)
            {
                case "1":
                    button1.BackColor = highlightedColor;
                    break;
                case "2":
                    button2.BackColor = highlightedColor;
                    break;
                case "3":
                    button3.BackColor = highlightedColor;
                    break;
                case "4":
                    button4.BackColor = highlightedColor;
                    break;
            }
        }

        void formB_ChangeHighlightedColor(Color newColor)
        {
            highlightedColor = newColor;

            switch (currentHighlightedButton)
            {
                case "1":
                    button1.BackColor = highlightedColor;
                    break;
                case "2":
                    button2.BackColor = highlightedColor;
                    break;
                case "3":
                    button3.BackColor = highlightedColor;
                    break;
                case "4":
                    button4.BackColor = highlightedColor;
                    break;
            }
        }

        void formB_TextSizePlusWasClicked()
        {

            float currentSize = button1.Font.Size;
            int nextSize = (int)currentSize + 1;
            button1.Font = new Font("Franklin Gothic Medium", nextSize, FontStyle.Bold);
            button2.Font = button1.Font;
            button3.Font = button1.Font;
            button4.Font = button1.Font;
            button5.Font = button1.Font;
            resizeAll();
            

        }

        void formB_TextSizeMinusWasClicked()
        {
            float currentSize = button1.Font.Size;
            int nextSize = (int)currentSize - 1;
            if (nextSize < 1) nextSize = 1;
            button1.Font = new Font("Franklin Gothic Medium", nextSize, FontStyle.Bold);
            button2.Font = button1.Font;
            button3.Font = button1.Font;
            button4.Font = button1.Font;
            button5.Font = button1.Font;
            resizeAll();

        }

        private void Form_Shown(object sender, EventArgs e)
        {
            ProcessStartInfo objProcess = new ProcessStartInfo(@"..\..\..\..\Main\Debug\Main.exe");
            objProcess.UseShellExecute = false;
            objProcess.RedirectStandardOutput = true;
            objProcess.CreateNoWindow = true; // Uncomment for release mode

            main_proc = Process.Start(objProcess);
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            main_proc.Kill(); // Dam son
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void setHighlightedButton(string str)
        {
            button1.BackColor = defaultColor;
            button2.BackColor = defaultColor;
            button3.BackColor = defaultColor;
            button4.BackColor = defaultColor;
            button5.BackColor = defaultColor;
            currentHighlightedButton = str;

            switch (str)
            {
                case "1":
                    button1.BackColor = highlightedColor;
                    break;
                case "2":
                    button2.BackColor = highlightedColor;
                    break;
                case "3":
                    button3.BackColor = highlightedColor;
                    break;
                case "4":
                    button4.BackColor = highlightedColor;
                    break;
            }

            resizeAll();
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

                    switch ((MessageType)msg)
                    {
                        case MessageType.option1Text:
                            button1.Text = str;
                            resizeAll();
                            break;
                        case MessageType.option2Text:
                            button2.Text = str;
                            resizeAll();
                            break;
                        case MessageType.option3Text:
                            button3.Text = str;
                            resizeAll();
                            break;
                        case MessageType.option4Text:
                            button4.Text = str;
                            resizeAll();
                            break;
                        case MessageType.option5Text:
                            setHighlightedButton(str);
                            break;

                    }

                    if (currentHighlightedButton !=  "4")
                    {
                        button5.Text = "Settings ↓";
                    } else
                    {
                        button5.Text = "Settings";
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
            Debug.WriteLine(Application.OpenForms.Count);

            if (Application.OpenForms.Count > 1)
            {
                Application.OpenForms[1].Close();
            }

            frm3 = new Form3();
            frm3.ButtonWidthPlusWasClicked += new Form3.ClickButton(formB_ButtonWidthPlusWasClicked);
            frm3.ButtonWidthMinusWasClicked += new Form3.ClickButton(formB_ButtonWidthMinusWasClicked);
            frm3.TextSizePlusWasClicked += new Form3.ClickButton(formB_TextSizePlusWasClicked);
            frm3.TextSizeMinusWasClicked += new Form3.ClickButton(formB_TextSizeMinusWasClicked);
            frm3.ButtonHeightPlusWasClicked += new Form3.ClickButton(formB_ButtonHeightPlusWasClicked);
            frm3.ButtonHeightMinusWasClicked += new Form3.ClickButton(formB_ButtonHeightMinusWasClicked);
            frm3.ChangeButtonColor += new Form3.ChangeColor(formB_ChangeColor);
            frm3.ChangeHighlightedColor += new Form3.ChangeColor(formB_ChangeHighlightedColor);

            frm3.Show();
            resizeAll();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
