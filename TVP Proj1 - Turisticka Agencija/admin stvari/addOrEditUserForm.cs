using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVP_Proj1___Turisticka_Agencija;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace TVP_Proj1___Open_To_Rent.admin_stvari
{
    public partial class addOrEditUserForm : Form
    {
        string _svrha;
        adminPanel _parentForm;
        user _userZaUredjenje = null;

        public addOrEditUserForm()
        {
            InitializeComponent();
        }

        public addOrEditUserForm(string svrha, adminPanel parentForm)
        {
            InitializeComponent();
            _svrha = svrha;
            _parentForm = parentForm;
        }

        public addOrEditUserForm(string svrha, adminPanel parentForm, user userZaUredjenje)
        {
            InitializeComponent();
            _svrha = svrha;
            _parentForm = parentForm;
            _userZaUredjenje = userZaUredjenje;
        }

        private void addOrEditUserForm_Load(object sender, EventArgs e)
        {
            switch (_svrha)
            {
                case "dodaj":
                    labelNaslov.Text = "Dodaj korisnika";
                    this.Text = "Dodaj korisnika";
                    break;
                case "uredi":
                    labelNaslov.Text = "Uredi korisnika";
                    this.Text = "Uredi korisnika";

                    if (_userZaUredjenje != null)
                    {
                        tBoxIme.Text = _userZaUredjenje._ime;
                        tBoxPrezime.Text = _userZaUredjenje._prezime;
                        tBoxEmail.Text = _userZaUredjenje._email;
                        tBoxUsername.Text = _userZaUredjenje._username;
                        tBoxLozinka.Text = _userZaUredjenje._password;
                        if(_userZaUredjenje._accountType == "user")
                        {
                            cBoxUserAdmin.SelectedIndex = 0;
                        }
                        else if(_userZaUredjenje._accountType == "admin")
                        {
                            cBoxUserAdmin.SelectedIndex = 1;
                        }
                    }

                    break;
                default:
                    break;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            user userZaVracanje = new user();
            string imePrezime;
            string ime;
            string prezime;
            string email;
            string username;
            string password;
            string accountType;

            bool valid = true;

            // vracanje boja na default, radi lakseg ponovnog popunjavanja
            tBoxIme.BackColor = TextBox.DefaultBackColor;
            tBoxPrezime.BackColor = TextBox.DefaultBackColor;
            tBoxEmail.BackColor = TextBox.DefaultBackColor;
            tBoxUsername.BackColor = TextBox.DefaultBackColor;
            tBoxLozinka.BackColor = TextBox.DefaultBackColor;

            if (string.IsNullOrWhiteSpace(tBoxIme.Text))
            {
                valid = false;
                tBoxIme.BackColor = Color.Red;
            }
            if (string.IsNullOrWhiteSpace(tBoxPrezime.Text))
            {
                valid = false;
                tBoxPrezime.BackColor = Color.Red;
            }
            if (string.IsNullOrWhiteSpace(tBoxUsername.Text))
            {
                valid = false;
                tBoxUsername.BackColor = Color.Red;
            }

            // Specijalan(ima i else) jer mora da se proveri da li je mejl mejl
            if (string.IsNullOrWhiteSpace(tBoxEmail.Text)) 
            {
                valid = false;
                tBoxEmail.BackColor = Color.Red;
            }
            else if(tBoxEmail.Text.Length <= 10)
            {
                valid = false;
                tBoxEmail.BackColor = Color.Red;
            }
            else if(tBoxEmail.Text.Substring(tBoxEmail.Text.Length - 10) != "@gmail.com")
            {
                valid = false;
                tBoxEmail.BackColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(tBoxLozinka.Text))
            {
                valid = false;
                tBoxLozinka.BackColor = Color.Red;
            }
            if(cBoxUserAdmin.SelectedIndex == -1)
            {
                valid = false;
                cBoxUserAdmin.BackColor = Color.Red;
            }

            if (!valid) 
            {
                MessageBox.Show("Napravili ste greške u popunjavanju. Molim vas da ispravite sva polja označena crvenom bojom.");
            }
            else
            {
                imePrezime = tBoxIme.Text + " " + tBoxPrezime.Text;
                ime = tBoxIme.Text;
                prezime = tBoxPrezime.Text;
                email = tBoxEmail.Text;
                username = tBoxUsername.Text;
                password = tBoxLozinka.Text;
                accountType = cBoxUserAdmin.SelectedItem.ToString();

                if (_svrha == "dodaj")
                {
                    if (_parentForm.userList.Count > 0)
                    {
                        userZaVracanje.generateUser(_parentForm.userList.Last()._idNaloga + 1, imePrezime, username, email, password, accountType);
                    }
                    else
                    {
                        userZaVracanje.generateUser(1, imePrezime, username, email, password, accountType);
                    }
                    _parentForm.userList.Add(userZaVracanje);
                    MessageBox.Show("Uspešno dodavanje novog korisnika.");
                    this.Close();
                }
                else if (_svrha == "uredi")
                {
                    _userZaUredjenje._ime = ime;
                    _userZaUredjenje._prezime = prezime;
                    _userZaUredjenje._username = username;
                    _userZaUredjenje._email = email;
                    _userZaUredjenje._password = password;
                    _userZaUredjenje._accountType = accountType;
                    MessageBox.Show("Podaci uspešno uređeni.");
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cBoxUserAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.U)
            {
                cBoxUserAdmin.SelectedItem = "user";
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.A)
            {
                cBoxUserAdmin.SelectedItem = "admin";
                e.Handled = true;
            }
        }
    }
}
