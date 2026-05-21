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
    public partial class addReservation : Form
    {
        BindingList<igra> gameList;
        userPanel parentForma;
        public addReservation()
        {
            InitializeComponent();
        }

        public addReservation(BindingList<igra> _gameList, userPanel _parentForma)
        {
            InitializeComponent();
            gameList = _gameList;
            parentForma = _parentForma;
        }

        private void addReservation_Load(object sender, EventArgs e)
        {
            // ***** PODESAVANJE DATAGRIDVIEWA ***** //
            dataGridIgre.AutoGenerateColumns = true;
            dataGridIgre.DataSource = gameList;
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
            dataGridIgre.Columns[0].HeaderText = "ID igre";
            dataGridIgre.Columns[1].HeaderText = "Naziv igre";
            dataGridIgre.Columns[2].HeaderText = "Studio";
            dataGridIgre.Columns[3].HeaderText = "Zanr";
            dataGridIgre.Columns[4].HeaderText = "Godina izdavanja";
            dataGridIgre.Columns[5].HeaderText = "Platforma";
            dataGridIgre.Columns[6].HeaderText = "Opis";
            dataGridIgre.Columns[7].HeaderText = "Cena";
            dataGridIgre.Columns[8].HeaderText = "Broj kopija";
            dataGridIgre.Columns[9].HeaderText = "Starosna granica";

            dateEnd.Value = dateEnd.Value.AddDays(1);
        }

        private void dataGridIgre_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridIgre.CurrentRow.DataBoundItem == null) return;
            igra selektovanaIgra = dataGridIgre.CurrentRow.DataBoundItem as igra;
            if (selektovanaIgra == null) return;
            labelGameName.Text = selektovanaIgra._gameName;
            labelDescription.Text = selektovanaIgra._description;
            TimeSpan brDana = dateEnd.Value.Date - dateStart.Value.Date;
            double cena = (selektovanaIgra._price * brDana.Days);
            labelCena.Text = cena.ToString() + " RSD";
        }

        private void btnPrimeniFilter_Click(object sender, EventArgs e)
        {
            BindingList<igra> filtriraneIgre = new BindingList<igra>();
            string filterText = tBoxFilter.Text;
            switch (comboBox1.SelectedIndex)
            {
                case 0: // ime igre
                    foreach(igra _igra in gameList)
                    {
                        if (_igra._gameName.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            filtriraneIgre.Add(_igra);
                        }
                    }
                    break;
                case 1: // ime studija
                    foreach (igra _igra in gameList)
                    {
                        if (_igra._gameStudioName.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            filtriraneIgre.Add(_igra);
                        }
                    }
                    break;
                case 2: // zanr
                    foreach (igra _igra in gameList)
                    {
                        if (_igra._genre.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            filtriraneIgre.Add(_igra);
                        }
                    }
                    break;
                case 3: // godina izdavanja
                    foreach (igra _igra in gameList)
                    {
                        if (_igra._releaseYear.ToString() == filterText)
                        {
                            filtriraneIgre.Add(_igra);
                        }
                    }
                    break;
                case 4: // platforma
                    foreach (igra _igra in gameList)
                    {
                        if (_igra._platformName.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            filtriraneIgre.Add(_igra);
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Nesto nije uredu sa filterom.");
                    break;
            }

            dataGridIgre.DataSource = filtriraneIgre;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // ispis, da vidim sta uzimam
            Console.WriteLine($"Prvo vreme: {dateStart.Value}, drugo vreme: {dateEnd.Value}\nPrvi datum: {dateStart.Value.Date}, drugi datum: {dateEnd.Value.Date}");         
            bool valid = true;
            int brDostupnihKopija = 0;

            if(dataGridIgre.CurrentRow?.DataBoundItem == null)
            {
                MessageBox.Show("Niste izabrali igru.");
                valid = false;
            }
            else
            {
                igra selektovanaIgra = dataGridIgre.CurrentRow.DataBoundItem as igra;
                if (selektovanaIgra == null)
                {
                    MessageBox.Show("Niste izabrali igru.");
                    valid = false;
                }
                else
                {
                    brDostupnihKopija = selektovanaIgra._numberOfCopies;
                    if (brDostupnihKopija <= 0)
                    {
                        MessageBox.Show("Nema dostupnih kopija za ovu igru.");
                        valid = false;
                    }
                }
            }

            if(dateStart.Value.Date > dateEnd.Value.Date)
            {
                MessageBox.Show("Datum pocetka rezervacije ne moze biti posle datuma kraja rezervacije.");
                valid = false;
            }

            if (valid)
            {
                if (parentForma.reservationList.Any(rezervacija => rezervacija.idKorisnika == parentForma.idUsera && rezervacija.idIgre == (dataGridIgre.CurrentRow.DataBoundItem as igra)._idIgre && rezervacija.status == statusRezervacije.Aktivna))
                {
                    MessageBox.Show("Vec imate aktivnu rezervaciju za ovu igru.");
                }
                else napraviRezervaciju();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"Selektovan indeks: {comboBox1.SelectedIndex}");
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.U)
            {
                comboBox1.SelectedItem = "user";
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.A)
            {
                comboBox1.SelectedItem = "admin";
                e.Handled = true;
            }
        }

        private void napraviRezervaciju()
        {
            rezervacija rezervacijaZaDodati = new rezervacija();
            int idIgre = 0;

            if (parentForma.reservationList.Count > 0)
            {
                if (dataGridIgre.CurrentRow?.DataBoundItem != null)
                {
                    idIgre = (dataGridIgre.CurrentRow.DataBoundItem as igra)._idIgre;
                    rezervacijaZaDodati.generateRezervacija(parentForma.reservationList.Last().idRezervacije + 1,
                        parentForma.idUsera,
                        idIgre,
                        dateStart.Value.Date,
                        dateEnd.Value.Date,
                        double.Parse(labelCena.Text.Split(' ')[0]),
                        statusRezervacije.Aktivna);
                }
            }
            else
            {
                if (dataGridIgre.CurrentRow?.DataBoundItem != null)
                {
                    idIgre = (dataGridIgre.CurrentRow.DataBoundItem as igra)._idIgre;
                    rezervacijaZaDodati.generateRezervacija(1,
                        parentForma.idUsera,
                        idIgre,
                        dateStart.Value.Date,
                        dateEnd.Value.Date,
                        double.Parse(labelCena.Text.Split(' ')[0]),
                        statusRezervacije.Aktivna);
                }
            }

            if (rezervacijaZaDodati != null)
            {
                parentForma.reservationList.Add(rezervacijaZaDodati);
                parentForma.dodajRezervacijeUPrikaz(gameList, parentForma.reservationList, parentForma.svrha);
                igra rezervisanaIgra = gameList.FirstOrDefault(igra => igra._idIgre == idIgre);

                string jsonRezervacije = JsonConvert.SerializeObject(parentForma.reservationList, Formatting.Indented);
                string jsonIgre = JsonConvert.SerializeObject(gameList, Formatting.Indented);
                File.WriteAllText("rezervacije.json", jsonRezervacije);
                File.WriteAllText("igre.json", jsonIgre);
                MessageBox.Show("Uspesno ste dodali rezervaciju!");
                this.Close();
            }
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridIgre.CurrentRow?.DataBoundItem != null)
            {
                igra selektovanaIgra = dataGridIgre.CurrentRow.DataBoundItem as igra;
                if (selektovanaIgra != null)
                {
                    TimeSpan brDana = dateEnd.Value.Date - dateStart.Value.Date;
                    double cena = (selektovanaIgra._price * brDana.Days);
                    labelCena.Text = cena.ToString() + " RSD";
                }
            }
        }
    }
}
