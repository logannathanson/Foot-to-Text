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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 68);
            this.label2.TabIndex = 1;
            this.label2.Text = "Button Width:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 68);
            this.label3.TabIndex = 2;
            this.label3.Text = "Text Size:";
            // 
            // buttonWidthPlus
            // 
            this.buttonWidthPlus.Location = new System.Drawing.Point(224, 114);
            this.buttonWidthPlus.Name = "buttonWidthPlus";
            this.buttonWidthPlus.Size = new System.Drawing.Size(54, 37);
            this.buttonWidthPlus.TabIndex = 3;
            this.buttonWidthPlus.Text = "+";
            this.buttonWidthPlus.UseVisualStyleBackColor = true;
            this.buttonWidthPlus.Click += new System.EventHandler(this.buttonWidthPlus_Click);
            // 
            // buttonWidthMinus
            // 
            this.buttonWidthMinus.Location = new System.Drawing.Point(299, 114);
            this.buttonWidthMinus.Name = "buttonWidthMinus";
            this.buttonWidthMinus.Size = new System.Drawing.Size(54, 37);
            this.buttonWidthMinus.TabIndex = 4;
            this.buttonWidthMinus.Text = "-";
            this.buttonWidthMinus.UseVisualStyleBackColor = true;
            this.buttonWidthMinus.Click += new System.EventHandler(this.buttonWidthMinus_Click);
            // 
            // textSizePlus
            // 
            this.textSizePlus.Location = new System.Drawing.Point(224, 203);
            this.textSizePlus.Name = "textSizePlus";
            this.textSizePlus.Size = new System.Drawing.Size(54, 37);
            this.textSizePlus.TabIndex = 5;
            this.textSizePlus.Text = "+";
            this.textSizePlus.UseVisualStyleBackColor = true;
            this.textSizePlus.Click += new System.EventHandler(this.textSizePlus_Click);
            // 
            // textSizeMinus
            // 
            this.textSizeMinus.Location = new System.Drawing.Point(299, 205);
            this.textSizeMinus.Name = "textSizeMinus";
            this.textSizeMinus.Size = new System.Drawing.Size(54, 37);
            this.textSizeMinus.TabIndex = 6;
            this.textSizeMinus.Text = "-";
            this.textSizeMinus.UseVisualStyleBackColor = true;
            this.textSizeMinus.Click += new System.EventHandler(this.textSizeMinus_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 447);
            this.Controls.Add(this.textSizeMinus);
            this.Controls.Add(this.textSizePlus);
            this.Controls.Add(this.buttonWidthMinus);
            this.Controls.Add(this.buttonWidthPlus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
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
    }
}