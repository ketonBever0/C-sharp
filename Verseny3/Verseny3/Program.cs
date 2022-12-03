using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Verseny3
{
    class Program
    {
        static void Main(string[] args)
        {


            //  2. feladat

            List<Utak> utak = new List<Utak>();

            try
            {
                var sorok = File.ReadAllLines("utak.txt", Encoding.Default);

                for (int i = 0; i < sorok.Length; i++)
                {
                    utak.Add(new Utak(sorok[i], ' '));
                }
                //Console.WriteLine($"Sorok száma: {utak.Count}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            //foreach (var i in utak)
            //{
            //    Console.WriteLine(i.VSzam);
            //    Console.WriteLine(i.Csucs);
            //    Console.WriteLine(i.Iranyok);
            //}


            //  A)


            char[] Ajo = { '1', '2', '3' };
            List<char> AjoList = new List<char>(Ajo);

            char[] Bjo = { '2', '3', '4' };
            List<char> BjoList = new List<char>(Bjo);

            char[] Cjo = { '3', '4', '5' };
            List<char> CjoList = new List<char>(Cjo);

            char[] Djo = { '3', '5', '1' };
            List<char> DjoList = new List<char>(Djo);

            char[] Ejo = { '1', '2', '6' };
            List<char> EjoList = new List<char>(Ejo);

            char[] Fjo = { '2', '4', '6' };
            List<char> FjoList = new List<char>(Fjo);

            char[] Gjo = { '4', '5', '6' };
            List<char> GjoList = new List<char>(Gjo);

            char[] Hjo = { '5', '6', '1' };
            List<char> HjoList = new List<char>(Hjo);


            int helyesLepesek = 0;
            int osszesCsucsonJart = 0;
            int osszesElenJart = 0;
            


            foreach (var i in utak)
            {
                char allas = i.Csucs;
                var mostani = i.Iranyok;
                bool jolepes = true;

                int jartAcsucson = 0;
                int jartBcsucson = 0;
                int jartCcsucson = 0;
                int jartDcsucson = 0;
                int jartEcsucson = 0;
                int jartFcsucson = 0;
                int jartGcsucson = 0;
                int jartHcsucson = 0;


                //  AB  DC  EF  FG  HG  AD  BC  EH  AE  BF  DH  CG

                int jartABelen = 0;
                int jartDCelen = 0;
                int jartEFelen = 0;
                int jartFGelen = 0;
                int jartHGelen = 0;
                int jartADelen = 0;
                int jartBCelen = 0;
                int jartEHelen = 0;
                int jartAEelen = 0;
                int jartBFelen = 0;
                int jartDHelen = 0;
                int jartCGelen = 0;


                for (int j = 0; j < mostani.Length; j++)
                {
                    if (allas == 'A' && AjoList.Contains(mostani[j]))
                    {
                        switch (mostani[j])
                        {
                            case '1':
                                allas = 'B';
                                jartABelen++;
                                break;
                            case '2':
                                allas = 'D';
                                jartADelen++;
                                break;
                            case '3':
                                allas = 'E';
                                jartAEelen++;
                                break;
                        }
                        jartAcsucson++;
                    }
                    else if (allas == 'B' && BjoList.Contains(mostani[j]))
                    {
                        switch (mostani[j])
                        {
                            case '2':
                                allas = 'C';
                                jartBCelen++;
                                break;
                            case '3':
                                allas = 'F';
                                jartBFelen++;
                                break;
                            case '4':
                                allas = 'A';
                                jartABelen++;
                                break;
                        }
                        jartBcsucson++;
                    }
                    else if (allas == 'C' && CjoList.Contains(mostani[j]))
                    {
                        switch (mostani[j])
                        {
                            case '3':
                                allas = 'G';
                                jartCGelen++;
                                break;
                            case '4':
                                allas = 'D';
                                jartDCelen++;
                                break;
                            case '5':
                                allas = 'B';
                                jartBCelen++;
                                break;
                        }
                        jartCcsucson++;
                    }
                    else if (allas == 'D' && DjoList.Contains(mostani[j]))
                    {
                        switch (mostani[j])
                        {
                            case '3':
                                allas = 'H';
                                jartDHelen++;
                                break;
                            case '5':
                                allas = 'A';
                                jartADelen++;
                                break;
                            case '1':
                                allas = 'C';
                                jartDCelen++;
                                break;
                        }
                        jartDcsucson++;
                    }
                    else if (allas == 'E' && EjoList.Contains(mostani[j]))
                    {
                        switch (mostani[j])
                        {
                            case '1':
                                allas = 'F';
                                jartEFelen++;
                                break;
                            case '2':
                                allas = 'H';
                                jartEHelen++;
                                break;
                            case '6':
                                allas = 'A';
                                jartAEelen++;
                                break;
                        }
                        jartEcsucson++;
                    }
                    else if (allas == 'F' && FjoList.Contains(mostani[j]))
                    {
                        switch (mostani[j])
                        {
                            case '2':
                                allas = 'G';
                                jartFGelen++;
                                break;
                            case '4':
                                allas = 'E';
                                jartEFelen++;
                                break;
                            case '6':
                                allas = 'B';
                                jartEFelen++;
                                break;
                        }
                        jartFcsucson++;
                    }
                    else if (allas == 'G' && GjoList.Contains(mostani[j]))
                    {
                        switch (mostani[j])
                        {
                            case '4':
                                allas = 'H';
                                jartHGelen++;
                                break;
                            case '5':
                                allas = 'F';
                                jartFGelen++;
                                break;
                            case '6':
                                allas = 'C';
                                jartCGelen++;
                                break;
                        }
                        jartGcsucson++;
                    }
                    else if (allas == 'H' && HjoList.Contains(mostani[j]))
                    {
                        switch (mostani[j])
                        {
                            case '5':
                                allas = 'E';
                                jartEHelen++;
                                break;
                            case '6':
                                allas = 'D';
                                jartDHelen++;
                                break;
                            case '1':
                                allas = 'G';
                                jartHGelen++;
                                break;
                        }
                        jartHcsucson++;
                    }
                    else
                    {
                        jolepes = false;
                        break;
                        //  Ha rossz a lépés, akkor jelenlegi lépéssorozat vizsgálata megszakad.
                    }                

                }

                if (jolepes)
                {
                    helyesLepesek++;
                    if(jartAcsucson>0 && jartBcsucson> 0 && jartCcsucson > 0 && jartDcsucson > 0 && jartEcsucson > 0 && jartFcsucson > 0 && jartGcsucson > 0 && jartHcsucson > 0)
                    {
                        osszesCsucsonJart++;
                    }
                    if (jartABelen > 0 && jartDCelen > 0 && jartEFelen > 0 && jartFGelen > 0 && jartHGelen > 0 && jartADelen > 0 && jartBCelen > 0 && jartEHelen > 0 && jartAEelen > 0 && jartBFelen > 0 && jartDHelen > 0 && jartCGelen > 0)
                    {
                        osszesElenJart++;
                    }
                }

            }

            Console.WriteLine($"\n2. feladat\n\n\tA)\n\t{helyesLepesek} helyes lépés szerepel.");

            Console.WriteLine($"\n\tB)\n\t{osszesCsucsonJart} alkalommal járt minden csúcson.");

            Console.WriteLine($"\n\tC)\n\t{osszesElenJart} alkalommal járt minden élen.");






            Console.WriteLine("\n\n\n");
        }
    }
}
