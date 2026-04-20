using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_Proj1___Turisticka_Agencija
{
    public partial class loginForm : Form
    {
        public List<user> userList = new List<user>();

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
            MessageBox.Show("brao brao");

            this.Close();
        }
    }
}
