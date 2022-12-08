using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace szamok
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            List<string> a_fajl = new List<string>();
            var text = "";

            try
            {
                text = File.ReadAllText("szamok_a.txt", Encoding.UTF8);

                var spliteltText = text.Split();

                for (int i = 0; i < spliteltText.Length; i++)
                {
                    a_fajl.Add(spliteltText[i]);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); 
            }




            var idk = text.Length;

            for (int i = 0; i < idk; i++)
            {
                for (int j = 0; j < idk; j++)
                {
                    Console.WriteLine(text.Substring(i,j));         //Substring(kezdőérték, lépésszám)
                    Console.WriteLine($"kezdő elem indexe: {i}");
                }
               idk--;       //eggyel kevesebb, mert az eredeti érték túlcsordulást okoz (ezt szűrtem le belőle)
            }




            Console.ReadKey();
        }
    }
}
