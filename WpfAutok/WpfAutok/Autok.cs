using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAutok
{
    class Autok
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Tipus { get; set; }
        public int Evjarat { get; set; }
        public string Uzem { get; set; }
        public int Hengerurtartalom { get; set; }
        public int Teljesitmeny { get; set; }
        public int FutottKm { get; set; }
        public int Ar { get; set; }

        public Autok(string line, char splitChar)
        {
            var data = line.Split(splitChar);
            Id = Convert.ToInt32(data[0]);
            Marka = data[1];
            Tipus = data[2];
            Evjarat = Convert.ToInt32(data[3]);
            Uzem = data[4];
            Hengerurtartalom = Convert.ToInt32(data[5]);
            Teljesitmeny = Convert.ToInt32(data[6]);
            FutottKm = Convert.ToInt32(data[7]);
            Ar = Convert.ToInt32(data[8]);
        }
    }
}
