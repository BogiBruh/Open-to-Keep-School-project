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

namespace TVP_Proj1___Turisticka_Agencija
{
    public partial class adminPanel : Form
    {
        public BindingList<igra> gameList = new BindingList<igra>();
        //public BindingList<reservation> reservationList = new BindingList<reservation>();
        public BindingList<user> userList = new BindingList<user>();
        string menu = "igre"; // podrazumevano se prikazuju igre, ali se menja na klik dugmadi

        public adminPanel()
        {
            InitializeComponent();
        }

        public adminPanel(BindingList<user> _userList)
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
        }

        private void adminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnIzleti_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = gameList;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            menu = "igre";
            renameColumns();

            btnPrvaOpcija.Text = "Dodaj igru";
            btnDrugaOpcija.Text = "Uredi igru";
            btnTrecaOpcija.Text = "Obrisi igru";
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
        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ovde ce se prikazivati rezervacije, ali za sad ne radi!");
            dataGridView1.DataSource = null;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            menu = "rezervacije";
            renameColumns();

            btnPrvaOpcija.Text = "Uredi rezervaciju";
            btnDrugaOpcija.Text = "Obrisi rezervaciju";
            btnTrecaOpcija.Hide();
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
                igra selektovanaIgra = (igra)dataGridView1.CurrentRow.DataBoundItem;
                gameList.Remove(selektovanaIgra);
                File.WriteAllText("igre.json", JsonConvert.SerializeObject(gameList, Formatting.Indented));
            }
            else
            {
                MessageBox.Show("Morate selektovati izlet da bi radilo!");
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
                user selektovanKorisnik = (user)dataGridView1.CurrentRow.DataBoundItem;
                userList.Remove(selektovanKorisnik);
                File.WriteAllText("users.json", JsonConvert.SerializeObject(userList, Formatting.Indented));
            }
            else
            {
                MessageBox.Show("Morate selektovati korisnika da bi radilo!");
                return;
            }
        }

        private void urediRezervaciju()
        {
            MessageBox.Show("za sad ne radi!(urediRezervaciju)");
        }

        private void izbrisiRezervaciju()
        {
            MessageBox.Show("za sad ne radi!(izbrisiRezervaciju)");
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
                    dataGridView1.Columns[6].HeaderText = "Account type";
                    break;
                case "rezervacije":
                    //dataGridView1.Columns[0].HeaderText = "";
                    break;
                default:
                    MessageBox.Show("nesto ne predvidjeno nije uredu sa menijem!(renameColumns)");
                    break;
            }
        }
    }
}