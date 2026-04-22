using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TVP_Proj1___Turisticka_Agencija
{
    public class user
    {
        public int _idNaloga { get; set; }
        public string _ime { get; set; }
        public string _prezime { get; set; }
        public string _username { get; set; } // kako glupo, moraju getteri i setteri za json da ne buljezga
        public string _email { get; set; }
        public string _password { get; set; }
        public string _accountType { get; set; }

        public void generateUser(int idNaloga, string imePrezime, string username, string email, string password, string accountType)
        {
            string[] punoIme = imePrezime.Split(' ');
            _idNaloga = idNaloga;
            _ime = punoIme[0];
            _prezime = punoIme[1];
            _username = username;
            _email = email;
            _password = password;
            _accountType = accountType;
        }

        public int readUsers(BindingList<user> userList)
        {
            string jsonText = null;
            try
            {
                /*Ako fajl postoji i uspe da se izvrsi File.ReadAllText(), citamo i pravimo userList
                 */
                jsonText = File.ReadAllText("users.json");

                List<user> tmpUserList = JsonConvert.DeserializeObject<List<user>>(jsonText);
                foreach (user _user in tmpUserList) 
                {
                    userList.Add(_user);
                }

                return 0;
            }
            catch(FileNotFoundException)
            {
                /* Ako fajl ne postoji, kreiramo prazan List<user> objekat, serijalizujemo ga kao takvog,
                 * i posaljemo sa File.WriteAllText() cisto da se kreira novi fajl.
                 */
                List<user> emptyUserList = new List<user>();
                jsonText = JsonConvert.SerializeObject(emptyUserList);
                File.WriteAllText("users.json", jsonText);

                return 0;
            }
            catch
            {
                MessageBox.Show("Nevidjena greska!");

                return -1;
            }
        }

        public void debugConsoleWritelineUser(user User)
        {
            Console.WriteLine($"\n\nID: {User._idNaloga}\nIme: {User._ime}\nPrezime: {User._prezime}\nUsername: {User._username}\nEmail: {User._email}\nPassword: {User._password}\nAccountType: {User._accountType}\n\n");
        }
    }
}
