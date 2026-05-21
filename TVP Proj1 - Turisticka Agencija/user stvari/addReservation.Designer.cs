namespace TVP_Proj1___Open_To_Rent.user_stvari
{
    partial class addReservation
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
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelGameName = new System.Windows.Forms.Label();
            this.dataGridIgre = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tBoxFilter = new System.Windows.Forms.TextBox();
            this.btnPrimeniFilter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCena = new System.Windows.Forms.Label();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIgre)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dodaj rezervaciju";
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(13, 499);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(384, 225);
            this.labelDescription.TabIndex = 21;
            this.labelDescription.Text = "Opis igre";
            // 
            // labelGameName
            // 
            this.labelGameName.AutoSize = true;
            this.labelGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameName.Location = new System.Drawing.Point(12, 479);
            this.labelGameName.Name = "labelGameName";
            this.labelGameName.Size = new System.Drawing.Size(74, 20);
            this.labelGameName.TabIndex = 20;
            this.labelGameName.Text = "Ime igre";
            // 
            // dataGridIgre
            // 
            this.dataGridIgre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIgre.Location = new System.Drawing.Point(12, 36);
            this.dataGridIgre.Name = "dataGridIgre";
            this.dataGridIgre.Size = new System.Drawing.Size(1176, 431);
            this.dataGridIgre.TabIndex = 19;
            this.dataGridIgre.SelectionChanged += new System.EventHandler(this.dataGridIgre_SelectionChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1096, 665);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 56);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(998, 665);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 56);
            this.btnOk.TabIndex = 23;
            this.btnOk.Text = "Rezerviši";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(412, 491);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Filteruj po:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ime",
            "Ime studija",
            "Zanr",
            "Godina izlaska",
            "Platforma"});
            this.comboBox1.Location = new System.Drawing.Point(578, 488);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(165, 26);
            this.comboBox1.TabIndex = 25;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // tBoxFilter
            // 
            this.tBoxFilter.Location = new System.Drawing.Point(760, 488);
            this.tBoxFilter.Name = "tBoxFilter";
            this.tBoxFilter.Size = new System.Drawing.Size(188, 24);
            this.tBoxFilter.TabIndex = 26;
            // 
            // btnPrimeniFilter
            // 
            this.btnPrimeniFilter.Location = new System.Drawing.Point(963, 488);
            this.btnPrimeniFilter.Name = "btnPrimeniFilter";
            this.btnPrimeniFilter.Size = new System.Drawing.Size(118, 26);
            this.btnPrimeniFilter.TabIndex = 27;
            this.btnPrimeniFilter.Text = "Primeni filter";
            this.btnPrimeniFilter.UseVisualStyleBackColor = true;
            this.btnPrimeniFilter.Click += new System.EventHandler(this.btnPrimeniFilter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(412, 576);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 18);
            this.label3.TabIndex = 28;
            this.label3.Text = "Cena iznajmljivanja:";
            // 
            // labelCena
            // 
            this.labelCena.AutoSize = true;
            this.labelCena.Location = new System.Drawing.Point(575, 576);
            this.labelCena.Name = "labelCena";
            this.labelCena.Size = new System.Drawing.Size(40, 18);
            this.labelCena.TabIndex = 29;
            this.labelCena.Text = "cena";
            // 
            // dateStart
            // 
            this.dateStart.Enabled = false;
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStart.Location = new System.Drawing.Point(557, 536);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(187, 24);
            this.dateStart.TabIndex = 32;
            // 
            // dateEnd
            // 
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEnd.Location = new System.Drawing.Point(761, 536);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(188, 24);
            this.dateEnd.TabIndex = 33;
            this.dateEnd.ValueChanged += new System.EventHandler(this.dateEnd_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(554, 515);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 18);
            this.label5.TabIndex = 34;
            this.label5.Text = "Datum od kada izdajete:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(758, 515);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "Datum do kada izdajete:";
            // 
            // addReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 733);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.labelCena);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrimeniFilter);
            this.Controls.Add(this.tBoxFilter);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelGameName);
            this.Controls.Add(this.dataGridIgre);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "addReservation";
            this.Text = "Dodaj rezervaciju";
            this.Load += new System.EventHandler(this.addReservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIgre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelGameName;
        private System.Windows.Forms.DataGridView dataGridIgre;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox tBoxFilter;
        private System.Windows.Forms.Button btnPrimeniFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCena;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}