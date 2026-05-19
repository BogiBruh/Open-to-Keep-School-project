using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_Proj1___Turisticka_Agencija
{
    public class igra
    {
        public int _idIgre { get; set; }
        public string _gameName { get; set; }
        public string _gameStudioName { get; set; }
        public string _genre { get; set; }
        public int _releaseYear { get; set; }
        public string _platformName { get; set; }
        public string _description { get; set; }
        public double _price { get; set; }
        public int _numberOfCopies { get; set; }
        public int _ageRating { get; set; }

        public void generisiIgru(int idIgre, string gameName, string gameStudioName, string genre, int releaseYear, string platformName, string description, double price, int numberOfCopies, int ageRating)
        {
            _idIgre = idIgre;
            _gameName = gameName;
            _gameStudioName = gameStudioName;
            _genre = genre;
            _releaseYear = releaseYear;
            _platformName = platformName;
            _description = description;
            _price = price;
            _numberOfCopies = numberOfCopies;
            _ageRating = ageRating;
        }

        public int readGames(BindingList<igra> gameList)
        {
            string jsonText = null;
            try
            {
                /*Ako fajl postoji i uspe da se izvrsi File.ReadAllText(), citamo i pravimo userList
                 */
                jsonText = File.ReadAllText("igre.json");

                List<igra> tmpListaIgara = JsonConvert.DeserializeObject<List<igra>>(jsonText);
                foreach (igra _igra in tmpListaIgara)
                {
                    gameList.Add(_igra);
                }

                return 0;
            }
            catch (FileNotFoundException)
            {
                /* Ako fajl ne postoji, kreiramo prazan List<user> objekat, serijalizujemo ga kao takvog,
                 * i posaljemo sa File.WriteAllText() cisto da se kreira novi fajl.
                 */
                List<igra> emptyListaIgara = new List<igra>();
                jsonText = JsonConvert.SerializeObject(emptyListaIgara);
                File.WriteAllText("igre.json", jsonText);

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
