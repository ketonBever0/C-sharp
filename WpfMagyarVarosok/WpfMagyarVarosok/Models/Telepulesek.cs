using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WpfMagyarVarosok.Models
{
    public partial class Telepulesek
    {
        public int Id { get; set; }
        public int Irszam { get; set; }
        public string Nev { get; set; }
        public string Megyekod { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Kshkod { get; set; }
        public int Jogallas { get; set; }
        public int Terulet { get; set; }
        public int Nepesseg { get; set; }
        public int Lakasok { get; set; }

        public virtual Jogallas JogallasNavigation { get; set; }
        public virtual Megyek MegyekodNavigation { get; set; }
    }
}
