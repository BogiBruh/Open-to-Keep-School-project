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

        public enum svrhaPrikaza
        {
            sve,
            aktivne,
            zavrsene
        }
        public svrhaPrikaza svrha;

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

            svrha = svrhaPrikaza.sve;
            dodajRezervacijeUPrikaz(gameList, reservationList, svrha);

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
            renameColumns();
        }

        private void userPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !logoutovanje)
            {
                Application.Exit();
            }
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            /*rezervacija rezervacijaZaDodavanje = new rezervacija();
            DateTime datPocetka = new DateTime(2026, 1, 1);
            DateTime datKraja = new DateTime(2026, 2, 1);
            if (reservationList.Count > 0)
            {
                rezervacijaZaDodavanje.generateRezervacija(reservationList.Last().idRezervacije + 1, idUsera, 1, datPocetka, datKraja, 1000, statusRezervacije.Aktivna);

            }
            else
            {
                rezervacijaZaDodavanje.generateRezervacija(1, idUsera, 1, datPocetka, datKraja, 1000, statusRezervacije.Aktivna);
            }

            reservationList.Add(rezervacijaZaDodavanje);
            dodajRezervacijeUPrikaz(gameList, reservationList, svrha);

            File.WriteAllText("rezervacije.json", JsonConvert.SerializeObject(reservationList, Formatting.Indented));*/
            addReservation formaZaDodavanje = new addReservation(gameList, this);
            formaZaDodavanje.ShowDialog();
        }

        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            editReservation formaZaIzmene = new editReservation(prikazRezervacijaList, this);
            formaZaIzmene.ShowDialog();
            dataGridReservations.Refresh();
            
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            var potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete ovu rezervaciju?", "Potvrda brisanja", MessageBoxButtons.OKCancel);
            if (potvrda == DialogResult.OK)
            {
                prikazRezervacije rezervacijaZaBrisanje = dataGridReservations.CurrentRow.DataBoundItem as prikazRezervacije;
                if (rezervacijaZaBrisanje == null) return;
                rezervacija rezervacijaUBazi = reservationList.FirstOrDefault(rez => rez.idRezervacije == rezervacijaZaBrisanje.idRezervacije);
                if(rezervacijaUBazi == null) return;
                igra igraZaVracanje = gameList.FirstOrDefault(igra => igra._idIgre == rezervacijaUBazi.idIgre);
                if(igraZaVracanje != null)
                {
                    igraZaVracanje._numberOfCopies++;
                }
                reservationList.Remove(rezervacijaUBazi);
                prikazRezervacijaList.Remove(rezervacijaZaBrisanje);

                File.WriteAllText("rezervacije.json", JsonConvert.SerializeObject(reservationList, Formatting.Indented));
                File.WriteAllText("igre.json", JsonConvert.SerializeObject(gameList, Formatting.Indented));
                MessageBox.Show("Uspesno ste obrisali rezervaciju!");
            }
            else return;
        }

        private void btnFilterAll_Click(object sender, EventArgs e)
        {
            svrha = svrhaPrikaza.sve;
            dodajRezervacijeUPrikaz(gameList, reservationList, svrha);
        }

        private void btnFilterActive_Click(object sender, EventArgs e)
        {
            svrha = svrhaPrikaza.aktivne;
            dodajRezervacijeUPrikaz(gameList, reservationList, svrha);
        }

        private void btnFilterFinished_Click(object sender, EventArgs e)
        {
            svrha = svrhaPrikaza.zavrsene;
            dodajRezervacijeUPrikaz(gameList, reservationList, svrha);
        }

        private void dataGridReservations_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridReservations.CurrentRow == null) return;
            prikazRezervacije prikazana = dataGridReservations.CurrentRow.DataBoundItem as prikazRezervacije;
            if (prikazana == null) return;
            Console.WriteLine($"Selektovana rezervacija: {prikazana.gameName}, {prikazana.idRezervacije}");
            int idIgre = reservationList.FirstOrDefault(rez => rez.idRezervacije == prikazana.idRezervacije).idIgre;
            igra podaciIgre = gameList.FirstOrDefault(igra => igra._idIgre == idIgre);
            if (podaciIgre == null) return;
            Console.WriteLine($"Prikazujem detalje za igru: {podaciIgre._gameName}, {podaciIgre._idIgre}");
            labelGameName.Text = podaciIgre._gameName;
            labelDescription.Text = podaciIgre._description;
            labelGenre.Text = podaciIgre._genre;
            labelStudio.Text = podaciIgre._gameStudioName;
            labelReleaseYear.Text = podaciIgre._releaseYear.ToString();
            labelReservationStartDate.Text = prikazana.datumRezervacije.ToShortDateString();
            labelReservationEndDate.Text = prikazana.datumVracanja.ToShortDateString();

            TimeSpan trajanjeRezervacije = prikazana.datumVracanja - DateTime.Now.Date;
            labelDaysLeft.Text = trajanjeRezervacije.Days.ToString() + " dana";
            if(trajanjeRezervacije.Days <= 0)
            {
                labelDaysLeft.ForeColor = Color.Red;
            }
            else
            {
                labelDaysLeft.ForeColor = SystemColors.ControlText;
            }
        }

        public void dodajRezervacijeUPrikaz(BindingList<igra> gameList, BindingList<rezervacija> reservationList, svrhaPrikaza svrha)
        {
            /* Dodavanje prikladnih rezervacija u prikazRezervacijaList na osnovu idUsera.
             * takodje formirano da bi se izbeglo prikazivanje tehnickih detalja rezervacije korisniku.
             */
            prikazRezervacijaList.Clear(); // Ocistiti svaki put pri generisanju. TODO: naci bolji nacin, da se ne cisti lista uvek

            switch (svrha)
            {
                case svrhaPrikaza.sve:
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
                                prikaz.datumRezervacije = rez.datumRezervacije;
                                prikaz.datumVracanja = rez.datumVracanja;
                                prikaz.status = rez.status;
                                prikaz.cenaRezervacije = rez.cena;
                                prikazRezervacijaList.Add(prikaz);
                            }
                        }
                    }
                    dataGridReservations.DataSource = prikazRezervacijaList;
                    break;
                case svrhaPrikaza.aktivne:
                    foreach (rezervacija rez in reservationList)
                    {
                        if (rez.idKorisnika == idUsera)
                        {
                            if(rez.status == statusRezervacije.Aktivna)
                            {
                                igra igraZaRezervaciju = gameList.FirstOrDefault(igra => igra._idIgre == rez.idIgre);
                                if (igraZaRezervaciju != null)
                                {
                                    prikazRezervacije prikaz = new prikazRezervacije();
                                    prikaz.idRezervacije = rez.idRezervacije;
                                    prikaz.gameName = igraZaRezervaciju._gameName;
                                    prikaz.genre = igraZaRezervaciju._genre;
                                    prikaz.platform = igraZaRezervaciju._platformName;
                                    prikaz.datumRezervacije = rez.datumRezervacije;
                                    prikaz.datumVracanja = rez.datumVracanja;
                                    prikaz.status = rez.status;
                                    prikaz.cenaRezervacije = rez.cena;
                                    prikazRezervacijaList.Add(prikaz);
                                }
                            }
                        }
                    }
                    dataGridReservations.DataSource = prikazRezervacijaList;
                    break;
                case svrhaPrikaza.zavrsene:
                    foreach (rezervacija rez in reservationList)
                    {
                        if (rez.idKorisnika == idUsera)
                        {
                            if(rez.status == statusRezervacije.Vracena)
                            {
                                igra igraZaRezervaciju = gameList.FirstOrDefault(igra => igra._idIgre == rez.idIgre);
                                if (igraZaRezervaciju != null)
                                {
                                    prikazRezervacije prikaz = new prikazRezervacije();
                                    prikaz.idRezervacije = rez.idRezervacije;
                                    prikaz.gameName = igraZaRezervaciju._gameName;
                                    prikaz.genre = igraZaRezervaciju._genre;
                                    prikaz.platform = igraZaRezervaciju._platformName;
                                    prikaz.datumRezervacije = rez.datumRezervacije;
                                    prikaz.datumVracanja = rez.datumVracanja;
                                    prikaz.status = rez.status;
                                    prikaz.cenaRezervacije = rez.cena;
                                    prikazRezervacijaList.Add(prikaz);
                                }
                            }
                        }
                    }
                    dataGridReservations.DataSource = prikazRezervacijaList;
                    break;
                default:
                    MessageBox.Show("Nesto nije bilo uredu kod filtriranja rezervacija.");
                    break;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            logoutovanje = true;
            parentForma.Show();
            this.Close();
        }

        private void renameColumns()
        {
            dataGridReservations.Columns[0].HeaderText = "ID Rezervacije";
            dataGridReservations.Columns[1].HeaderText = "Naziv igre";
            dataGridReservations.Columns[2].HeaderText = "Zanr";
            dataGridReservations.Columns[3].HeaderText = "Platforma";
            dataGridReservations.Columns[4].HeaderText = "Datum rezervacije";
            dataGridReservations.Columns[5].HeaderText = "Datum vracanja";
            dataGridReservations.Columns[6].HeaderText = "Cena rezervacije";
            dataGridReservations.Columns[7].HeaderText = "Status rezervacije";
        }

        private void btnComboboxFilter_Click(object sender, EventArgs e)
        {
            BindingList<prikazRezervacije> tempList = new BindingList<prikazRezervacije>();

            switch (comboBox1.SelectedIndex)
            {
                case 0: // ime igre
                    string filterTextCase1 = tBoxFilter.Text;
                    foreach (prikazRezervacije rez in prikazRezervacijaList)
                    {
                        if (rez.gameName.IndexOf(filterTextCase1, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            if (svrha == svrhaPrikaza.aktivne)
                            {
                                if (rez.status == statusRezervacije.Aktivna)
                                {
                                   tempList.Add(rez);
                                }

                            }
                            else if (svrha == svrhaPrikaza.zavrsene)
                            {
                                if (rez.status == statusRezervacije.Vracena)
                                {
                                    tempList.Add(rez);
                                }
                            }
                            else
                            {
                                tempList.Add(rez);
                            }
                        }
                    }
                    break;
                case 1: // zanr
                    string filterTextCase2 = tBoxFilter.Text;
                    foreach (prikazRezervacije rez in prikazRezervacijaList)
                    {
                        if (rez.genre.IndexOf(filterTextCase2, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            if (svrha == svrhaPrikaza.aktivne)
                            {
                                if (rez.status == statusRezervacije.Aktivna)
                                {
                                    tempList.Add(rez);
                                }

                            }
                            else if (svrha == svrhaPrikaza.zavrsene)
                            {
                                if (rez.status == statusRezervacije.Vracena)
                                {
                                    tempList.Add(rez);
                                }
                            }
                            else
                            {
                                tempList.Add(rez);
                            }
                        }
                    }
                    break;
                case 2: // platforma
                    string filterTextCase3 = tBoxFilter.Text;
                    foreach (prikazRezervacije rez in prikazRezervacijaList)
                    {
                        if (rez.platform.IndexOf(filterTextCase3, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            if (svrha == svrhaPrikaza.aktivne)
                            {
                                if (rez.status == statusRezervacije.Aktivna)
                                {
                                    tempList.Add(rez);
                                }

                            }
                            else if (svrha == svrhaPrikaza.zavrsene)
                            {
                                if (rez.status == statusRezervacije.Vracena)
                                {
                                    tempList.Add(rez);
                                }
                            }
                            else
                            {
                                tempList.Add(rez);
                            }
                        }
                    }
                    break;
                case 3: // datum pocetka rezervacije
                    DateTime filterDateCase4 = dateTimePicker1.Value.Date;

                    foreach (prikazRezervacije rez in prikazRezervacijaList)
                    {
                        if (rez.datumRezervacije == filterDateCase4)
                        {
                            if (svrha == svrhaPrikaza.aktivne)
                            {
                                if (rez.status == statusRezervacije.Aktivna)
                                {
                                    tempList.Add(rez);
                                }

                            }
                            else if (svrha == svrhaPrikaza.zavrsene)
                            {
                                if (rez.status == statusRezervacije.Vracena)
                                {
                                    tempList.Add(rez);
                                }
                            }
                            else
                            {
                                tempList.Add(rez);
                            }
                        }
                    }
                    break;
                case 4: // datum kraja rezervacije
                    DateTime filterDateCase5 = dateTimePicker1.Value.Date;

                    foreach (prikazRezervacije rez in prikazRezervacijaList)
                    {
                        if (rez.datumVracanja == filterDateCase5)
                        {
                            if (svrha == svrhaPrikaza.aktivne)
                            {
                                if (rez.status == statusRezervacije.Aktivna)
                                {
                                    tempList.Add(rez);
                                }

                            }
                            else if (svrha == svrhaPrikaza.zavrsene)
                            {
                                if (rez.status == statusRezervacije.Vracena)
                                {
                                    tempList.Add(rez);
                                }
                            }
                            else
                            {
                                tempList.Add(rez);
                            }
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Nesto nije bilo uredu kod filtriranja rezervacija.");
                    break;
            }

            dataGridReservations.DataSource = tempList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    tBoxFilter.Visible = true;
                    dateTimePicker1.Visible = false;
                    break;
                case 1:
                    tBoxFilter.Visible = true;
                    dateTimePicker1.Visible = false;
                    break;
                case 2:
                    tBoxFilter.Visible = true;
                    dateTimePicker1.Visible = false;
                    break;
                case 3:
                    tBoxFilter.Visible = false;
                    dateTimePicker1.Visible = true;
                    break;
                case 4:
                    tBoxFilter.Visible = false;
                    dateTimePicker1.Visible = true;
                    break;
                default:
                    break;
            }
        }
    }
}
