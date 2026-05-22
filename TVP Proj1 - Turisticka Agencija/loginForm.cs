using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVP_Proj1___Open_To_Rent.user_stvari;

namespace TVP_Proj1___Turisticka_Agencija
{
    public partial class loginForm : Form
    {
        public BindingList<user> userList = new BindingList<user>();

        public loginForm()
        {
            InitializeComponent();

        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            user tempObjekatZaCitanje = new user();
            int citanje = tempObjekatZaCitanje.readUsers(userList);

            if(citanje == -1)
            {
                MessageBox.Show("Nešto nije uredu(problem sa citanjem fajlova).");
                this.Close();
            }
        }

        private void labelPrijava_MouseHover(object sender, EventArgs e)
        {
            labelPrijava.ForeColor = SystemColors.ControlText;
            labelPrijava.Cursor = Cursors.Hand;
        }

        private void labelPrijava_MouseLeave(object sender, EventArgs e)
        {
            labelPrijava.ForeColor = SystemColors.ControlDarkDark;
        }

        private void labelPrijava_Click(object sender, EventArgs e)
        {
            signUpForm signUp = new signUpForm(this);
            this.Hide();
            signUp.Show();
            //MessageBox.Show("brao, sta sad");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string attemptedEmail = tBoxEmail.Text;
            string attemptedPassword = tBoxPassword.Text;

            bool uspesnaPrijava = false;
            user loggedIn = null;

            foreach (user u in userList)
            {
                if(u._email == attemptedEmail && u._password == attemptedPassword)
                {
                    Console.WriteLine($"Uspešna prijava {attemptedEmail} == {u._email} i {attemptedPassword} == {u._password}\n");
                   
                    uspesnaPrijava = true;
                    loggedIn = u;

                    break;
                }
                else
                {
                    Console.WriteLine($"Pokusan {attemptedEmail} != {u._email} i {attemptedPassword} != {u._password}\n");
                }
            }
            if (!uspesnaPrijava)
            {
                MessageBox.Show("Neuspešna prijava. Proverite unete podatke i pokušajte ponovo.");
            }
            else if(loggedIn != null && loggedIn._accountType == "user")
            {
                userPanel user = new userPanel(loggedIn._idNaloga, this);
                // kada se logoutujemo da nema vise podataka od proslog logina
                tBoxEmail.Text = "";
                tBoxPassword.Text = "";
                tBoxEmail.Focus();
                user.Show();
                this.Hide();
            }
            else if(loggedIn != null && loggedIn._accountType == "admin")
            {
                adminPanel admin = new adminPanel(userList, this, loggedIn);
                tBoxEmail.Text = "";
                tBoxPassword.Text = "";
                tBoxEmail.Focus();
                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nešto je negde crklo.");
            }
        }
    }
}
