namespace TVP_Proj1___Open_To_Rent.user_stvari
{
    partial class userPanel
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
            this.dataGridReservations = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewReservation = new System.Windows.Forms.Button();
            this.btnEditReservation = new System.Windows.Forms.Button();
            this.btnDeleteReservation = new System.Windows.Forms.Button();
            this.labelGameName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelStudio = new System.Windows.Forms.Label();
            this.labelReleaseYear = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.btnFilterAll = new System.Windows.Forms.Button();
            this.btnFilterActive = new System.Windows.Forms.Button();
            this.btnFilterFinished = new System.Windows.Forms.Button();
            this.labelReservationStart = new System.Windows.Forms.Label();
            this.labelReservationEnd = new System.Windows.Forms.Label();
            this.labelPreostaliDani = new System.Windows.Forms.Label();
            this.labelDaysLeft = new System.Windows.Forms.Label();
            this.labelReservationStartDate = new System.Windows.Forms.Label();
            this.labelReservationEndDate = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnComboboxFilter = new System.Windows.Forms.Button();
            this.tBoxFilter = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridReservations
            // 
            this.dataGridReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReservations.Location = new System.Drawing.Point(174, 44);
            this.dataGridReservations.Name = "dataGridReservations";
            this.dataGridReservations.Size = new System.Drawing.Size(1062, 431);
            this.dataGridReservations.TabIndex = 0;
            this.dataGridReservations.SelectionChanged += new System.EventHandler(this.dataGridReservations_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vase rezervacije";
            // 
            // btnNewReservation
            // 
            this.btnNewReservation.Location = new System.Drawing.Point(12, 44);
            this.btnNewReservation.Name = "btnNewReservation";
            this.btnNewReservation.Size = new System.Drawing.Size(143, 57);
            this.btnNewReservation.TabIndex = 2;
            this.btnNewReservation.Text = "Dodaj novu rezervaciju";
            this.btnNewReservation.UseVisualStyleBackColor = true;
            this.btnNewReservation.Click += new System.EventHandler(this.btnNewReservation_Click);
            // 
            // btnEditReservation
            // 
            this.btnEditReservation.Location = new System.Drawing.Point(12, 145);
            this.btnEditReservation.Name = "btnEditReservation";
            this.btnEditReservation.Size = new System.Drawing.Size(143, 57);
            this.btnEditReservation.TabIndex = 3;
            this.btnEditReservation.Text = "Izmeni rezervaciju";
            this.btnEditReservation.UseVisualStyleBackColor = true;
            this.btnEditReservation.Click += new System.EventHandler(this.btnEditReservation_Click);
            // 
            // btnDeleteReservation
            // 
            this.btnDeleteReservation.Location = new System.Drawing.Point(12, 244);
            this.btnDeleteReservation.Name = "btnDeleteReservation";
            this.btnDeleteReservation.Size = new System.Drawing.Size(143, 57);
            this.btnDeleteReservation.TabIndex = 4;
            this.btnDeleteReservation.Text = "Izbriši rezervaciju\r\n";
            this.btnDeleteReservation.UseVisualStyleBackColor = true;
            this.btnDeleteReservation.Click += new System.EventHandler(this.btnDeleteReservation_Click);
            // 
            // labelGameName
            // 
            this.labelGameName.AutoSize = true;
            this.labelGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameName.Location = new System.Drawing.Point(203, 504);
            this.labelGameName.Name = "labelGameName";
            this.labelGameName.Size = new System.Drawing.Size(74, 20);
            this.labelGameName.TabIndex = 5;
            this.labelGameName.Text = "Ime igre";
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(204, 524);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(384, 148);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "Opis igre";
            // 
            // labelStudio
            // 
            this.labelStudio.AutoSize = true;
            this.labelStudio.Location = new System.Drawing.Point(594, 524);
            this.labelStudio.Name = "labelStudio";
            this.labelStudio.Size = new System.Drawing.Size(78, 18);
            this.labelStudio.TabIndex = 7;
            this.labelStudio.Text = "Ime studija";
            // 
            // labelReleaseYear
            // 
            this.labelReleaseYear.AutoSize = true;
            this.labelReleaseYear.Location = new System.Drawing.Point(594, 551);
            this.labelReleaseYear.Name = "labelReleaseYear";
            this.labelReleaseYear.Size = new System.Drawing.Size(121, 18);
            this.labelReleaseYear.TabIndex = 8;
            this.labelReleaseYear.Text = "Godina izdavanja";
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(594, 500);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(38, 18);
            this.labelGenre.TabIndex = 9;
            this.labelGenre.Text = "Zanr";
            // 
            // btnFilterAll
            // 
            this.btnFilterAll.Location = new System.Drawing.Point(365, 10);
            this.btnFilterAll.Name = "btnFilterAll";
            this.btnFilterAll.Size = new System.Drawing.Size(117, 28);
            this.btnFilterAll.TabIndex = 10;
            this.btnFilterAll.Text = "Sve rezervacije";
            this.btnFilterAll.UseVisualStyleBackColor = true;
            this.btnFilterAll.Click += new System.EventHandler(this.btnFilterAll_Click);
            // 
            // btnFilterActive
            // 
            this.btnFilterActive.Location = new System.Drawing.Point(488, 10);
            this.btnFilterActive.Name = "btnFilterActive";
            this.btnFilterActive.Size = new System.Drawing.Size(144, 28);
            this.btnFilterActive.TabIndex = 11;
            this.btnFilterActive.Text = "Aktivne rezervacije";
            this.btnFilterActive.UseVisualStyleBackColor = true;
            this.btnFilterActive.Click += new System.EventHandler(this.btnFilterActive_Click);
            // 
            // btnFilterFinished
            // 
            this.btnFilterFinished.Location = new System.Drawing.Point(638, 10);
            this.btnFilterFinished.Name = "btnFilterFinished";
            this.btnFilterFinished.Size = new System.Drawing.Size(152, 28);
            this.btnFilterFinished.TabIndex = 12;
            this.btnFilterFinished.Text = "Zavrsene rezervacije";
            this.btnFilterFinished.UseVisualStyleBackColor = true;
            this.btnFilterFinished.Click += new System.EventHandler(this.btnFilterFinished_Click);
            // 
            // labelReservationStart
            // 
            this.labelReservationStart.AutoSize = true;
            this.labelReservationStart.Location = new System.Drawing.Point(859, 500);
            this.labelReservationStart.Name = "labelReservationStart";
            this.labelReservationStart.Size = new System.Drawing.Size(188, 18);
            this.labelReservationStart.TabIndex = 13;
            this.labelReservationStart.Text = "Datum pocetka rezervacije:";
            // 
            // labelReservationEnd
            // 
            this.labelReservationEnd.AutoSize = true;
            this.labelReservationEnd.Location = new System.Drawing.Point(859, 524);
            this.labelReservationEnd.Name = "labelReservationEnd";
            this.labelReservationEnd.Size = new System.Drawing.Size(167, 18);
            this.labelReservationEnd.TabIndex = 14;
            this.labelReservationEnd.Text = "Datum kraja rezervacije:";
            // 
            // labelPreostaliDani
            // 
            this.labelPreostaliDani.AutoSize = true;
            this.labelPreostaliDani.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPreostaliDani.Location = new System.Drawing.Point(859, 551);
            this.labelPreostaliDani.Name = "labelPreostaliDani";
            this.labelPreostaliDani.Size = new System.Drawing.Size(112, 18);
            this.labelPreostaliDani.TabIndex = 15;
            this.labelPreostaliDani.Text = "Preostalo dana:";
            // 
            // labelDaysLeft
            // 
            this.labelDaysLeft.AutoSize = true;
            this.labelDaysLeft.Location = new System.Drawing.Point(1065, 551);
            this.labelDaysLeft.Name = "labelDaysLeft";
            this.labelDaysLeft.Size = new System.Drawing.Size(38, 18);
            this.labelDaysLeft.TabIndex = 16;
            this.labelDaysLeft.Text = "Dani";
            // 
            // labelReservationStartDate
            // 
            this.labelReservationStartDate.AutoSize = true;
            this.labelReservationStartDate.Location = new System.Drawing.Point(1065, 502);
            this.labelReservationStartDate.Name = "labelReservationStartDate";
            this.labelReservationStartDate.Size = new System.Drawing.Size(52, 18);
            this.labelReservationStartDate.TabIndex = 17;
            this.labelReservationStartDate.Text = "Datum";
            // 
            // labelReservationEndDate
            // 
            this.labelReservationEndDate.AutoSize = true;
            this.labelReservationEndDate.Location = new System.Drawing.Point(1065, 524);
            this.labelReservationEndDate.Name = "labelReservationEndDate";
            this.labelReservationEndDate.Size = new System.Drawing.Size(52, 18);
            this.labelReservationEndDate.TabIndex = 18;
            this.labelReservationEndDate.Text = "Datum";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 618);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(74, 51);
            this.btnLogout.TabIndex = 19;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ime igre",
            "Zanr",
            "Platforma",
            "Datum Pocetka Rezervacije",
            "Datum Vracanja Rezervacije"});
            this.comboBox1.Location = new System.Drawing.Point(796, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 26);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnComboboxFilter
            // 
            this.btnComboboxFilter.Location = new System.Drawing.Point(1151, 10);
            this.btnComboboxFilter.Name = "btnComboboxFilter";
            this.btnComboboxFilter.Size = new System.Drawing.Size(101, 28);
            this.btnComboboxFilter.TabIndex = 21;
            this.btnComboboxFilter.Text = "Primeni filter";
            this.btnComboboxFilter.UseVisualStyleBackColor = true;
            this.btnComboboxFilter.Click += new System.EventHandler(this.btnComboboxFilter_Click);
            // 
            // tBoxFilter
            // 
            this.tBoxFilter.Location = new System.Drawing.Point(977, 12);
            this.tBoxFilter.Name = "tBoxFilter";
            this.tBoxFilter.Size = new System.Drawing.Size(168, 24);
            this.tBoxFilter.TabIndex = 22;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(978, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(167, 24);
            this.dateTimePicker1.TabIndex = 23;
            this.dateTimePicker1.Visible = false;
            // 
            // userPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tBoxFilter);
            this.Controls.Add(this.btnComboboxFilter);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.labelReservationEndDate);
            this.Controls.Add(this.labelReservationStartDate);
            this.Controls.Add(this.labelDaysLeft);
            this.Controls.Add(this.labelPreostaliDani);
            this.Controls.Add(this.labelReservationEnd);
            this.Controls.Add(this.labelReservationStart);
            this.Controls.Add(this.btnFilterFinished);
            this.Controls.Add(this.btnFilterActive);
            this.Controls.Add(this.btnFilterAll);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.labelReleaseYear);
            this.Controls.Add(this.labelStudio);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelGameName);
            this.Controls.Add(this.btnDeleteReservation);
            this.Controls.Add(this.btnEditReservation);
            this.Controls.Add(this.btnNewReservation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridReservations);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "userPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open To Rent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.userPanel_FormClosing);
            this.Load += new System.EventHandler(this.userPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridReservations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewReservation;
        private System.Windows.Forms.Button btnEditReservation;
        private System.Windows.Forms.Button btnDeleteReservation;
        private System.Windows.Forms.Label labelGameName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelStudio;
        private System.Windows.Forms.Label labelReleaseYear;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Button btnFilterAll;
        private System.Windows.Forms.Button btnFilterActive;
        private System.Windows.Forms.Button btnFilterFinished;
        private System.Windows.Forms.Label labelReservationStart;
        private System.Windows.Forms.Label labelReservationEnd;
        private System.Windows.Forms.Label labelPreostaliDani;
        private System.Windows.Forms.Label labelDaysLeft;
        private System.Windows.Forms.Label labelReservationStartDate;
        private System.Windows.Forms.Label labelReservationEndDate;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnComboboxFilter;
        private System.Windows.Forms.TextBox tBoxFilter;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}