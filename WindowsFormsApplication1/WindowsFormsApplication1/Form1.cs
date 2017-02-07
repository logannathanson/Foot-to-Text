using System;
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


        public Form1()
        {
            InitializeComponent();
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

        private void ClearForm()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;
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
            obj.FirstName = txtFirstName.Text;
            obj.LastName = txtLastName.Text;
            obj.Phone = txtPhone.Text;

            Write(obj);
            Read();
            Display();
            ClearForm();

        }
    }
}
