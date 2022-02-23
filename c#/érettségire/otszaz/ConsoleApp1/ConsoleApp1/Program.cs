using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public class vasarlo
        {
            public List<string> termekek { get; set; }
            public int vegOsszeg { get; set; }
            public int dbTermek { get; set; }

            public vasarlo(List<string> a)
            {
                int i = 0;
                foreach (var item in a)
                {
                    vegOsszeg += 500 - i;
                    if (i < 100)
                        i += 50;
                }
                dbTermek = a.Count;
                termekek = new List<string>(a);
            }
        }
        static void Main(string[] args)
        {
            List<vasarlo> x = new List<vasarlo>();
            //beolvasás:
            Console.WriteLine("1. feladat:");
            {
                List<string> temp = new List<string>();
                foreach (var item in System.IO.File.ReadAllLines("penztar.txt"))
                {
                    if (item == "F")
                    {
                        x.Add(new vasarlo(temp));
                        temp = new List<string>();
                    }
                    else
                        temp.Add(item);
                }
            }

            //masodik feladat:
            Console.WriteLine("2. feladat:");
            Console.WriteLine(x.Count);

            //3. fealdat
            Console.WriteLine("3. fealdat:");
            Console.WriteLine(x[0].termekek.Count);

            //4. feladat
            Console.WriteLine("4. feladat:");
            Console.WriteLine("Egy vásárlás sorszáma:");
            int sorszam = int.Parse(Console.ReadLine())-1; //!!!!!!
            Console.WriteLine("Egy árucikk neve:");
            string arucikkNev = Console.ReadLine();
            Console.WriteLine("Egy darabszám:");
            int darabszam = int.Parse(Console.ReadLine());

            //5. feladat
            Console.WriteLine("5. feladat:");

            {
                (int, bool) elso = (0, false);
                int utolso = 0;
                int szamlalo = 0;
                for (int i = 0; i < x.Count; i++)
                    foreach (var item in x[i].termekek)
                    {
                        if (item == arucikkNev)
                        {
                            if (!elso.Item2)
                            {
                                elso.Item1 = i + 1;
                                elso.Item2 = true;
                            }
                            utolso = i + 1;
                            ++szamlalo;
                        }
                    }

                Console.WriteLine("a) Elösször: " + elso.Item1 + ". vásárláskor, utoljára: " + utolso + ". vásárláskor.");
                Console.WriteLine("b) " + szamlalo + " darabot vettek belőle");
            }

            //6.feladat
            Console.WriteLine("6.feladat");
            Console.WriteLine(ertek(darabszam));

            //7. feladat:
            Console.WriteLine("7. feladat:");
            {
                List<string> voltmar = new List<string>();
                foreach (var i in x[sorszam].termekek)
                {
                    if (!voltmar.Contains(i))
                    {
                        Console.Write(x[sorszam].termekek.Where(k => k == i).Count() + " ");
                        Console.WriteLine(i);
                        voltmar.Add(i);
                    }
                }
            }

            //8. feladat:
            Console.WriteLine("8. feladat:");
            using (System.IO.StreamWriter f = new System.IO.StreamWriter("osszeg.txt"))
            {
                for (int i = 0; i < x.Count; i++)
                {
                    f.Write(i + 1);
                    f.WriteLine(": " + x[i].vegOsszeg);
                }
            }
        }

        //6. feladat:
        public static int ertek(int db)
        {
            if (db == 1)
                return 500;
            if (db == 2)
                return 950;

            return 950 + (db - 2) * 400;
        }
    }
}
