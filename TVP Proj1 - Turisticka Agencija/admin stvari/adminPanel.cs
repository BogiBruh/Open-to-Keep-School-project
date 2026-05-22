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
using TVP_Proj1___Open_To_Rent.admin_stvari;
using TVP_Proj1___Open_To_Rent.klase;

namespace TVP_Proj1___Turisticka_Agencija
{
    public partial class adminPanel : Form
    {
        public BindingList<igra> gameList = new BindingList<igra>();
        public BindingList<rezervacija> reservationList = new BindingList<rezervacija>();
        public BindingList<user> userList = new BindingList<user>();
        string menu = "igre"; // podrazumevano se prikazuju igre, ali se menja na klik dugmadi
        loginForm parentForm;

        bool logoutovanje = false; // sluzi da bi znali da li zatvaramo formu zbog logouta ili zbog X dugmeta

        public adminPanel()
        {
            InitializeComponent();
        }

        public adminPanel(BindingList<user> _userList, loginForm parentForma)
        {
            InitializeComponent();

            // ***** PODESAVANJE DATAGRIDVIEWA ***** //
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = gameList;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            renameColumns();

            userList = _userList;
            parentForm = parentForma;

            btnPrvaOpcija.Text = "Dodaj igru";
            btnDrugaOpcija.Text = "Uredi igru";
            btnTrecaOpcija.Text = "Obrisi igru";
        }

        private void adminPanel_Load(object sender, EventArgs e)
        {
            igra tmpObjZaCitanje = new igra();
            int citanje = tmpObjZaCitanje.readGames(gameList);
            if (citanje == -1)
            {
                MessageBox.Show("Nesto ne predvidjeno nije uredu sa citanjem fajla!");
                this.Close();
            }

            rezervacija tmpObjZaCitanjeRez = new rezervacija();
            int citanjeRez = tmpObjZaCitanjeRez.readRezervacije(reservationList);
            if (citanjeRez == -1)
            {
                MessageBox.Show("Nesto ne predvidjeno nije uredu sa citanjem rezervacija!");
                this.Close();
            }
        }

