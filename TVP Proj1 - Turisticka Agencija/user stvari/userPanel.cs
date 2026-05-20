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
        public BindingList<prikazRezervacije> prikazRezervacijaList = new BindingList<prikazRezervacije>();
        public int idUsera;

        bool logoutovanje = false;
        loginForm parentForma;

        public userPanel()
        {
            InitializeComponent();
        }

        public userPanel(int _idUsera, loginForm _parentForma)
        {
            InitializeComponent();
            idUsera = _idUsera;
            parentForma = _parentForma;
        }

        private void userPanel_Load(object sender, EventArgs e)
        {
            rezervacija tmpObjekatZaCitanjeRezervacija = new rezervacija();
            int citanjeRezervacija = tmpObjekatZaCitanjeRezervacija.readRezervacije(reservationList);
            if (citanjeRezervacija == -1)
            {
                MessageBox.Show("Nesto nije bilo uredu kod citanja rezervacija.");
                this.Close();
            }

            igra tmpObjekatZaCitanjeIgara = new igra();
            int citanjeIgara = tmpObjekatZaCitanjeIgara.readGames(gameList);
            if (citanjeIgara == -1)
            {
                MessageBox.Show("Nesto nije bilo uredu kod citanja igara.");
                this.Close();
            }

            dodajRezervacijeUPrikaz(gameList, reservationList);

            //Podesavanje datagridviewa
            dataGridReservations.DataSource = prikazRezervacijaList;
            dataGridReservations.AutoGenerateColumns = true;
            dataGridReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridReservations.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridReservations.MultiSelect = false;
            dataGridReservations.AllowUserToAddRows = false;
            dataGridReservations.ColumnHeadersVisible = true;
            dataGridReservations.RowHeadersVisible = false;
            dataGridReservations.ReadOnly = true;
            dataGridReservations.Columns[0].Visible = false;
        }

        private void userPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing && !logoutovanje)
            {
                Application.Exit();
            }
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            rezervacija rezervacijaZaDodavanje = new rezervacija();
            DateTime datPocetka = new DateTime(2026, 1, 1);
            DateTime datKraja = new DateTime(2026, 2, 1);
            rezervacijaZaDodavanje.generateRezervacija(1, idUsera, 1, datPocetka, datKraja, 499.99, statusRezervacije.Aktivna);
            reservationList.Add(rezervacijaZaDodavanje);
            dodajRezervacijeUPrikaz(gameList, reservationList);

            File.WriteAllText("rezervacije.json", JsonConvert.SerializeObject(reservationList, Formatting.Indented));
        }

        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ovde ce se editovati selektovana rezervacija");
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            var potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete ovu rezervaciju?", "Potvrda brisanja", MessageBoxButtons.OKCancel);
            if (potvrda == DialogResult.OK)
            {
                prikazRezervacije rezervacijaZaBrisanje = dataGridReservations.CurrentRow.DataBoundItem as prikazRezervacije;
                rezervacija rezervacijaUBazi = reservationList.FirstOrDefault(rez => rez.idRezervacije == rezervacijaZaBrisanje.idRezervacije);
                reservationList.Remove(rezervacijaUBazi);
                prikazRezervacijaList.Remove(rezervacijaZaBrisanje);

                File.WriteAllText("rezervacije.json", JsonConvert.SerializeObject(reservationList, Formatting.Indented));
                MessageBox.Show("Uspesno ste obrisali rezervaciju!");
            }
            else return;
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
            if (dataGridReservations.CurrentRow == null) return;
            prikazRezervacije prikazana = dataGridReservations.CurrentRow.DataBoundItem as prikazRezervacije;
            int idIgre = reservationList.FirstOrDefault(rez => rez.idRezervacije == prikazana.idRezervacije).idIgre;
            igra podaciIgre = gameList.FirstOrDefault(igra => igra._idIgre == idIgre);
            if (podaciIgre == null) return;
            labelGameName.Text = podaciIgre._gameName;
            labelDescription.Text = podaciIgre._description;
            labelGenre.Text = podaciIgre._genre;
            labelStudio.Text = podaciIgre._gameStudioName;
            labelReleaseYear.Text = podaciIgre._releaseYear.ToString();
            labelReservationStartDate.Text = prikazana.datumRezervacije.ToShortDateString();
            labelReservationEndDate.Text = prikazana.datumVracanja.ToShortDateString();

            TimeSpan trajanjeRezervacije = prikazana.datumVracanja - prikazana.datumRezervacije;
            labelDaysLeft.Text = trajanjeRezervacije.Days.ToString() + " dana";
        }

        private void dodajRezervacijeUPrikaz(BindingList<igra> gameList, BindingList<rezervacija> reservationList)
        {
            /* Dodavanje prikladnih rezervacija u prikazRezervacijaList na osnovu idUsera.
             * takodje formirano da bi se izbeglo prikazivanje tehnickih detalja rezervacije korisniku.
             */
            prikazRezervacijaList.Clear(); // Ocistiti svaki put pri generisanju. TODO: naci bolji nacin, da se ne cisti lista uvek

            foreach (rezervacija rez in reservationList)
            {
                if (rez.idKorisnika == idUsera)
                {
                    igra igraZaRezervaciju = gameList.FirstOrDefault(igra => igra._idIgre == rez.idIgre);
                    if (igraZaRezervaciju != null)
                    {
                        prikazRezervacije prikaz = new prikazRezervacije();
                        prikaz.idRezervacije = rez.idRezervacije;
                        prikaz.gameName = igraZaRezervaciju._gameName;
                        prikaz.genre = igraZaRezervaciju._genre;
                        prikaz.platform = igraZaRezervaciju._platformName;
                        prikaz.brKopija = igraZaRezervaciju._numberOfCopies;
                        prikaz.datumRezervacije = rez.datumRezervacije;
                        prikaz.datumVracanja = rez.datumVracanja;
                        prikaz.status = rez.status;
                        prikazRezervacijaList.Add(prikaz);
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            logoutovanje = true;
            parentForma.Show();
            this.Close();
        }
    }
}
