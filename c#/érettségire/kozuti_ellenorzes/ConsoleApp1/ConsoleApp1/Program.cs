using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        class Adat
        {
            public DateTime ido { get; set; }
            public string rendszam { get; set; }

            public Adat(DateTime a, string b)
            {
                ido = a;
                rendszam = b;
            }
            public Adat()
            {

            }
        }
        static void Main(string[] args)
        {
            string[] s = System.IO.File.ReadAllLines("jarmu.txt");
            List<Adat> x = new List<Adat>();

            foreach (var item in s)
            {
                string[] tempSplit = item.Split(' ');
                Adat tempAdat = new Adat();
                tempAdat.ido = new DateTime(1, 1, 1, int.Parse(tempSplit[0]), int.Parse(tempSplit[1]), int.Parse(tempSplit[2]));
                tempAdat.rendszam = tempSplit[3];
                x.Add(tempAdat);
            }
            x.OrderBy(kk => kk.ido);

            //1. feladat
            Console.WriteLine("1. feladat");

            //2. feladat
            {
                Console.WriteLine();
                Console.WriteLine("2. feladat");
                DateTime lowest = x.Min(kk => kk.ido);
                DateTime highest = x.Max(kk => kk.ido);
                float smt = (highest.Hour * 360 + highest.Minute * 60 + highest.Second) - (lowest.Hour * 360 + lowest.Minute * 60 + lowest.Second);
                Console.WriteLine(smt / 360);
            }

            //3. feladat
            {
                Console.WriteLine();
                Console.WriteLine("3. feladat");
                for (int i = 0; i < 24; i++)
                {
                    if (x.Where(kk => kk.ido.Hour == i).Count() == 0)
                        continue;

                    DateTime temp = x.Where(kk => kk.ido.Hour == i).Min(kk => kk.ido);
                    foreach (var item in x.Where(kk => kk.ido.Hour == i))
                    {
                        if (item.ido == temp)
                        {
                            Console.WriteLine(i + ". óra: " + item.rendszam);
                            break;
                        }
                    }

                }
            }

            //4. feladat
            {
                Console.WriteLine();
                Console.WriteLine("4. feladat");
                int autobusz = x.Where(kk => kk.rendszam[0] == 'B').Count();
                int kamion = x.Where(kk => kk.rendszam[0] == 'K').Count();
                int motor = x.Where(kk => kk.rendszam[0] == 'M').Count();
                int gepkocsi = x.Count - (autobusz + kamion + motor);
                Console.WriteLine("Autobusz: " + autobusz);
                Console.WriteLine("Kamion: " + kamion);
                Console.WriteLine("Motor: " + motor);
                Console.WriteLine("Gepkocsi: " + gepkocsi);
            }

            //5. feladat
            {
                Console.WriteLine();
                Console.WriteLine("5. feladat");
                long maxido = 0;
                DateTime kezdet = new DateTime(12);
                DateTime vegzet = new DateTime(12);
                for (int i = 0; i < x.Count - 1; i++)
                {
                    long temp = (x[i + 1].ido.Hour * 360 + x[i + 1].ido.Minute * 60 + x[i + 1].ido.Second) - (x[i].ido.Hour * 360 + x[i].ido.Minute * 60 + x[i].ido.Second);
                    if (temp > maxido)
                    {
                        kezdet = x[i].ido;
                        vegzet = x[i + 1].ido;
                        maxido = temp;
                    }
                }
                Console.WriteLine(kezdet.ToString("H:m:s") + " - " + vegzet.ToString("H:m:s"));
            }

            //6. feladat
            {
                Console.WriteLine();
                Console.WriteLine("6. feladat");
                string input = Console.ReadLine();
                char[] temp = input.ToArray();
                List<Adat> szurt = new List<Adat>(x);
                if (temp[0] != '*')
                    szurt = szurt.Where(kk => kk.rendszam[0] == temp[0]).ToList();
                if (temp[1] != '*')
                    szurt = szurt.Where(kk => kk.rendszam[0] == temp[1]).ToList();
                if (temp[2] != '*')
                    szurt = szurt.Where(kk => kk.rendszam[0] == temp[2]).ToList();
                if (temp[3] != '*')
                    szurt = szurt.Where(kk => kk.rendszam[0] == temp[3]).ToList();
                if (temp[4] != '*')
                    szurt = szurt.Where(kk => kk.rendszam[0] == temp[4]).ToList();
                if (temp[5] != '*')
                    szurt = szurt.Where(kk => kk.rendszam[0] == temp[5]).ToList();
                foreach (var item in szurt)
                {
                    Console.WriteLine(item.ido + item.rendszam);
                }
            }
        }
    }
}
