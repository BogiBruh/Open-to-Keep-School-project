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

        public signUpForm()
        {
            InitializeComponent();
        }

        public signUpForm(loginForm loginForma)
        {
            InitializeComponent();
            _loginForma = loginForma;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("za sad ne radi, vratite se kasnije!");
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("za sad samo ovaj radi!");
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            bool imejlIspravan = false;
            bool lozinkaIspravna = false; // mozda dodam mozda ne
            bool lozinkeIste = false;
            bool sifraIspravna = false;

            string imejl = tBoxEmail.Text;
            if (imejl.Substring(imejl.Length - 10) != "@gmail.com")
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
    }
}
