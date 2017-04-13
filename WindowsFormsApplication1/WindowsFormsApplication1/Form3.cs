using System;
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
        public delegate void ChangeColor(Color newColor);

        public event ClickButton ButtonWidthPlusWasClicked;
        public event ClickButton ButtonWidthMinusWasClicked;
        public event ClickButton TextSizePlusWasClicked;
        public event ClickButton TextSizeMinusWasClicked;
        public event ClickButton ButtonHeightPlusWasClicked;
        public event ClickButton ButtonHeightMinusWasClicked;

        public event ChangeColor ChangeButtonColor;
        public event ChangeColor ChangeHighlightedColor;

        private Form2 frm2;


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

        private void buttonHeightPlus_Click(object sender, EventArgs e)
        {
            ButtonHeightPlusWasClicked();
        }

        private void buttonHeightMinus_Click(object sender, EventArgs e)
        {
            ButtonHeightMinusWasClicked();
        }

        private void textSizePlus_Click(object sender, EventArgs e)
        {
            TextSizePlusWasClicked();
        }

        private void textSizeMinus_Click(object sender, EventArgs e)
        {
            TextSizeMinusWasClicked();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Close Settings button
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonColorSilver_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Silver;
            ChangeButtonColor(newColor);
        }

        private void buttonColorRed_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Red;
            ChangeButtonColor(newColor);
        }

        private void buttonColorBisque_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Bisque;
            ChangeButtonColor(newColor);
        }

        private void buttonColorPaleGreen_Click(object sender, EventArgs e)
        {
            Color newColor = Color.PaleGreen;
            ChangeButtonColor(newColor);
        }

        private void buttonColorCyan_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Cyan;
            ChangeButtonColor(newColor);
        }

        private void buttonColorPink_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Pink;
            ChangeButtonColor(newColor);
        }

        private void buttonColorTransparent_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Transparent;
            ChangeButtonColor(newColor);
        }

        private void buttonColorBurlyWood_Click(object sender, EventArgs e)
        {
            Color newColor = Color.BurlyWood;
            ChangeButtonColor(newColor);
        }

        private void buttonColorBeige_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Beige;
            ChangeButtonColor(newColor);
        }

        private void buttonColorMintCream_Click(object sender, EventArgs e)
        {
            Color newColor = Color.MintCream;
            ChangeButtonColor(newColor);
        }

        private void buttonColorSkyBlue_Click(object sender, EventArgs e)
        {
            Color newColor = Color.SkyBlue;
            ChangeButtonColor(newColor);
        }

        private void buttonColorHotPink_Click(object sender, EventArgs e)
        {
            Color newColor = Color.HotPink;
            ChangeButtonColor(newColor);
        }

        private void highlightColorSilver_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Silver;
            ChangeHighlightedColor(newColor);
        }

        private void highlightColorRed_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Red;
            ChangeHighlightedColor(newColor);
        }

        private void highlightColorBisque_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Bisque;
            ChangeHighlightedColor(newColor);
        }

        private void highlightColorPaleGreen_Click(object sender, EventArgs e)
        {
            Color newColor = Color.PaleGreen;
            ChangeHighlightedColor(newColor);
        }

        private void highlightColorCyan_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Cyan;
            ChangeHighlightedColor(newColor);
        }

        private void highlightColorPink_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Pink;
            ChangeHighlightedColor(newColor);
        }

        private void highlightColorTransparent_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Transparent;
            ChangeHighlightedColor(newColor);
        }

        private void highlightColorBurlyWood_Click(object sender, EventArgs e)
        {
            Color newColor = Color.BurlyWood;
            ChangeHighlightedColor(newColor);
        }

        private void highlightColorBeige_Click(object sender, EventArgs e)
        {
            Color newColor = Color.Beige;
            ChangeHighlightedColor(newColor);
        }

        private void highlightColorMintCream_Click(object sender, EventArgs e)
        {
            Color newColor = Color.MintCream;
            ChangeHighlightedColor(newColor);
        }

        private void highlightColorSkyBlue_Click(object sender, EventArgs e)
        {
            Color newColor = Color.SkyBlue;
            ChangeHighlightedColor(newColor);
        }

        private void highlightColorHotPink_Click(object sender, EventArgs e)
        {
            Color newColor = Color.HotPink;
            ChangeHighlightedColor(newColor);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count > 2)
            {
                Application.OpenForms[2].Close();
            }

            frm2 = new Form2();
            frm2.Show();
        }
    }
}