        private void adminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing && !logoutovanje)
            {
                Application.Exit();
            }
        }

        private void btnIgre_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = gameList;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            menu = "igre";
            renameColumns();

            btnPrvaOpcija.Text = "Dodaj igru";
            btnDrugaOpcija.Text = "Uredi igru";
            btnTrecaOpcija.Text = "Obrisi igru";
            btnTrecaOpcija.Visible = true;
        }

        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = userList;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            menu = "korisnici";
            renameColumns();

            btnPrvaOpcija.Text = "Dodaj korisnika";
            btnDrugaOpcija.Text = "Uredi korisnika";
            btnTrecaOpcija.Text = "Obrisi korisnika";
            btnTrecaOpcija.Visible = true;
        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reservationList;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            menu = "rezervacije";
            renameColumns();

            btnPrvaOpcija.Text = "Uredi rezervaciju";
            btnDrugaOpcija.Text = "Obrisi rezervaciju";
            btnTrecaOpcija.Visible = false;
        }

        private void btnPrvaOpcija_Click(object sender, EventArgs e)
        {
            switch (menu)
            {
                case "igre":
                    dodajIgru();
                    break;
                case "korisnici":
                    dodajKorisnika();
                    break;
                case "rezervacije":
                    urediRezervaciju();
                    break;
                default:
                    MessageBox.Show("nesto ne predvidjeno nije uredu sa menijem!(btnPrvaOpcija");
                    break;
            }
        }

        private void btnDrugaOpcija_Click(object sender, EventArgs e)
        {
            switch (menu)
            {
                case "igre":
                    urediIgru();
                    break;
                case "korisnici":
                    urediKorisnika();
                    break;
                case "rezervacije":
                    izbrisiRezervaciju();
                    break;
                default:
                    MessageBox.Show("nesto ne predvidjeno nije uredu sa menijem!(btnDrugaOpcija");
                    break;
            }
        }

        private void btnTrecaOpcija_Click(object sender, EventArgs e)
        {
            switch (menu)
            {
                case "igre":
                    izbrisiIgru();
                    break;
                case "korisnici":
                    izbrisiKorisnika();
                    break;
                default:
                    MessageBox.Show("nesto ne predvidjeno nije uredu sa menijem!(btnTrecaOpcija");
                    break;
            }
        }

        private void dodajIgru()
        {
            addOrEditGameForm addGameForm = new addOrEditGameForm("dodaj", this);
            addGameForm.ShowDialog();

            File.WriteAllText("igre.json", JsonConvert.SerializeObject(gameList, Formatting.Indented));
        }

        private void izbrisiIgru()
        {
            if (dataGridView1.CurrentRow != null)
            {
                if(reservationList.Any(rez => rez.idIgre == ((igra)dataGridView1.CurrentRow.DataBoundItem)._idIgre && rez.status == statusRezervacije.Aktivna))
                {
                    MessageBox.Show("Ne možete obrisati igru koja ima aktivne rezervacije! Molim vas, sačekajte da se sve rezervacije za ovu igru završe.");
                    return;
                }
                else if(reservationList.Any(rez => rez.idIgre == ((igra)dataGridView1.CurrentRow.DataBoundItem)._idIgre && rez.status == statusRezervacije.Vracena))
                {
                    MessageBox.Show("Morate obrisati sve zavrsene rezervacije pre nego sto obrisete igru.");
                    return;
                }
                else
                {
                    igra selektovanaIgra = (igra)dataGridView1.CurrentRow.DataBoundItem;
                    gameList.Remove(selektovanaIgra);
                    File.WriteAllText("igre.json", JsonConvert.SerializeObject(gameList, Formatting.Indented));

                    MessageBox.Show("Uspešno brisanje igre iz baze podataka.");
                }
            }
            else
            {
                MessageBox.Show("Morate selektovati igru da bi radilo!");
                return;
            }
        }

        private void urediIgru()
        {
            if (dataGridView1.CurrentRow != null)
            {
                addOrEditGameForm editGameForm = new addOrEditGameForm("uredi", this, (igra)dataGridView1.CurrentRow.DataBoundItem);
                editGameForm.ShowDialog();

                dataGridView1.Refresh(); // osvezavamo datagridview da bi se videle promene koje smo napravili u igri
                dataGridView1.ClearSelection(); // skidamo selekciju
                File.WriteAllText("igre.json", JsonConvert.SerializeObject(gameList, Formatting.Indented));

            }
            else
            {
                MessageBox.Show("Molim vas, prvo selektujte igru.");
                return;
            }
        }

        private void dodajKorisnika()
        {
            //MessageBox.Show("za sad ne radi!(dodajKorisnika)");
            addOrEditUserForm addUserForm = new addOrEditUserForm("dodaj", this);
            addUserForm.ShowDialog();

            File.WriteAllText("users.json", JsonConvert.SerializeObject(userList, Formatting.Indented));
        }

        private void urediKorisnika()
        {
            //MessageBox.Show("za sad ne radi!(urediKorisnika)");
            if(dataGridView1.CurrentRow != null)
            {
                addOrEditUserForm editUserForm = new addOrEditUserForm("uredi", this, (user)dataGridView1.CurrentRow.DataBoundItem);
                editUserForm.ShowDialog();

                dataGridView1.Refresh(); // osvezavamo datagridview da bi se videle promene koje smo napravili u korisniku
                dataGridView1.ClearSelection(); // skidamo selekciju
                File.WriteAllText("users.json", JsonConvert.SerializeObject(userList, Formatting.Indented));
            }
            else
            {
                MessageBox.Show("Molim vas, prvo selektujte korisnika.");
                return;
            }
        }

        private void izbrisiKorisnika()
        {
            if (dataGridView1.CurrentRow != null)
            {
                // proveravamo da li ima ikakve rezervacije, zato sto ako ima i te rezervacije se vide moze da dodje do kresovanja
                if(reservationList.Any(rez => rez.idKorisnika == ((user)dataGridView1.CurrentRow.DataBoundItem)._idNaloga))
                {
                    MessageBox.Show("Ne možete obrisati korisnika koji ima rezervacije vezane za svoj id. Molim vas, prvo obrišite sve rezervacije ovog korisnika.");
                    return;
                }
                else
                {
                    user selektovanKorisnik = (user)dataGridView1.CurrentRow.DataBoundItem;
                    userList.Remove(selektovanKorisnik);
                    File.WriteAllText("users.json", JsonConvert.SerializeObject(userList, Formatting.Indented));

                    MessageBox.Show("Uspešno brisanje korisnika iz baze podataka.");
                }
            }
            else
            {
                MessageBox.Show("Morate selektovati korisnika da bi radilo!");
                return;
            }
        }

        private void urediRezervaciju()
        {
            //MessageBox.Show("za sad ne radi!(urediRezervaciju)");
            editReservationAdmin editRezForm = new editReservationAdmin(reservationList, this);
            editRezForm.ShowDialog();
            dataGridView1.Refresh();
        }

        private void izbrisiRezervaciju()
        {
            //MessageBox.Show("za sad ne radi!(izbrisiRezervaciju)");
            if(dataGridView1.CurrentRow != null)
            {
                rezervacija rezZaBrisanje = (rezervacija)dataGridView1.CurrentRow.DataBoundItem;
                if (rezZaBrisanje == null)
                {
                    Console.WriteLine("rezZaBrisanje je null");
                    return;
                }
                igra vracenaIgra = gameList.FirstOrDefault(ig => ig._idIgre == rezZaBrisanje.idIgre);
                if (vracenaIgra != null && rezZaBrisanje.status == statusRezervacije.Aktivna)
                {
                    vracenaIgra._numberOfCopies++;
                }

                reservationList.Remove(rezZaBrisanje);
                File.WriteAllText("rezervacije.json", JsonConvert.SerializeObject(reservationList, Formatting.Indented));
                File.WriteAllText("igre.json", JsonConvert.SerializeObject(gameList, Formatting.Indented));
                MessageBox.Show("Uspesno izbrisana rezervacija.");
            }
            else
            {
                MessageBox.Show("Morate selektovati rezervaciju da bi radilo!");
                return;
            }
        }

        private void renameColumns()
        {
            switch (menu)
            {
                case "igre":
                    dataGridView1.Columns[0].HeaderText = "ID igre";
                    dataGridView1.Columns[1].HeaderText = "Naziv igre";
                    dataGridView1.Columns[2].HeaderText = "Studio";
                    dataGridView1.Columns[3].HeaderText = "Zanr";
                    dataGridView1.Columns[4].HeaderText = "Godina izdavanja";
                    dataGridView1.Columns[5].HeaderText = "Platforma";
                    dataGridView1.Columns[6].HeaderText = "Opis";
                    dataGridView1.Columns[7].HeaderText = "Cena";
                    dataGridView1.Columns[8].HeaderText = "Broj primeraka";
                    dataGridView1.Columns[9].HeaderText = "Starosna granica";
                    break;
                case "korisnici":
                    dataGridView1.Columns[0].HeaderText = "ID naloga";
                    dataGridView1.Columns[1].HeaderText = "Ime";
                    dataGridView1.Columns[2].HeaderText = "Prezime";
                    dataGridView1.Columns[3].HeaderText = "Username";
                    dataGridView1.Columns[4].HeaderText = "Email";
                    dataGridView1.Columns[5].HeaderText = "Password";
                    dataGridView1.Columns[6].HeaderText = "Tip naloga";
                    break;
                case "rezervacije":
                    dataGridView1.Columns[0].HeaderText = "ID rezervacije";
                    dataGridView1.Columns[1].HeaderText = "ID korisnika";
                    dataGridView1.Columns[2].HeaderText = "ID igre";
                    dataGridView1.Columns[3].HeaderText = "Datum pocetka";
                    dataGridView1.Columns[4].HeaderText = "Datum kraja";
                    dataGridView1.Columns[5].HeaderText = "Cena";
                    dataGridView1.Columns[6].HeaderText = "Status rezervacije";
                    break;
                default:
                    MessageBox.Show("nesto ne predvidjeno nije uredu sa menijem!(renameColumns)");
                    break;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            logoutovanje = true;
            parentForm.Show();
            this.Close();
        }
    }
}