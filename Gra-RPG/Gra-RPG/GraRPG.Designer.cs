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
            this.label5 = new System.Windows.Forms.Label();
            this.cboBronie = new System.Windows.Forms.ComboBox();
            this.cboMikstury = new System.Windows.Forms.ComboBox();
            this.btnUzyjBroni = new System.Windows.Forms.Button();
            this.btnUzyjMikstury = new System.Windows.Forms.Button();
            this.btnPolnoc = new System.Windows.Forms.Button();
            this.btnWschod = new System.Windows.Forms.Button();
            this.btnPoludnie = new System.Windows.Forms.Button();
            this.btnZachod = new System.Windows.Forms.Button();
            this.rbtWiadomosci = new System.Windows.Forms.RichTextBox();
            this.rbtLokalizacja = new System.Windows.Forms.RichTextBox();
            this.dgvInwentarz = new System.Windows.Forms.DataGridView();
            this.dgvZadania = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInwentarz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZadania)).BeginInit();
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 531);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Wybierz akcję:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cboBronie
            // 
            this.cboBronie.FormattingEnabled = true;
            this.cboBronie.Location = new System.Drawing.Point(369, 559);
            this.cboBronie.Name = "cboBronie";
            this.cboBronie.Size = new System.Drawing.Size(121, 21);
            this.cboBronie.TabIndex = 9;
            // 
            // cboMikstury
            // 
            this.cboMikstury.FormattingEnabled = true;
            this.cboMikstury.Location = new System.Drawing.Point(369, 593);
            this.cboMikstury.Name = "cboMikstury";
            this.cboMikstury.Size = new System.Drawing.Size(121, 21);
            this.cboMikstury.TabIndex = 10;
            // 
            // btnUzyjBroni
            // 
            this.btnUzyjBroni.Location = new System.Drawing.Point(620, 559);
            this.btnUzyjBroni.Name = "btnUzyjBroni";
            this.btnUzyjBroni.Size = new System.Drawing.Size(75, 23);
            this.btnUzyjBroni.TabIndex = 11;
            this.btnUzyjBroni.Text = "Użyj";
            this.btnUzyjBroni.UseVisualStyleBackColor = true;
            // 
            // btnUzyjMikstury
            // 
            this.btnUzyjMikstury.Location = new System.Drawing.Point(620, 593);
            this.btnUzyjMikstury.Name = "btnUzyjMikstury";
            this.btnUzyjMikstury.Size = new System.Drawing.Size(75, 23);
            this.btnUzyjMikstury.TabIndex = 12;
            this.btnUzyjMikstury.Text = "Użyj";
            this.btnUzyjMikstury.UseVisualStyleBackColor = true;
            // 
            // btnPolnoc
            // 
            this.btnPolnoc.Location = new System.Drawing.Point(493, 433);
            this.btnPolnoc.Name = "btnPolnoc";
            this.btnPolnoc.Size = new System.Drawing.Size(75, 23);
            this.btnPolnoc.TabIndex = 13;
            this.btnPolnoc.Text = "Północ";
            this.btnPolnoc.UseVisualStyleBackColor = true;
            // 
            // btnWschod
            // 
            this.btnWschod.Location = new System.Drawing.Point(573, 457);
            this.btnWschod.Name = "btnWschod";
            this.btnWschod.Size = new System.Drawing.Size(75, 23);
            this.btnWschod.TabIndex = 14;
            this.btnWschod.Text = "Wschód";
            this.btnWschod.UseVisualStyleBackColor = true;
            // 
            // btnPoludnie
            // 
            this.btnPoludnie.Location = new System.Drawing.Point(493, 487);
            this.btnPoludnie.Name = "btnPoludnie";
            this.btnPoludnie.Size = new System.Drawing.Size(75, 23);
            this.btnPoludnie.TabIndex = 15;
            this.btnPoludnie.Text = "Południe";
            this.btnPoludnie.UseVisualStyleBackColor = true;
            // 
            // btnZachod
            // 
            this.btnZachod.Location = new System.Drawing.Point(412, 457);
            this.btnZachod.Name = "btnZachod";
            this.btnZachod.Size = new System.Drawing.Size(75, 23);
            this.btnZachod.TabIndex = 16;
            this.btnZachod.Text = "Zachód";
            this.btnZachod.UseVisualStyleBackColor = true;
            // 
            // rbtWiadomosci
            // 
            this.rbtWiadomosci.Location = new System.Drawing.Point(347, 130);
            this.rbtWiadomosci.Name = "rbtWiadomosci";
            this.rbtWiadomosci.ReadOnly = true;
            this.rbtWiadomosci.Size = new System.Drawing.Size(360, 286);
            this.rbtWiadomosci.TabIndex = 17;
            this.rbtWiadomosci.Text = "";
            // 
            // rbtLokalizacja
            // 
            this.rbtLokalizacja.Location = new System.Drawing.Point(347, 19);
            this.rbtLokalizacja.Name = "rbtLokalizacja";
            this.rbtLokalizacja.ReadOnly = true;
            this.rbtLokalizacja.Size = new System.Drawing.Size(360, 105);
            this.rbtLokalizacja.TabIndex = 18;
            this.rbtLokalizacja.Text = "";
            // 
            // dgvInwentarz
            // 
            this.dgvInwentarz.AllowUserToAddRows = false;
            this.dgvInwentarz.AllowUserToDeleteRows = false;
            this.dgvInwentarz.AllowUserToResizeRows = false;
            this.dgvInwentarz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInwentarz.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInwentarz.Enabled = false;
            this.dgvInwentarz.Location = new System.Drawing.Point(16, 130);
            this.dgvInwentarz.MultiSelect = false;
            this.dgvInwentarz.Name = "dgvInwentarz";
            this.dgvInwentarz.ReadOnly = true;
            this.dgvInwentarz.RowHeadersVisible = false;
            this.dgvInwentarz.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvInwentarz.Size = new System.Drawing.Size(312, 309);
            this.dgvInwentarz.TabIndex = 19;
            // 
            // dgvZadania
            // 
            this.dgvZadania.AllowUserToAddRows = false;
            this.dgvZadania.AllowUserToDeleteRows = false;
            this.dgvZadania.AllowUserToResizeRows = false;
            this.dgvZadania.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZadania.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvZadania.Enabled = false;
            this.dgvZadania.Location = new System.Drawing.Point(16, 446);
            this.dgvZadania.MultiSelect = false;
            this.dgvZadania.Name = "dgvZadania";
            this.dgvZadania.ReadOnly = true;
            this.dgvZadania.RowHeadersVisible = false;
            this.dgvZadania.Size = new System.Drawing.Size(312, 189);
            this.dgvZadania.TabIndex = 20;
            // 
            // GraRPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 651);
            this.Controls.Add(this.dgvZadania);
            this.Controls.Add(this.dgvInwentarz);
            this.Controls.Add(this.rbtLokalizacja);
            this.Controls.Add(this.rbtWiadomosci);
            this.Controls.Add(this.btnZachod);
            this.Controls.Add(this.btnPoludnie);
            this.Controls.Add(this.btnWschod);
            this.Controls.Add(this.btnPolnoc);
            this.Controls.Add(this.btnUzyjMikstury);
            this.Controls.Add(this.btnUzyjBroni);
            this.Controls.Add(this.cboMikstury);
            this.Controls.Add(this.cboBronie);
            this.Controls.Add(this.label5);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvInwentarz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZadania)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBronie;
        private System.Windows.Forms.ComboBox cboMikstury;
        private System.Windows.Forms.Button btnUzyjBroni;
        private System.Windows.Forms.Button btnUzyjMikstury;
        private System.Windows.Forms.Button btnPolnoc;
        private System.Windows.Forms.Button btnWschod;
        private System.Windows.Forms.Button btnPoludnie;
        private System.Windows.Forms.Button btnZachod;
        private System.Windows.Forms.RichTextBox rbtWiadomosci;
        private System.Windows.Forms.RichTextBox rbtLokalizacja;
        private System.Windows.Forms.DataGridView dgvInwentarz;
        private System.Windows.Forms.DataGridView dgvZadania;
    }
}

