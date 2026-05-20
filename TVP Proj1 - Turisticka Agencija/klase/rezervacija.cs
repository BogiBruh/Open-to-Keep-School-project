using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVP_Proj1___Turisticka_Agencija;

namespace TVP_Proj1___Open_To_Rent.klase
{
    public enum statusRezervacije
    {
        Aktivna,
        Vracena
    }

    public class rezervacija
    {
        public int idRezervacije { get; set; }
        public int idKorisnika { get; set; }
        public int idIgre { get; set; }
        public DateTime datumRezervacije { get; set; }
        public DateTime datumVracanja { get; set; }
        public double cena { get; set; }
        public statusRezervacije status { get; set; }

        public void generateRezervacija(int idRezervacije, int idKorisnika, int idIgre, DateTime datumRezervacije, DateTime datumVracanja, double cena, statusRezervacije status)
        {
            this.idRezervacije = idRezervacije;
            this.idKorisnika = idKorisnika;
            this.idIgre = idIgre;
            this.datumRezervacije = datumRezervacije;
            this.datumVracanja = datumVracanja;
            this.cena = cena;
            this.status = status;
        }

        public int readRezervacije(BindingList<rezervacija> reservationList)
        {
            string jsonText = null;
            try
            {
                /*Ako fajl postoji i uspe da se izvrsi File.ReadAllText(), citamo i pravimo userList
                 */
                jsonText = File.ReadAllText("rezervacije.json");

                BindingList<rezervacija> tmpListaRezervacija = JsonConvert.DeserializeObject<BindingList<rezervacija>>(jsonText);
                foreach (rezervacija _rezervacija in tmpListaRezervacija)
                {
                    reservationList.Add(_rezervacija);
                }

                return 0;
            }
            catch (FileNotFoundException)
            {
                /* Ako fajl ne postoji, kreiramo prazan List<user> objekat, serijalizujemo ga kao takvog,
                 * i posaljemo sa File.WriteAllText() cisto da se kreira novi fajl.
                 */
                BindingList<rezervacija> emptyListaRezervacija = new BindingList<rezervacija>();
                jsonText = JsonConvert.SerializeObject(emptyListaRezervacija);
                File.WriteAllText("rezervacije.json", jsonText);

                return 0;
            }
            catch
            {
                MessageBox.Show("Nevidjena greska!");

                return -1;
            }
        }
    }
}
