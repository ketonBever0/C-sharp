using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SuperBowl
{
    class Program
    {

        public static int RomanToDecimal(string szam)
        {
            var arab = 0;
            for (int i = 0; i < szam.Length;i++)
            {
                if(i>0 && Romai(szam[i]) > Romai(szam[i - 1]))
                {
                    arab += Romai(szam[i]) - Romai(szam[i-1])*2;
                }
                else
                {
                    arab += Romai(szam[i]);
                }
            }
            return arab;
        }

        public static int Romai(char elem)
        {
            switch (elem)
            {
                case 'I':return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return 0;
            }
        }




        static void Main(string[] args)
        {
            List<Helyezesek> helyezesek = new List<Helyezesek>();

            //  3

            string fejlec = "";

            try
            {
                var sorok = File.ReadAllLines("SuperBowl.txt", Encoding.UTF8);

                fejlec = sorok[0];
                for(int i = 1; i < sorok.Length;i++)
                {
                    helyezesek.Add(new Helyezesek(sorok[i], ';'));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            //  4
            Console.WriteLine($"4. feladat: {helyezesek.Count}");


            //  5

            List<int> pontKulombsegek= new List<int>();


            foreach(var i in helyezesek)
            {
                string[] eredmenyPontok= i.Eredmeny.Split('-');
                pontKulombsegek.Add(Convert.ToInt32(eredmenyPontok[0]) - Convert.ToInt32(eredmenyPontok[1]));
            }

            //foreach (var i in pontKulombsegek)
            //{
            //    Console.WriteLine(i);
            //}


            Console.WriteLine($"5. feladat: {Math.Round(pontKulombsegek.Average(),2)}");



            //  6

            List<int> nezoszamok = new List<int>();
            foreach (var i in helyezesek)
            {
                nezoszamok.Add(i.Nezoszam);
            }


            var maxNezo = helyezesek.Find(x=>x.Nezoszam==nezoszamok.Max());

            Console.WriteLine($"6. feladat:\n\tLegtöbb néző: {maxNezo.Nezoszam}\n\tHelyezés: {RomanToDecimal(maxNezo.Sorszam)}.\n\tCsapat: {maxNezo.Gyoztes}\n\tPontszám: {maxNezo.Eredmeny.Substring(0,maxNezo.Eredmeny.IndexOf('-'))}");



            //  7

            List<string> reszvetelSzamok = new List<string>();

            int elofordulas = 1;
            List<string> voltmar = new List<string>();

            using (StreamWriter sw = new StreamWriter(new FileStream("SuperBowlNew.txt",FileMode.Open),Encoding.UTF8))
            {
                sw.WriteLine(fejlec);
                foreach (var i in helyezesek)
                {
                    voltmar.Add(i.Gyoztes);
                    voltmar.Add(i.Vesztes);

                    sw.WriteLine($"{RomanToDecimal(i.Sorszam)}.;{i.Datum};{i.Gyoztes} ({voltmar.Where(x=>x.Contains(i.Gyoztes)).Count()});{i.Eredmeny};{i.Vesztes} ({voltmar.Where(x=>x.Contains(i.Vesztes)).Count()});{i.VarosAllam};{i.Nezoszam}");
                }
            }

            Console.WriteLine("7. feladat: Fájl kész!");







        }
    }
}
