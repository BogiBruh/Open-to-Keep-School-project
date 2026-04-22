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

namespace TVP_Proj1___Turisticka_Agencija
{
    public partial class adminPanel : Form
    {
        public BindingList<izlet> izletList = new BindingList<izlet>();
        //public BindingList<reservation> reservationList = new BindingList<reservation>();
        public BindingList<user> userList = new BindingList<user>();
        string menu = "izleti"; // podrazumevano se prikazuju izleti, ali se menja na klik dugmadi

        public adminPanel()
        {
            InitializeComponent();
        }

        public adminPanel(BindingList<user> _userList)
        {
            InitializeComponent();

            // ***** PODESAVANJE DATAGRIDVIEWA ***** //
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = izletList;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].Visible = false; // sakrivamo idIzleta kolonu, ne treba da se vidi
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            userList = _userList;

            btnPrvaOpcija.Text = "Dodaj izlet";
            btnDrugaOpcija.Text = "Uredi izlet";
            btnTrecaOpcija.Text = "Obrisi izlet";
        }

        private void adminPanel_Load(object sender, EventArgs e)
        {
            izlet tmpObjZaCitanje = new izlet();
            int citanje = tmpObjZaCitanje.readIzletFile(izletList);
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
            dataGridView1.DataSource = izletList;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            menu = "izleti";

            btnPrvaOpcija.Text = "Dodaj izlet";
            btnDrugaOpcija.Text = "Uredi izlet";
            btnTrecaOpcija.Text = "Obrisi izlet";
        }

        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = userList;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            menu = "korisnici";

            btnPrvaOpcija.Text = "Dodaj korisnika";
            btnDrugaOpcija.Text = "Uredi korisnika";
            btnTrecaOpcija.Text = "Obrisi korisnika";
        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ovde ce se prikazivati rezervacije, ali za sad ne radi!");
            dataGridView1.DataSource = null;
            //dataGridView1.Columns[0].Visible = false;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            menu = "rezervacije";

            btnPrvaOpcija.Text = "Uredi rezervaciju";
            btnDrugaOpcija.Text = "Obrisi rezervaciju";
            btnTrecaOpcija.Hide();
        }

        private void btnPrvaOpcija_Click(object sender, EventArgs e)
        {
            switch(menu)
            {
                case "izleti":
                    dodajIzlet();
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
                case "izleti":
                    urediIzlet();
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
                case "izleti":
                    izbrisiIzlet();
                    break;
                case "korisnici":
                    izbrisiKorisnika();
                    break;
                 default:
                    MessageBox.Show("nesto ne predvidjeno nije uredu sa menijem!(btnTrecaOpcija");
                    break;
            }
        }

        private void dodajIzlet()
        {
            izlet primerIzleta = new izlet();

            if (izletList.Count() > 0)
            {
                primerIzleta.generateIzlet(izletList.Last()._idIzleta + 1, "zakintos", "grcka", 100, 20, 7, 50, DateTime.Now.Date);
            }
            else
            {
                primerIzleta.generateIzlet(1, "zakintos", "grcka", 100, 20, 7, 50, DateTime.Now.Date);
            }

            izletList.Add(primerIzleta);

            File.WriteAllText("izleti.json", JsonConvert.SerializeObject(izletList, Formatting.Indented));
        }

        private void izbrisiIzlet()
        {
            if (dataGridView1.CurrentRow != null)
            {
                izlet selektovanIzlet = (izlet)dataGridView1.CurrentRow.DataBoundItem;
                izletList.Remove(selektovanIzlet);
                File.WriteAllText("izleti.json", JsonConvert.SerializeObject(izletList, Formatting.Indented));
            }
            else
            {
               MessageBox.Show("Morate selektovati izlet da bi radilo!");
                return;
            }
        }

        private void urediIzlet()
        {
            MessageBox.Show("za sad ne radi!(urediIzlet)");
        }

        private void dodajKorisnika()
        {
            MessageBox.Show("za sad ne radi!(dodajKorisnika)");
        }

        private void izbrisiKorisnika()
        {
            if(dataGridView1.CurrentRow != null)
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

        private void urediKorisnika()
        {
            MessageBox.Show("za sad ne radi!(urediKorisnika)");
        }

        private void urediRezervaciju()
        {
            MessageBox.Show("za sad ne radi!(urediRezervaciju)");
        }

        private void izbrisiRezervaciju()
        {
            MessageBox.Show("za sad ne radi!(izbrisiRezervaciju)");
        }
    }
}