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
            MessageBox.Show("ovde ce se raditi:\n\nprovera podudaranja lozinke\ndodeljivanje Ida\nzapis u json\nzatvaranje prozora");

            string prvaLozinka = tBoxLozinka.Text;
            string drugaLozinka = tBoxPotvrdaLozinke.Text;
            if(prvaLozinka == drugaLozinka)
            {
                user ubaciUsera = new user();
                ubaciUsera.generateUser((_loginForma.userList.Count + 1), tBoxImePrezime.Text, tBoxUsername.Text, tBoxEmail.Text, tBoxLozinka.Text, "admin");
                
                _loginForma.userList.Add(ubaciUsera);

                string jsonText = JsonConvert.SerializeObject(_loginForma.userList, Formatting.Indented);
                File.WriteAllText("users.json", jsonText);
            }

            _loginForma.Show();
            this.Close();
        }
    }
}
