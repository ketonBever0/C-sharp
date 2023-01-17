using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBowl
{
    public class Helyezesek
    {
        public string Sorszam { get; set; }
        public string Datum { get; set; }
        public string Gyoztes { get; set; }
        public string Eredmeny { get; set; }
        public string Vesztes { get; set; }
        public string Helyszin { get; set; }
        public string VarosAllam { get; set; }
        public int Nezoszam { get; set; }




        public Helyezesek(string sor, char hatarolo)
        {

            var adat = sor.Split(hatarolo);

            Sorszam = adat[0];
            Datum = adat[1];
            Gyoztes = adat[2];
            Eredmeny = adat[3];
            Vesztes = adat[4];
            Helyszin = adat[5];
            VarosAllam = adat[6];
            Nezoszam = Convert.ToInt32(adat[7]);




        }






    }
}
