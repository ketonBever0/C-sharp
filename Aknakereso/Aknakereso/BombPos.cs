using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aknakereso
{
    class BombPos
    {

        public class Pos
        {


            public int sor { get; set; }
            public int oszlop { get; set; }

            public Pos(int sor, int oszlop)
            {
                this.sor = sor;
                this.oszlop = this.oszlop;
            }


        }

        private List<Pos> bombapoziciok = new List<Pos>();
        public List<Pos> bombak
        {
            get { return bombapoziciok; }

        }

        Random rand = new Random();

        public BombPos(int sorSzam, int oszlopSzam, int darabszam)
        {
            for (int i = 0; i < darabszam; i++)
            {
                var randSor = rand.Next(0, sorSzam + 1);
                var randOszlop = rand.Next(0, oszlopSzam + 1);

                while (bombapoziciok.Any(x=>x.sor==randSor && x.oszlop == randOszlop))
                {
                    randSor = rand.Next(0, sorSzam + 1);
                    randOszlop = rand.Next(0, oszlopSzam + 1);
                }
                bombapoziciok.Add(new Pos(randSor, randOszlop));
            }
        }

    }
}
