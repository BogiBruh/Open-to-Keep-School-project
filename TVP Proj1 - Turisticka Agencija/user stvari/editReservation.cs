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
    public partial class editReservation : Form
    {
        BindingList<prikazRezervacije> prikazRezervacijeList;
        userPanel parentForma;

        public editReservation()
        {
            InitializeComponent();
        }

        public editReservation(BindingList<prikazRezervacije> _prikazRezervacijeList, userPanel _parentForma)
        {
            InitializeComponent();
            prikazRezervacijeList = _prikazRezervacijeList;
            parentForma = _parentForma;
            dataGridIgre.DataSource = prikazRezervacijeList;
        }

        private void editReservation_Load(object sender, EventArgs e)
        {
            // ***** PODESAVANJE DATAGRIDVIEWA ***** //
            dataGridIgre.AutoGenerateColumns = true;
            dataGridIgre.DataSource = prikazRezervacijeList;
            dataGridIgre.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridIgre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridIgre.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridIgre.MultiSelect = false;
            dataGridIgre.AllowUserToAddRows = false;
            dataGridIgre.ColumnHeadersVisible = true;
            dataGridIgre.RowHeadersVisible = false;
            dataGridIgre.ReadOnly = true;
            dataGridIgre.ClearSelection();
            dataGridIgre.CurrentCell = null;
            dataGridIgre.Columns[0].Visible = false;
            renameColumns();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(dataGridIgre.CurrentRow?.DataBoundItem == null) return;
            prikazRezervacije rezPrikaz = (prikazRezervacije)dataGridIgre.CurrentRow.DataBoundItem;
            if (rezPrikaz == null) return;
            else if (rezPrikaz.status == statusRezervacije.Vracena) MessageBox.Show("Možete menjati samo aktivne rezervacije!");
            else
            {
                rezervacija rez = parentForma.reservationList.FirstOrDefault(r => r.idRezervacije == rezPrikaz.idRezervacije);
                if (rez == null) return;
                igra rezervisanaIgra = parentForma.gameList.FirstOrDefault(i => i._idIgre == rez.idIgre);
                if(rezervisanaIgra == null) return;
                
                int brDana = (dateEnd.Value.Date - dateStart.Value.Date).Days;
                if(brDana <= 0)
                {
                    MessageBox.Show("Datum vraćanja mora biti posle datuma rezervacije!");
                    return;
                }

                rez.datumVracanja = dateEnd.Value.Date;
                rezPrikaz.datumVracanja = dateEnd.Value.Date;

                double cena = rezervisanaIgra._price * brDana;
                rez.cena = cena;
                rezPrikaz.cenaRezervacije = cena;
                File.WriteAllText("rezervacije.json", JsonConvert.SerializeObject(parentForma.reservationList));
                dataGridIgre.Refresh();
                MessageBox.Show("Uspešno ste promenili rezervaciju!");
                this.Close();
            }
        }

        private void btnVrati_Click(object sender, EventArgs e)
        {
            if (dataGridIgre.CurrentRow?.DataBoundItem == null) return;
            prikazRezervacije rezervacijaZaMenjanje = (prikazRezervacije)dataGridIgre.CurrentRow.DataBoundItem;
            if (rezervacijaZaMenjanje == null) return;
            else
            {
                if (rezervacijaZaMenjanje.status == statusRezervacije.Aktivna)
                {
                    rezervacijaZaMenjanje.status = statusRezervacije.Vracena;
                    rezervacija rez = parentForma.reservationList.FirstOrDefault(r => r.idRezervacije == rezervacijaZaMenjanje.idRezervacije);
                    if (rez == null) return;
                    igra igraZaVracanje = parentForma.gameList.FirstOrDefault(i => i._idIgre == rez.idIgre);
                    if(igraZaVracanje == null) return;
                    igraZaVracanje._numberOfCopies++;
                    rez.status = statusRezervacije.Vracena;
                    File.WriteAllText("igre.json", JsonConvert.SerializeObject(parentForma.gameList));
                    File.WriteAllText("rezervacije.json", JsonConvert.SerializeObject(parentForma.reservationList));
                    dataGridIgre.Refresh();
                    MessageBox.Show("Uspesno ste vratili igru.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ova igra nije rezervisana, ne mozete je vratiti.");
                }
            }
        }

        private void btnPrimeniFilter_Click(object sender, EventArgs e)
        {
            BindingList<prikazRezervacije> filtriraneRezervacije = new BindingList<prikazRezervacije>();
            string filterText = tBoxFilter.Text;
            switch (comboBox1.SelectedIndex)
            {
                case 0: // ime igre
                    foreach(prikazRezervacije rez in prikazRezervacijeList)
                    {
                        if (rez.gameName.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            filtriraneRezervacije.Add(rez);
                        }
                    }
                    break;
                case 1: // zanr
                   foreach(prikazRezervacije rez in prikazRezervacijeList)
                    {
                        if (rez.genre.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            filtriraneRezervacije.Add(rez);
                        }
                    }
                    break;
                case 2: // platforma
                   foreach(prikazRezervacije rez in prikazRezervacijeList)
                    {
                        if (rez.platform.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            filtriraneRezervacije.Add(rez);
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Nesto nije uredu sa filterom.");
                    break;
            }

            dataGridIgre.DataSource = filtriraneRezervacije;
        }

        private void renameColumns()
        {
            dataGridIgre.Columns[0].HeaderText = "ID Rezervacije";
            dataGridIgre.Columns[1].HeaderText = "Naziv igre";
            dataGridIgre.Columns[2].HeaderText = "Zanr";
            dataGridIgre.Columns[3].HeaderText = "Platforma";
            dataGridIgre.Columns[4].HeaderText = "Cena rezervacije";
            dataGridIgre.Columns[5].HeaderText = "Datum rezervacije";
            dataGridIgre.Columns[6].HeaderText = "Datum vracanja";
            dataGridIgre.Columns[7].HeaderText = "Status rezervacije";
        }

        private void dataGridIgre_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridIgre.CurrentRow?.DataBoundItem == null)
            {
                Console.WriteLine("Nema selektovanog reda ili DataBoundItem je null.");
                return;
            }
            prikazRezervacije selektovanaRezervacija = (prikazRezervacije)dataGridIgre.CurrentRow.DataBoundItem;
            if (selektovanaRezervacija == null) return;
            rezervacija rez = parentForma.reservationList.FirstOrDefault(r => r.idRezervacije == selektovanaRezervacija.idRezervacije);
            if(rez == null) return;
            igra selektovanaIgra = parentForma.gameList.FirstOrDefault(i => i._idIgre == rez.idIgre);
            if(selektovanaIgra == null) return;
            labelGameName.Text = selektovanaIgra._gameName;
            labelDescription.Text = selektovanaIgra._description;
            dateStart.Value = rez.datumRezervacije;
            dateEnd.Value = rez.datumVracanja;
            labelCenaRez.Text = rez.cena.ToString() + " RSD";
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridIgre.CurrentRow?.DataBoundItem == null) return;
            prikazRezervacije selektovanaRezervacija = (prikazRezervacije)dataGridIgre.CurrentRow.DataBoundItem;
            if (selektovanaRezervacija == null) return;
            rezervacija rez = parentForma.reservationList.FirstOrDefault(r => r.idRezervacije == selektovanaRezervacija.idRezervacije);
            if (rez == null) return;
            igra selektovanaIgra = parentForma.gameList.FirstOrDefault(i => i._idIgre == rez.idIgre);
            if (selektovanaIgra == null) return;
            double prvobitnaCena = rez.cena;
            int brDana = (dateEnd.Value.Date - dateStart.Value.Date).Days;
            double novaCena = selektovanaIgra._price * brDana;
            labelCenaEdita.Text = novaCena.ToString() + " RSD";
            if (novaCena < prvobitnaCena)
            {
                Random rand = new Random();
                int kod = 0;
                for(int i = 0; i < 6; i++) kod = kod * 10 + rand.Next(0, 10);
                labelPopust.Text = $"Imate pravo na povracaj novca u iznosu od {(prvobitnaCena - novaCena).ToString() + " RSD"}! Prilikom vraćanja igre dajte i kod ({kod}) i dobićete navedeni iznos nazad!";
                labelPopust.Visible = true;
            }
            else
            {
                labelPopust.Visible = false;
            }
        }
    }
}
