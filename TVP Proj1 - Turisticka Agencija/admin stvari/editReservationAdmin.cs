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
using TVP_Proj1___Open_To_Rent.user_stvari;
using TVP_Proj1___Turisticka_Agencija;

namespace TVP_Proj1___Open_To_Rent.admin_stvari
{
    public partial class editReservationAdmin : Form
    {
        public BindingList<rezervacija> rezervacijeLista;
        adminPanel parentForma;
        public editReservationAdmin()
        {
            InitializeComponent();
        }

        public editReservationAdmin(BindingList<rezervacija> _rezervacijeLista, adminPanel _parentForma)
        {
            InitializeComponent();
            rezervacijeLista = _rezervacijeLista;
            parentForma = _parentForma;
        }

        private void editReservationAdmin_Load(object sender, EventArgs e)
        {
            // ***** PODESAVANJE DATAGRIDVIEWA ***** //
            dataGridRezervacije.DataSource = rezervacijeLista;
            dataGridRezervacije.AutoGenerateColumns = true;
            dataGridRezervacije.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridRezervacije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridRezervacije.MultiSelect = false;
            dataGridRezervacije.AllowUserToAddRows = false;
            dataGridRezervacije.ColumnHeadersVisible = true;
            dataGridRezervacije.RowHeadersVisible = false;
            dataGridRezervacije.ReadOnly = true;
            dataGridRezervacije.ClearSelection();
            dataGridRezervacije.CurrentCell = null;
            dataGridRezervacije.Columns[0].HeaderText = "ID rezervacije";
            dataGridRezervacije.Columns[1].HeaderText = "ID korisnika";
            dataGridRezervacije.Columns[2].HeaderText = "ID igre";
            dataGridRezervacije.Columns[3].HeaderText = "Datum pocetka";
            dataGridRezervacije.Columns[4].HeaderText = "Datum kraja";
            dataGridRezervacije.Columns[5].HeaderText = "Cena";
            dataGridRezervacije.Columns[6].HeaderText = "Status rezervacije";
        }

        private void dataGridRezervacije_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridRezervacije.CurrentRow?.DataBoundItem == null)
            {
                Console.WriteLine("Nema selektovanog reda ili DataBoundItem je null.");
                return;
            }
            rezervacija selektovanaRezervacija = (rezervacija)dataGridRezervacije.CurrentRow.DataBoundItem;
            if (selektovanaRezervacija == null) return;
            igra selektovanaIgra = parentForma.gameList.FirstOrDefault(i => i._idIgre == selektovanaRezervacija.idIgre);
            if (selektovanaIgra == null) return;
            labelGameName.Text = selektovanaIgra._gameName;
            labelDescription.Text = selektovanaIgra._description;
            dateStart.Value = selektovanaRezervacija.datumRezervacije;
            dateEnd.Value = selektovanaRezervacija.datumVracanja;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrimeniFilter_Click(object sender, EventArgs e)
        {
            BindingList<rezervacija> filtriraneRezervacije = new BindingList<rezervacija>();
            string filterText = tBoxFilter.Text;
            switch (comboBox1.SelectedIndex)
            {
                case 0: // idKorisnika
                    foreach (rezervacija rez in rezervacijeLista)
                    {
                        if (int.TryParse(filterText, out int idKorisnikaFilter) && rez.idKorisnika == idKorisnikaFilter)
                        {
                            filtriraneRezervacije.Add(rez);
                        }
                    }
                    break;
                case 1: // idIgre
                    foreach (rezervacija rez in rezervacijeLista)
                    {
                        if (int.TryParse(filterText, out int idIgreFilter) && rez.idIgre == idIgreFilter)
                        {
                            filtriraneRezervacije.Add(rez);
                        }
                    }
                    break;
                case 2: // Cena
                    foreach (rezervacija rez in rezervacijeLista)
                    {
                        if(double.TryParse(filterText, out double cenaFilter) && rez.cena >= cenaFilter)
                        {
                            filtriraneRezervacije.Add(rez);
                        }
                    }
                    break;
                case 3: // Status
                    foreach (rezervacija rez in rezervacijeLista)
                    {
                        if (rez.status.ToString().IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            filtriraneRezervacije.Add(rez);
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Nesto nije uredu sa filterom.");
                    break;
            }

            dataGridRezervacije.DataSource = filtriraneRezervacije;
        }

        private void btnVrati_Click(object sender, EventArgs e)
        {
            if (dataGridRezervacije.CurrentRow?.DataBoundItem == null) return;
            rezervacija rezervacijaZaMenjanje = (rezervacija)dataGridRezervacije.CurrentRow.DataBoundItem;
            if (rezervacijaZaMenjanje == null) return;
            else
            {
                if (rezervacijaZaMenjanje.status == statusRezervacije.Aktivna)
                {
                    rezervacijaZaMenjanje.status = statusRezervacije.Vracena;
                    igra igraZaVracanje = parentForma.gameList.FirstOrDefault(i => i._idIgre == rezervacijaZaMenjanje.idIgre);
                    if (igraZaVracanje == null) return;
                    igraZaVracanje._numberOfCopies++;
                    rezervacijaZaMenjanje.status = statusRezervacije.Vracena;
                    File.WriteAllText("igre.json", JsonConvert.SerializeObject(parentForma.gameList, Formatting.Indented));
                    File.WriteAllText("rezervacije.json", JsonConvert.SerializeObject(parentForma.reservationList, Formatting.Indented));
                    dataGridRezervacije.Refresh();
                    MessageBox.Show("Uspesno ste vratili igru.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ova igra nije rezervisana, ne mozete je vratiti.");
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dataGridRezervacije.CurrentRow?.DataBoundItem == null) return;
            rezervacija rez = (rezervacija)dataGridRezervacije.CurrentRow.DataBoundItem;
            if (rez == null) return;
            else if (rez.status == statusRezervacije.Vracena) MessageBox.Show("Možete menjati samo aktivne rezervacije!");
            else
            {
                igra rezervisanaIgra = parentForma.gameList.FirstOrDefault(i => i._idIgre == rez.idIgre);
                if (rezervisanaIgra == null) return;
                int brDana = (dateEnd.Value.Date - dateStart.Value.Date).Days;

                if(brDana <= 0)
                {
                    MessageBox.Show("Datum kraja mora biti posle datuma pocetka!");
                    return;
                }

                rez.datumVracanja = dateEnd.Value.Date;
                double cena = rezervisanaIgra._price * brDana;
                rez.cena = cena;
                File.WriteAllText("rezervacije.json", JsonConvert.SerializeObject(parentForma.reservationList));
                dataGridRezervacije.Refresh();
                MessageBox.Show("Uspešno ste promenili rezervaciju!");
                this.Close();
            }
        }
    }
}
