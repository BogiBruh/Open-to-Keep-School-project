namespace TVP_Proj1___Turisticka_Agencija
{
    partial class adminPanel
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnPrvaOpcija = new System.Windows.Forms.Button();
            this.btnDrugaOpcija = new System.Windows.Forms.Button();
            this.btnIzleti = new System.Windows.Forms.Button();
            this.btnKorisnici = new System.Windows.Forms.Button();
            this.btnRezervacije = new System.Windows.Forms.Button();
            this.btnTrecaOpcija = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(209, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1043, 441);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnPrvaOpcija
            // 
            this.btnPrvaOpcija.Location = new System.Drawing.Point(209, 521);
            this.btnPrvaOpcija.Name = "btnPrvaOpcija";
            this.btnPrvaOpcija.Size = new System.Drawing.Size(146, 50);
            this.btnPrvaOpcija.TabIndex = 2;
            this.btnPrvaOpcija.Text = "prva opcija";
            this.btnPrvaOpcija.UseVisualStyleBackColor = true;
            this.btnPrvaOpcija.Click += new System.EventHandler(this.btnPrvaOpcija_Click);
            // 
            // btnDrugaOpcija
            // 
            this.btnDrugaOpcija.Location = new System.Drawing.Point(388, 520);
            this.btnDrugaOpcija.Name = "btnDrugaOpcija";
            this.btnDrugaOpcija.Size = new System.Drawing.Size(154, 51);
            this.btnDrugaOpcija.TabIndex = 3;
            this.btnDrugaOpcija.Text = "druga opcija";
            this.btnDrugaOpcija.UseVisualStyleBackColor = true;
            this.btnDrugaOpcija.Click += new System.EventHandler(this.btnDrugaOpcija_Click);
            // 
            // btnIzleti
            // 
            this.btnIzleti.Location = new System.Drawing.Point(13, 52);
            this.btnIzleti.Name = "btnIzleti";
            this.btnIzleti.Size = new System.Drawing.Size(147, 59);
            this.btnIzleti.TabIndex = 4;
            this.btnIzleti.Text = "Igre";
            this.btnIzleti.UseVisualStyleBackColor = true;
            this.btnIzleti.Click += new System.EventHandler(this.btnIzleti_Click);
            // 
            // btnKorisnici
            // 
            this.btnKorisnici.Location = new System.Drawing.Point(13, 168);
            this.btnKorisnici.Name = "btnKorisnici";
            this.btnKorisnici.Size = new System.Drawing.Size(147, 59);
            this.btnKorisnici.TabIndex = 5;
            this.btnKorisnici.Text = "Korisnici";
            this.btnKorisnici.UseVisualStyleBackColor = true;
            this.btnKorisnici.Click += new System.EventHandler(this.btnKorisnici_Click);
            // 
            // btnRezervacije
            // 
            this.btnRezervacije.Location = new System.Drawing.Point(13, 294);
            this.btnRezervacije.Name = "btnRezervacije";
            this.btnRezervacije.Size = new System.Drawing.Size(147, 59);
            this.btnRezervacije.TabIndex = 6;
            this.btnRezervacije.Text = "Rezervacije";
            this.btnRezervacije.UseVisualStyleBackColor = true;
            this.btnRezervacije.Click += new System.EventHandler(this.btnRezervacije_Click);
            // 
            // btnTrecaOpcija
            // 
            this.btnTrecaOpcija.Location = new System.Drawing.Point(571, 520);
            this.btnTrecaOpcija.Name = "btnTrecaOpcija";
            this.btnTrecaOpcija.Size = new System.Drawing.Size(154, 51);
            this.btnTrecaOpcija.TabIndex = 7;
            this.btnTrecaOpcija.Text = "treca opcija";
            this.btnTrecaOpcija.UseVisualStyleBackColor = true;
            this.btnTrecaOpcija.Click += new System.EventHandler(this.btnTrecaOpcija_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(13, 623);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 46);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // adminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnTrecaOpcija);
            this.Controls.Add(this.btnRezervacije);
            this.Controls.Add(this.btnKorisnici);
            this.Controls.Add(this.btnIzleti);
            this.Controls.Add(this.btnDrugaOpcija);
            this.Controls.Add(this.btnPrvaOpcija);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "adminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open to Rent - Admin panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.adminPanel_FormClosing);
            this.Load += new System.EventHandler(this.adminPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnPrvaOpcija;
        private System.Windows.Forms.Button btnDrugaOpcija;
        private System.Windows.Forms.Button btnIzleti;
        private System.Windows.Forms.Button btnKorisnici;
        private System.Windows.Forms.Button btnRezervacije;
        private System.Windows.Forms.Button btnTrecaOpcija;
        private System.Windows.Forms.Button btnLogout;
    }
}