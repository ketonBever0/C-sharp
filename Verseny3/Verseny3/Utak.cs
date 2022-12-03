using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verseny3
{
    public class Utak
    {

        public int VSzam { get; set; }
        public char Csucs { get; set; }
        public string Iranyok { get; set; }


        public Utak(string sor, char hatarolo)
        {
            var adat = sor.Split(hatarolo);
            VSzam = Convert.ToInt32(adat[0]);
            Csucs = Convert.ToChar(adat[1]);




            for (int i = 2; i < adat.Length; i++)
            {
                string ezmi = adat[i];
                Iranyok += ezmi;
            }





        }






    }
}
