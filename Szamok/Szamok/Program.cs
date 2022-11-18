using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamok
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. feladat\n");

            var sor = File.ReadAllText("szamok.txt", Encoding.Default);

            //  A)
            int nullaCount = sor.Count(f=>(f=='0'));
            Console.WriteLine($"A)\nA fájlban {nullaCount} nulla található.\n");

            //  B)
            List<string> negyjegyuek = new List<string>();
            for (int i = 0; i < sor.Length; i += 4)
            {
                if (sor.Substring(sor[i], 4).ToString().Substring(0,1)=="0")
                {
                    i -= 2;
                    continue;
                }
                else
                {
                    negyjegyuek.Add(sor.Substring(sor[i], 4));
                }
                
                

                

                

            }


            //Console.WriteLine(negyjegyuek.Count);
            //for(int i = 0; i < negyjegyuek.Count; i++)
            //{
            //    Console.WriteLine(negyjegyuek[i]);
            //}


            Console.WriteLine($"\nB)\nA számsorozatból {negyjegyuek.Count} négyjegyű szám készíthető.\n");

            //  C)
            List<string> primek = new List<string>();

            for (int i = 0; i < negyjegyuek.Count; i++)
            {
                if(negyjegyuek[i])
            }


        }
    }
}
