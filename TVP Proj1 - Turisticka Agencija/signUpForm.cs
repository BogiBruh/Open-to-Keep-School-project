using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_Proj1___Turisticka_Agencija
{
    public partial class signUpForm : Form
    {
        loginForm _loginForma;
        bool userOrAdmin = false; // false = user, true = admin

        public signUpForm()
        {
            InitializeComponent();
        }

        public signUpForm(loginForm loginForma)
        {
            InitializeComponent();
            _loginForma = loginForma;
        }

        private void signUpForm_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
            tBoxSifra.Visible = false;
            btnSignUp.Location = new Point(btnSignUp.Location.X, 510);
            this.Size = new Size(this.Size.Width, 650);
        }

        private void signUpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginForma.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            tBoxSifra.Visible = false;
            btnSignUp.Location = new Point(btnSignUp.Location.X, 510);
            this.Size = new Size(this.Size.Width, 650);
            userOrAdmin = false;

            // za svaki slucaj
            tBoxImePrezime.BackColor = SystemColors.Window;
            tBoxUsername.BackColor = SystemColors.Window;
            tBoxEmail.BackColor = SystemColors.Window;
            tBoxLozinka.BackColor = SystemColors.Window;
            tBoxPotvrdaLozinke.BackColor = SystemColors.Window;
            tBoxSifra.BackColor = SystemColors.Window;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            tBoxSifra.Visible = true;
            btnSignUp.Location = new Point(btnSignUp.Location.X, 600);
            this.Size = new Size(this.Size.Width, 720);
            userOrAdmin = true;

            // za svaki slucaj
            tBoxImePrezime.BackColor = SystemColors.Window;
            tBoxUsername.BackColor = SystemColors.Window;
            tBoxEmail.BackColor = SystemColors.Window;
            tBoxLozinka.BackColor = SystemColors.Window;
            tBoxPotvrdaLozinke.BackColor = SystemColors.Window;
            tBoxSifra.BackColor = SystemColors.Window;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string imeprezime;
            string username;
            string email;
            string password;
            bool valid = true;

            // vracanje textbox boja u normalu radi lakseg ponovnog unosa
            tBoxImePrezime.BackColor = SystemColors.Window;
            tBoxUsername.BackColor = SystemColors.Window;
            tBoxEmail.BackColor = SystemColors.Window;
            tBoxLozinka.BackColor = SystemColors.Window;
            tBoxPotvrdaLozinke.BackColor = SystemColors.Window;
            tBoxSifra.BackColor = SystemColors.Window;

            if (string.IsNullOrWhiteSpace(tBoxImePrezime.Text) || !tBoxImePrezime.Text.Contains(" "))
            {
                tBoxImePrezime.BackColor = Color.Red;
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(tBoxUsername.Text))
            {
                tBoxUsername.BackColor = Color.Red;
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(tBoxEmail.Text)) // ako je prazno ne valja
            {
                tBoxEmail.BackColor = Color.Red;
                valid = false;
            }
            else if (tBoxEmail.Text.Length < 10) // ako ima manje od 10 karaktera ne valja, jer ne moze da stane @gmail.com
            {
                tBoxEmail.BackColor = Color.Red;
                valid = false;
            }
            else if (tBoxEmail.Text.Substring(tBoxEmail.Text.Length - 10) != "@gmail.com") // i zadnje, ako nema @gmail.com na kraju ne valja
            {
                tBoxEmail.BackColor = Color.Red;
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(tBoxLozinka.Text))
            {
                tBoxLozinka.BackColor = Color.Red;
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(tBoxPotvrdaLozinke.Text))
            {
                tBoxPotvrdaLozinke.BackColor = Color.Red;
                valid = false;
            }
            if (tBoxLozinka.Text != tBoxPotvrdaLozinke.Text)
            {
                tBoxLozinka.BackColor = Color.Red;
                tBoxPotvrdaLozinke.BackColor = Color.Red;
                valid = false;
            }
            if (userOrAdmin)
            {
                if (string.IsNullOrWhiteSpace(tBoxSifra.Text))
                {
                    tBoxSifra.BackColor = Color.Red;
                    valid = false;
                }
                else if (tBoxSifra.Text != "123456")
                {
                    tBoxSifra.BackColor = Color.Red;
                    valid = false;
                }
            }

            if (valid)
            {
                imeprezime = tBoxImePrezime.Text;
                username = tBoxUsername.Text;
                email = tBoxEmail.Text;
                password = tBoxLozinka.Text;
                user ubaciUsera = new user();

                if (_loginForma.userList.Count() > 0)
                {
                    ubaciUsera.generateUser((_loginForma.userList.Last()._idNaloga + 1), imeprezime, username, email, password, userOrAdmin ? "admin" : "user");
                }
                else
                {
                    ubaciUsera.generateUser(1, imeprezime, username, email, password, userOrAdmin ? "admin" : "user");
                }

                _loginForma.userList.Add(ubaciUsera);
                string jsonText = JsonConvert.SerializeObject(_loginForma.userList, Formatting.Indented);
                File.WriteAllText("users.json", jsonText);
                MessageBox.Show("Uspešno napravljen nalog! Možete se log inovati sad.");
                _loginForma.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ima grešaka u unosu podataka, molim vas ispravite sva crvena polja.");
            }
        }
    }
}
