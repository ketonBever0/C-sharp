using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace karacsonyCLI
{
    class Program
    {
        static void Main(string[] args)
        {

            //  3. feladat

            List<NapiMunka> zaroAdat = new List<NapiMunka>();

            try
            {
                var sorok = File.ReadAllLines("diszek.txt", Encoding.Default);

                for (int i = 0; i < sorok.Length; i++)
                {
                    zaroAdat.Add(new NapiMunka(sorok[i]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            //  4. feladat

            int angyalkaOssz = 0, harangOssz = 0, fenyofaOssz = 0;

            foreach (var i in zaroAdat)
            {
                angyalkaOssz += i.AngyalkaKesz;
                harangOssz += i.HarangKesz;
                fenyofaOssz += i.FenyofaKesz;
            }

            int osszDisz = angyalkaOssz + harangOssz + fenyofaOssz;

            //Console.WriteLine($"{angyalkaOssz} {harangOssz} {fenyofaOssz}");

            Console.WriteLine($"4. feladat: Összesen {osszDisz} darab dísz készült.");


            //  5. feladat

            List<NapiMunka> egyDiszSe = zaroAdat.FindAll(x => x.AngyalkaKesz == 0 && x.HarangKesz == 0 && x.FenyofaKesz == 0);

            //foreach(var i in egyDiszSe)
            //{
            //    Console.WriteLine($"{i.AngyalkaKesz} {i.HarangKesz} {i.FenyofaKesz}");
            //}

            Console.Write("\n5. feladat: ");

            if (egyDiszSe.Count == 0)
            {
                Console.WriteLine("Nem volt olyan nap, amikor egyetlen dísz se készült.");
            }
            else
            {
                Console.WriteLine("Volt olyan nap, amikor egyetlen dísz se készült.");
            }


            //  6. feladat

            Console.WriteLine("\n6. feladat:");

            int bekert = 50;


            while (bekert < 1 || bekert > 40)
            {
                Console.Write("Adja meg a keresett napot [1 ... 40]: ");
                bekert = Convert.ToInt32(Console.ReadLine());
            }

            angyalkaOssz = 0;
            harangOssz = 0;
            fenyofaOssz = 0;


            //int angyalkaMaradt = 0, harangMaradt = 0, fenyofaMaradt = 0;

            var nap = 0;
            foreach (var i in zaroAdat)
            {
                if (i.Nap <= bekert)
                {
                    angyalkaOssz += i.AngyalkaKesz;
                    angyalkaOssz += i.AngyalkaEladott;

                    harangOssz += i.HarangKesz;
                    harangOssz += i.HarangEladott;

                    fenyofaOssz += i.FenyofaKesz;
                    fenyofaOssz += i.FenyofaEladott;

                    nap = i.Nap;
                }
                else break;
            }

            Console.WriteLine($"\tA(z) {nap}. nap végén {harangOssz} harang, {angyalkaOssz} angyalka és {fenyofaOssz} fenyőfa maradt a készleten.");


            //  7. feladat


            int angyalkaEladottOssz = 0, harangEladottOssz = 0, fenyofaEladottOssz = 0;

            IDictionary<string, int> osszEladott = new Dictionary<string, int>();

            foreach (var i in zaroAdat)
            {
                angyalkaEladottOssz -= i.AngyalkaEladott;

                harangEladottOssz -= i.HarangEladott;

                fenyofaEladottOssz -= i.FenyofaEladott;
            }

            osszEladott.Add("Harang", harangEladottOssz);
            osszEladott.Add("Angyalka", angyalkaEladottOssz);
            osszEladott.Add("Fenyőfa", fenyofaEladottOssz);


            IDictionary<string, int> maxEladott = new Dictionary<string, int>();

            int maxErtek = 0;


            foreach (var i in osszEladott)
            {
                if (i.Value >= maxErtek)
                {
                    maxErtek = i.Value;
                }
            }

            foreach (var i in osszEladott)
            {
                if (i.Value == maxErtek)
                {
                    maxEladott.Add(i.Key, i.Value);
                }
            }

            Console.WriteLine($"7. feladat: Legtöbbet eladott dísz: {maxEladott.Max(x=>x.Value)} darab");


            foreach (var i in maxEladott)
            {
                //Console.WriteLine($"{i.Key}: {i.Value}");
                Console.WriteLine($"\t{i.Key}");

            }


            //  8. feladat


            


            int bevetel = 0;

            foreach (var i in zaroAdat)
            {
                
            }














        }
    }
}
