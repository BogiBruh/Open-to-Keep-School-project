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
        public DateTime datumRezervacije { get; set; }
        public DateTime datumVracanja { get; set; }
        public double cenaRezervacije { get; set; }
        public statusRezervacije status { get; set; }

        public prikazRezervacije()
        {
            idRezervacije = 0;
            gameName = "";
            genre = "";
            platform = "";
            datumRezervacije = DateTime.Now;
            datumVracanja = DateTime.Now;
            cenaRezervacije = 0;
            status = statusRezervacije.Vracena;
        }

        public prikazRezervacije(int idRezervacije, string gameName, string genre, string platform, double cenaRezervacije, DateTime datumRezervacije, DateTime datumVracanja, statusRezervacije status)
        {
            this.idRezervacije = idRezervacije;
            this.gameName = gameName;
            this.genre = genre;
            this.platform = platform;
            this.cenaRezervacije = cenaRezervacije;
            this.datumRezervacije = datumRezervacije;
            this.datumVracanja = datumVracanja;
            this.status = status;
        }
    }
}
