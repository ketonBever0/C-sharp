using System;
using MagyarorszagVarosai.Models;
using Microsoft.EntityFrameworkCore;

namespace MagyarorszagVarosai
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new magyar_telepulesekContext();
            context.Telepulesek.Load();
            context.Megyek.Load();
            context.Jogallas.Load();


            foreach (var i in context.Megyek.Local)
            {
                Console.WriteLine($"{i.Nev}, {i.Telepulesek}");
            }

            foreach (var i in context.Jogallas.Local)
            {
                Console.WriteLine($"{i.Jogallas1}, {i.Telepulesek}");
            }

            foreach (var i in context.Telepulesek.Local)
            {
                Console.WriteLine($"{i.Nev}, {i.Nepesseg}, {i.JogallasNavigation.Jogallas1}");
            }



            Console.ReadKey();
        }
    }
}
