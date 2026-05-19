using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            tBoxSifra.Visible = false;
            btnSignUp.Location = new Point(btnSignUp.Location.X, 510);
            userOrAdmin = false;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            tBoxSifra.Visible = true;
            btnSignUp.Location = new Point(btnSignUp.Location.X, 600);
            userOrAdmin = true;
        }

        private void btnSignUp_Click(object sender, EventArgs e) //TODO: validiranje da li je sve popunjeno kao prvo, i crash prevention za imePrezime index out of bounds
        {
            bool imejlIspravan = false;
            bool lozinkaIspravna = false; // mozda dodam mozda ne
            bool lozinkeIste = false;
            bool sifraIspravna = false;

            string imejl = tBoxEmail.Text;
            if (imejl.Length <= 10)
            {
                tBoxEmail.BackColor = Color.Red;
            }
            else if(imejl.Substring(imejl.Length - 10) != "@gmail.com")
            {
                tBoxEmail.BackColor = Color.Red;
            }
            else
            {
                imejlIspravan = true;
            }
    
            string prvaLozinka = tBoxLozinka.Text;
            string drugaLozinka = tBoxPotvrdaLozinke.Text;
            if (prvaLozinka == drugaLozinka)
            {
                lozinkeIste = true;
            }
            else
            {
                tBoxLozinka.BackColor = Color.Red;
                tBoxPotvrdaLozinke.BackColor = Color.Red;
            }

            int sifra;
            if (int.TryParse(tBoxSifra.Text, out sifra))
            {
                if (sifra == 123456)
                {
                    sifraIspravna = true;
                }
                else
                {
                    tBoxSifra.BackColor = Color.Red;
                }
            }
            else
            {
                tBoxSifra.BackColor = Color.Red;
            }

            //sada if ako se sve podudara
            if (userOrAdmin)
            {
                if (imejlIspravan && lozinkeIste && sifraIspravna)
                {
                    user ubaciUsera = new user();
                    if (_loginForma.userList.Count() > 0)
                    {
                        ubaciUsera.generateUser((_loginForma.userList.Last()._idNaloga + 1), tBoxImePrezime.Text, tBoxUsername.Text, tBoxEmail.Text, tBoxLozinka.Text, "admin");
                    }
                    else
                    {
                        ubaciUsera.generateUser(1, tBoxImePrezime.Text, tBoxUsername.Text, tBoxEmail.Text, tBoxLozinka.Text, "admin");
                    }

                    _loginForma.userList.Add(ubaciUsera);

                    string jsonText = JsonConvert.SerializeObject(_loginForma.userList, Formatting.Indented);
                    File.WriteAllText("users.json", jsonText);

                    _loginForma.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Neka polja nisu ispravno popunjena, proverite vrednosti u crvenim poljima i pokušajte ponovo!");
                }
            }
            else
            {
                if (imejlIspravan && lozinkeIste)
                {
                    user ubaciUsera = new user();
                    if (_loginForma.userList.Count() > 0)
                    {
                        ubaciUsera.generateUser((_loginForma.userList.Last()._idNaloga + 1), tBoxImePrezime.Text, tBoxUsername.Text, tBoxEmail.Text, tBoxLozinka.Text, "user");
                    }
                    else
                    {
                        ubaciUsera.generateUser(1, tBoxImePrezime.Text, tBoxUsername.Text, tBoxEmail.Text, tBoxLozinka.Text, "user");
                    }

                    _loginForma.userList.Add(ubaciUsera);

                    string jsonText = JsonConvert.SerializeObject(_loginForma.userList, Formatting.Indented);
                    File.WriteAllText("users.json", jsonText);

                    _loginForma.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Neka polja nisu ispravno popunjena, proverite vrednosti u crvenim poljima i pokušajte ponovo!");
                }
            }
        }
    }
}
