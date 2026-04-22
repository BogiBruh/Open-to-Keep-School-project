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
    public class izlet
    {
        public int _idIzleta {  get; set; }
        public string _mesto { get; set; }
        public string _drzava { get; set; }
        public double _cena { get; set; }
        public double _popust { get; set; }
        public int _brDana { get; set; }
        public int _brMesta { get; set; }
        public DateTime _datum { get; set; }

        public void generateIzlet(int idIzleta, string mesto, string drzava, double cena, double popust, int brDana, int brMesta, DateTime datum)
        {
            _idIzleta = idIzleta;
            _mesto = mesto;
            _drzava = drzava;
            _cena = cena;
            _popust = popust;
            _brDana = brDana;
            _brMesta = brMesta;
            _datum = datum;
        }

        public int readIzletFile(BindingList<izlet> izletList)
        {
            string jsonText = null;
            try
            {
                /*Ako fajl postoji i uspe da se izvrsi File.ReadAllText(), citamo i pravimo izletList
                 */
                jsonText = File.ReadAllText("izleti.json");

                List<izlet> tmpIzletList = JsonConvert.DeserializeObject<List<izlet>>(jsonText);
                foreach(var izlet in tmpIzletList)
                {
                    izletList.Add(izlet);
                }

                return 0;
            }
            catch (FileNotFoundException)
            {
                /* Ako fajl ne postoji, kreiramo prazan List<izlet> objekat, serijalizujemo ga kao takvog,
                 * i posaljemo sa File.WriteAllText() cisto da se kreira novi fajl.
                 */
                List<izlet> emptyIzletList = new List<izlet>();
                jsonText = JsonConvert.SerializeObject(emptyIzletList);
                File.WriteAllText("izleti.json", jsonText);

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
