using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVP_Proj1___Open_To_Rent.klase;

namespace TVP_Proj1___Open_To_Rent.user_stvari
{
    public class prikazRezervacije
    {
        public int idRezervacije { get; set; }
        public string gameName { get; set; }
        public string genre { get; set; }
        public string platform { get; set; }
        public int brKopija { get; set; }
        public DateTime datumRezervacije { get; set; }
        public DateTime datumVracanja { get; set; }
        public statusRezervacije status { get; set; }

        public prikazRezervacije()
        {
            idRezervacije = 0;
            gameName = "";
            genre = "";
            platform = "";
            brKopija = 0;
            datumRezervacije = DateTime.Now;
            datumVracanja = DateTime.Now;
            status = statusRezervacije.Vracena;
        }

        public prikazRezervacije(int idRezervacije, string gameName, string genre, string platform, int brKopija, DateTime datumRezervacije, DateTime datumVracanja, statusRezervacije status)
        {
            this.idRezervacije = idRezervacije;
            this.gameName = gameName;
            this.genre = genre;
            this.platform = platform;
            this.brKopija = brKopija;
            this.datumRezervacije = datumRezervacije;
            this.datumVracanja = datumVracanja;
            this.status = status;
        }
    }
}
