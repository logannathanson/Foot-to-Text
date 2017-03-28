namespace WindowsFormsApplication1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonWidthPlus = new System.Windows.Forms.Button();
            this.buttonWidthMinus = new System.Windows.Forms.Button();
            this.textSizePlus = new System.Windows.Forms.Button();
            this.textSizeMinus = new System.Windows.Forms.Button();
            this.buttonHeightMinus = new System.Windows.Forms.Button();
            this.buttonHeightPlus = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 68);
            this.label2.TabIndex = 1;
            this.label2.Text = "Button Width:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 68);
            this.label3.TabIndex = 2;
            this.label3.Text = "Text Size:";
            // 
            // buttonWidthPlus
            // 
            this.buttonWidthPlus.BackColor = System.Drawing.Color.Bisque;
            this.buttonWidthPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWidthPlus.Location = new System.Drawing.Point(22, 137);
            this.buttonWidthPlus.Name = "buttonWidthPlus";
            this.buttonWidthPlus.Size = new System.Drawing.Size(174, 62);
            this.buttonWidthPlus.TabIndex = 3;
            this.buttonWidthPlus.Text = "+";
            this.buttonWidthPlus.UseVisualStyleBackColor = false;
            this.buttonWidthPlus.Click += new System.EventHandler(this.buttonWidthPlus_Click);
            // 
            // buttonWidthMinus
            // 
            this.buttonWidthMinus.BackColor = System.Drawing.Color.Bisque;
            this.buttonWidthMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWidthMinus.Location = new System.Drawing.Point(224, 137);
            this.buttonWidthMinus.Name = "buttonWidthMinus";
            this.buttonWidthMinus.Size = new System.Drawing.Size(159, 62);
            this.buttonWidthMinus.TabIndex = 4;
            this.buttonWidthMinus.Text = "-";
            this.buttonWidthMinus.UseVisualStyleBackColor = false;
            this.buttonWidthMinus.Click += new System.EventHandler(this.buttonWidthMinus_Click);
            // 
            // textSizePlus
            // 
            this.textSizePlus.BackColor = System.Drawing.Color.Bisque;
            this.textSizePlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSizePlus.Location = new System.Drawing.Point(22, 384);
            this.textSizePlus.Name = "textSizePlus";
            this.textSizePlus.Size = new System.Drawing.Size(174, 74);
            this.textSizePlus.TabIndex = 5;
            this.textSizePlus.Text = "+";
            this.textSizePlus.UseVisualStyleBackColor = false;
            this.textSizePlus.Click += new System.EventHandler(this.textSizePlus_Click);
            // 
            // textSizeMinus
            // 
            this.textSizeMinus.BackColor = System.Drawing.Color.Bisque;
            this.textSizeMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSizeMinus.Location = new System.Drawing.Point(224, 384);
            this.textSizeMinus.Name = "textSizeMinus";
            this.textSizeMinus.Size = new System.Drawing.Size(170, 74);
            this.textSizeMinus.TabIndex = 6;
            this.textSizeMinus.Text = "-";
            this.textSizeMinus.UseVisualStyleBackColor = false;
            this.textSizeMinus.Click += new System.EventHandler(this.textSizeMinus_Click);
            // 
            // buttonHeightMinus
            // 
            this.buttonHeightMinus.BackColor = System.Drawing.Color.Bisque;
            this.buttonHeightMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHeightMinus.Location = new System.Drawing.Point(224, 264);
            this.buttonHeightMinus.Name = "buttonHeightMinus";
            this.buttonHeightMinus.Size = new System.Drawing.Size(159, 67);
            this.buttonHeightMinus.TabIndex = 9;
            this.buttonHeightMinus.Text = "-";
            this.buttonHeightMinus.UseVisualStyleBackColor = false;
            this.buttonHeightMinus.Click += new System.EventHandler(this.buttonHeightMinus_Click);
            // 
            // buttonHeightPlus
            // 
            this.buttonHeightPlus.BackColor = System.Drawing.Color.Bisque;
            this.buttonHeightPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHeightPlus.Location = new System.Drawing.Point(22, 264);
            this.buttonHeightPlus.Name = "buttonHeightPlus";
            this.buttonHeightPlus.Size = new System.Drawing.Size(174, 67);
            this.buttonHeightPlus.TabIndex = 8;
            this.buttonHeightPlus.Text = "+";
            this.buttonHeightPlus.UseVisualStyleBackColor = false;
            this.buttonHeightPlus.Click += new System.EventHandler(this.buttonHeightPlus_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(319, 68);
            this.label4.TabIndex = 7;
            this.label4.Text = "Button Height:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Bisque;
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(22, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(372, 97);
            this.button1.TabIndex = 10;
            this.button1.Text = "Close Settings";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 582);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonHeightMinus);
            this.Controls.Add(this.buttonHeightPlus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textSizeMinus);
            this.Controls.Add(this.textSizePlus);
            this.Controls.Add(this.buttonWidthMinus);
            this.Controls.Add(this.buttonWidthPlus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonWidthPlus;
        private System.Windows.Forms.Button buttonWidthMinus;
        private System.Windows.Forms.Button textSizePlus;
        private System.Windows.Forms.Button textSizeMinus;
        private System.Windows.Forms.Button buttonHeightMinus;
        private System.Windows.Forms.Button buttonHeightPlus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}