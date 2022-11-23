using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verseny2
{
    class Program
    {

        static bool PrimeCheck(int number)
        {
            int a = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    a++;
                }
            }
            if (a <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {



            //  1. feladat
            //  A)

            int truncated, primeNums = 0;

            for (int i = 10; i < 100; i++)
            {
                truncated = Int32.Parse(i.ToString().Remove(0, 1));
                if (PrimeCheck(truncated))
                {
                    primeNums++;
                }


            }

            if (primeNums == 0)
            {
                Console.WriteLine("There are no truncatable prime numbers between 10 and 100.");
            }
            else if (primeNums == 1)
            {
                Console.WriteLine($"There there is {primeNums} truncatable prime numbers between 10 and 100.");
            }
            else
            {
                Console.WriteLine($"There are {primeNums} truncatable prime numbers between 10 and 100.");
            }

            System.Threading.Thread.Sleep(2000);

            //  B)

            int truncated2;
            var primeNums2 = new List<int>();

            Console.WriteLine("Please wait. It will take some time...");

            for (int i = 100000; i < 300000; i++)
            {
                if (PrimeCheck(i))
                {
                    truncated2 = Int32.Parse(i.ToString().Remove(0, 1));
                    //Console.WriteLine(i);
                    if (PrimeCheck(truncated2))
                    {
                        primeNums2.Add(truncated2);
                    }
                }

            }

            //Console.WriteLine($"The largest truncatable prime number between 100 000 and 300 000 is {primeNums2.Max()}.");


            //  C)

            int primeNums3 = 0;


            for (int i = 100000; i <= 999999; i++)
            {
                if (PrimeCheck(i))
                {
                    Console.WriteLine(i);
                    if (PrimeCheck(i))
                    {
                        primeNums3++;
                    }
                }

            }

            Console.WriteLine($"B)\nThe largest truncatable prime number between 100 000 and 300 000 is {primeNums2.Max()}.\n");

            Console.WriteLine($"C)\nThe amount of 5 digit prime number is {primeNums2.Max()}.\n");


        }







    }
}
