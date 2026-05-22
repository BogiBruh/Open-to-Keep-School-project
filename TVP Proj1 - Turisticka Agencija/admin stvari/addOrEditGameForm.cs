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

namespace TVP_Proj1___Open_To_Rent.admin_stvari
{
    public partial class addOrEditGameForm : Form
    {
        string _svrha;
        adminPanel _parentForm;
        igra _igraZaUredjenje = null;
        public addOrEditGameForm()
        {
            InitializeComponent();
        }

        public addOrEditGameForm(string svrha, adminPanel parentForm)
        {
            InitializeComponent();
            _svrha = svrha;
            _parentForm = parentForm;
        }

        public addOrEditGameForm(string svrha, adminPanel parentForm, igra igraZaUredjenje)
        {
            InitializeComponent();
            _svrha = svrha;
            _parentForm = parentForm;
            _igraZaUredjenje = igraZaUredjenje;
        }

        private void addOrEditGameForm_Load(object sender, EventArgs e)
        {
            switch (_svrha)
            {
                case "dodaj":
                    labelNaslov.Text = "Dodaj igru";
                    this.Text = "Dodaj igru";
                    break;
                case "uredi":
                    labelNaslov.Text = "Uredi igru";
                    this.Text = "Uredi igru";

                    if (_igraZaUredjenje != null)
                    {
                        tBoxNazivIgre.Text = _igraZaUredjenje._gameName;
                        tBoxStudio.Text = _igraZaUredjenje._gameStudioName;
                        tBoxZanr.Text = _igraZaUredjenje._genre;
                        tBoxGodIzdavanja.Text = _igraZaUredjenje._releaseYear.ToString();
                        tBoxPlatforma.Text = _igraZaUredjenje._platformName;
                        tBoxOpis.Text = _igraZaUredjenje._description;
                        tBoxCena.Text = _igraZaUredjenje._price.ToString();
                        tBoxBrPrimeraka.Text = _igraZaUredjenje._numberOfCopies.ToString();
                        tBoxStarosnaGranica.Text = _igraZaUredjenje._ageRating.ToString();
                    }

                    break;
                default:
                    break;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            igra igraZaVracanje = new igra();
            bool valid = true;
            string nazivIgre = tBoxNazivIgre.Text;
            string studio = tBoxStudio.Text;
            string zanr = tBoxZanr.Text;
            string platforma = tBoxPlatforma.Text;
            string opis = tBoxOpis.Text;
            int godIzdavanja = 0;
            double cena = 0;
            int brPrimeraka = 0;
            int starosnaGranica = 0;

            // vracanje boja na default, radi lakseg ponovnog popunjavanja
            tBoxNazivIgre.BackColor = TextBox.DefaultBackColor;
            tBoxStudio.BackColor = TextBox.DefaultBackColor;
            tBoxZanr.BackColor = TextBox.DefaultBackColor;
            tBoxPlatforma.BackColor = TextBox.DefaultBackColor;
            tBoxOpis.BackColor = TextBox.DefaultBackColor;
            tBoxGodIzdavanja.BackColor = TextBox.DefaultBackColor;
            tBoxCena.BackColor = TextBox.DefaultBackColor;
            tBoxBrPrimeraka.BackColor = TextBox.DefaultBackColor;
            tBoxStarosnaGranica.BackColor = TextBox.DefaultBackColor;

            if (string.IsNullOrWhiteSpace(tBoxNazivIgre.Text))
            {
                tBoxNazivIgre.BackColor = Color.Red;
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(tBoxStudio.Text))
            {
                tBoxStudio.BackColor = Color.Red;
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(tBoxZanr.Text))
            {
                tBoxZanr.BackColor = Color.Red;
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(tBoxPlatforma.Text))
            {
                tBoxPlatforma.BackColor = Color.Red;
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(tBoxOpis.Text))
            {
                tBoxOpis.BackColor = Color.Red;
                valid = false;
            }

            if (!int.TryParse(tBoxGodIzdavanja.Text, out godIzdavanja) || godIzdavanja <= 1970)
            {
                tBoxGodIzdavanja.BackColor = Color.Red;
                valid = false;
            }

            if (!double.TryParse(tBoxCena.Text, out cena) || cena <= 0)
            {
                tBoxCena.BackColor = Color.Red;
                valid = false;
            }

            if (!int.TryParse(tBoxBrPrimeraka.Text, out brPrimeraka) || brPrimeraka < 0)
            {
                tBoxBrPrimeraka.BackColor = Color.Red;
                valid = false;
            }

            if (!int.TryParse(tBoxStarosnaGranica.Text, out starosnaGranica) || (starosnaGranica <= 0 || starosnaGranica > 18))
            {
                tBoxStarosnaGranica.BackColor = Color.Red;
                valid = false;
            }

            // ONE final decision
            if (!valid)
            {
                MessageBox.Show("Neke podatke niste uneli kako valja. Molim vas da ispravite sva crvena polja");
            }
            else
            {
                if (_svrha == "dodaj")
                {
                    if (_parentForm.gameList.Count() > 0)
                    {
                        igraZaVracanje.generisiIgru(_parentForm.gameList.Last()._idIgre + 1, nazivIgre, studio, zanr, godIzdavanja, platforma, opis,
                                                    cena, brPrimeraka, starosnaGranica);
                    }
                    else
                    {
                        igraZaVracanje.generisiIgru(1, nazivIgre, studio, zanr, godIzdavanja, platforma, opis, cena, brPrimeraka, starosnaGranica);
                    }
                    _parentForm.gameList.Add(igraZaVracanje);
                    MessageBox.Show("Uspešno dodata nova igra.");
                    this.Close();
                }
                else if (_svrha == "uredi")
                {
                    _igraZaUredjenje._gameName = nazivIgre;
                    _igraZaUredjenje._gameStudioName = studio;
                    _igraZaUredjenje._genre = zanr;
                    _igraZaUredjenje._releaseYear = godIzdavanja;
                    _igraZaUredjenje._platformName = platforma;
                    _igraZaUredjenje._description = opis;
                    _igraZaUredjenje._price = cena;
                    _igraZaUredjenje._numberOfCopies = brPrimeraka;
                    _igraZaUredjenje._ageRating = starosnaGranica;
                    MessageBox.Show("Podaci igrice su uspešno promenjeni.");
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
