namespace Gra_RPG
{
    partial class GraRPG
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
            this.label4 = new System.Windows.Forms.Label();
            this.lblPunktyZdrowia = new System.Windows.Forms.Label();
            this.lblZłoto = new System.Windows.Forms.Label();
            this.lblDoświadczenie = new System.Windows.Forms.Label();
            this.lblPoziom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Punkty zdrowia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Złoto";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Doświadczenie";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Poziom";
            // 
            // lblPunktyZdrowia
            // 
            this.lblPunktyZdrowia.AutoSize = true;
            this.lblPunktyZdrowia.Location = new System.Drawing.Point(110, 19);
            this.lblPunktyZdrowia.Name = "lblPunktyZdrowia";
            this.lblPunktyZdrowia.Size = new System.Drawing.Size(35, 13);
            this.lblPunktyZdrowia.TabIndex = 4;
            this.lblPunktyZdrowia.Text = "label5";
            // 
            // lblZłoto
            // 
            this.lblZłoto.AutoSize = true;
            this.lblZłoto.Location = new System.Drawing.Point(110, 45);
            this.lblZłoto.Name = "lblZłoto";
            this.lblZłoto.Size = new System.Drawing.Size(35, 13);
            this.lblZłoto.TabIndex = 5;
            this.lblZłoto.Text = "label6";
            this.lblZłoto.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblDoświadczenie
            // 
            this.lblDoświadczenie.AutoSize = true;
            this.lblDoświadczenie.Location = new System.Drawing.Point(110, 73);
            this.lblDoświadczenie.Name = "lblDoświadczenie";
            this.lblDoświadczenie.Size = new System.Drawing.Size(35, 13);
            this.lblDoświadczenie.TabIndex = 6;
            this.lblDoświadczenie.Text = "label7";
            // 
            // lblPoziom
            // 
            this.lblPoziom.AutoSize = true;
            this.lblPoziom.Location = new System.Drawing.Point(110, 99);
            this.lblPoziom.Name = "lblPoziom";
            this.lblPoziom.Size = new System.Drawing.Size(35, 13);
            this.lblPoziom.TabIndex = 7;
            this.lblPoziom.Text = "label8";
            // 
            // GraRPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 261);
            this.Controls.Add(this.lblPoziom);
            this.Controls.Add(this.lblDoświadczenie);
            this.Controls.Add(this.lblZłoto);
            this.Controls.Add(this.lblPunktyZdrowia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GraRPG";
            this.Text = "Gra RPG";
            this.Load += new System.EventHandler(this.GraRPG_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPunktyZdrowia;
        private System.Windows.Forms.Label lblZłoto;
        private System.Windows.Forms.Label lblDoświadczenie;
        private System.Windows.Forms.Label lblPoziom;
    }
}

