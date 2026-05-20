using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVP_Proj1___Open_To_Rent.klase;
using TVP_Proj1___Turisticka_Agencija;

namespace TVP_Proj1___Open_To_Rent.user_stvari
{
    public partial class userPanel : Form
    {
        public BindingList<rezervacija> reservationList = new BindingList<rezervacija>();
        public BindingList<igra> gameList = new BindingList<igra>();
        public int idUsera;

        public userPanel()
        {
            InitializeComponent();
        }

        public userPanel(int _idUsera)
        {
            InitializeComponent();
            idUsera = _idUsera;
        }

        private void userPanel_Load(object sender, EventArgs e)
        {
            rezervacija tmpObjekatZaCitanjeRezervacija = new rezervacija();
            int citanjeRezervacija = tmpObjekatZaCitanjeRezervacija.readRezervacije(reservationList);
            if(citanjeRezervacija == -1)
            {
                MessageBox.Show("Nesto nije bilo uredu kod citanja rezervacija.");
                this.Close();
            }

            igra tmpObjekatZaCitanjeIgara = new igra();
            int citanjeIgara = tmpObjekatZaCitanjeIgara.readGames(gameList);
            if(citanjeIgara == -1)
            {
                MessageBox.Show("Nesto nije bilo uredu kod citanja igara.");
                this.Close();
            }

            //Podesavanje datagridviewa
            dataGridReservations.DataSource = reservationList;
            dataGridReservations.AutoGenerateColumns = true;
            dataGridReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridReservations.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridReservations.MultiSelect = false;
            dataGridReservations.AllowUserToAddRows = false;
            dataGridReservations.ColumnHeadersVisible = true;
            dataGridReservations.RowHeadersVisible = false;
            dataGridReservations.ReadOnly = true;
            //dataGridReservations.SelectedRows[0].Selected = true;
            //dataGridReservations.Rows[0].Visible = false;
        }

        private void userPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            rezervacija rezervacijaZaDodavanje = new rezervacija();
            DateTime datPocetka = new DateTime(2026, 1, 1);
            DateTime datKraja = new DateTime(2026, 2, 1);
            rezervacijaZaDodavanje.generateRezervacija(1,idUsera,1,datPocetka,datKraja,499.99, statusRezervacije.Aktivna);
            reservationList.Add(rezervacijaZaDodavanje);

            File.WriteAllText("rezervacije.json", JsonConvert.SerializeObject(reservationList, Formatting.Indented));
        }

        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ovde ce se editovati selektovana rezervacija");
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ovde ce se brisati selektovana rezervacija.");
        }

        private void btnFilterAll_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ovde ce se sortirati dataGridView dole(Sve rezervacije)");
        }

        private void btnFilterActive_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ovde ce se sortirati dataGridView dole(Aktivne rezervacije)");
        }

        private void btnFilterFinished_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ovde ce se sortirati dataGridView dole(Zavrsene rezervacije)");
        }

        private void dataGridReservations_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridReservations.CurrentRow == null) return;
            rezervacija selektovanaRezervacija = (rezervacija)dataGridReservations.CurrentRow.DataBoundItem;
            igra podaciIgre = gameList.FirstOrDefault(igra => igra._idIgre == selektovanaRezervacija.idIgre);
            if (podaciIgre == null) return;
            labelGameName.Text = podaciIgre._gameName;
            labelDescription.Text = podaciIgre._description;
            labelGenre.Text = podaciIgre._genre;
            labelStudio.Text = podaciIgre._gameStudioName;
            labelReleaseYear.Text = podaciIgre._releaseYear.ToString();
            labelReservationStartDate.Text = selektovanaRezervacija.datumRezervacije.ToShortDateString();
            labelReservationEndDate.Text = selektovanaRezervacija.datumVracanja.ToShortDateString();

            TimeSpan trajanjeRezervacije = selektovanaRezervacija.datumVracanja - selektovanaRezervacija.datumRezervacije;
            labelDaysLeft.Text = trajanjeRezervacije.Days.ToString() + " dana";
        }
    }
}
