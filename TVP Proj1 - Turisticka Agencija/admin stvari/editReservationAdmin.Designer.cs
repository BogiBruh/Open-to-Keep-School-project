namespace TVP_Proj1___Open_To_Rent.admin_stvari
{
    partial class editReservationAdmin
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.btnPrimeniFilter = new System.Windows.Forms.Button();
            this.tBoxFilter = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelGameName = new System.Windows.Forms.Label();
            this.dataGridRezervacije = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnVrati = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRezervacije)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(757, 530);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 18);
            this.label6.TabIndex = 67;
            this.label6.Text = "Datum do kada izdajete:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(553, 530);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 18);
            this.label5.TabIndex = 66;
            this.label5.Text = "Datum od kada izdajete:";
            // 
            // dateEnd
            // 
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEnd.Location = new System.Drawing.Point(760, 551);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(188, 24);
            this.dateEnd.TabIndex = 65;
            // 
            // dateStart
            // 
            this.dateStart.Enabled = false;
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStart.Location = new System.Drawing.Point(556, 551);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(187, 24);
            this.dateStart.TabIndex = 64;
            // 
            // btnPrimeniFilter
            // 
            this.btnPrimeniFilter.Location = new System.Drawing.Point(963, 490);
            this.btnPrimeniFilter.Name = "btnPrimeniFilter";
            this.btnPrimeniFilter.Size = new System.Drawing.Size(118, 26);
            this.btnPrimeniFilter.TabIndex = 63;
            this.btnPrimeniFilter.Text = "Primeni filter";
            this.btnPrimeniFilter.UseVisualStyleBackColor = true;
            this.btnPrimeniFilter.Click += new System.EventHandler(this.btnPrimeniFilter_Click);
            // 
            // tBoxFilter
            // 
            this.tBoxFilter.Location = new System.Drawing.Point(760, 490);
            this.tBoxFilter.Name = "tBoxFilter";
            this.tBoxFilter.Size = new System.Drawing.Size(188, 24);
            this.tBoxFilter.TabIndex = 62;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ID Korisnika",
            "ID Igre",
            "Cena",
            "Status"});
            this.comboBox1.Location = new System.Drawing.Point(578, 490);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(165, 26);
            this.comboBox1.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(412, 493);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 60;
            this.label2.Text = "Filteruj po:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1096, 667);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 56);
            this.btnCancel.TabIndex = 58;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(13, 501);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(384, 225);
            this.labelDescription.TabIndex = 57;
            this.labelDescription.Text = "Opis igre";
            // 
            // labelGameName
            // 
            this.labelGameName.AutoSize = true;
            this.labelGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameName.Location = new System.Drawing.Point(12, 481);
            this.labelGameName.Name = "labelGameName";
            this.labelGameName.Size = new System.Drawing.Size(74, 20);
            this.labelGameName.TabIndex = 56;
            this.labelGameName.Text = "Ime igre";
            // 
            // dataGridRezervacije
            // 
            this.dataGridRezervacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRezervacije.Location = new System.Drawing.Point(12, 38);
            this.dataGridRezervacije.Name = "dataGridRezervacije";
            this.dataGridRezervacije.Size = new System.Drawing.Size(1176, 431);
            this.dataGridRezervacije.TabIndex = 55;
            this.dataGridRezervacije.SelectionChanged += new System.EventHandler(this.dataGridRezervacije_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 24);
            this.label1.TabIndex = 69;
            this.label1.Text = "Uredi Rezervaciju";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(989, 667);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 56);
            this.btnOk.TabIndex = 70;
            this.btnOk.Text = "Primeni promene";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnVrati
            // 
            this.btnVrati.Location = new System.Drawing.Point(882, 667);
            this.btnVrati.Name = "btnVrati";
            this.btnVrati.Size = new System.Drawing.Size(92, 56);
            this.btnVrati.TabIndex = 71;
            this.btnVrati.Text = "Vrati rezervaciju";
            this.btnVrati.UseVisualStyleBackColor = true;
            this.btnVrati.Click += new System.EventHandler(this.btnVrati_Click);
            // 
            // editReservationAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 736);
            this.Controls.Add(this.btnVrati);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.btnPrimeniFilter);
            this.Controls.Add(this.tBoxFilter);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelGameName);
            this.Controls.Add(this.dataGridRezervacije);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "editReservationAdmin";
            this.Text = "Uredi rezervaciju - Admin Panel";
            this.Load += new System.EventHandler(this.editReservationAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRezervacije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Button btnPrimeniFilter;
        private System.Windows.Forms.TextBox tBoxFilter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelGameName;
        private System.Windows.Forms.DataGridView dataGridRezervacije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnVrati;
    }
}