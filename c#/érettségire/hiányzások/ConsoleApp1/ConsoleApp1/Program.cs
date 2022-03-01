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
            public DateTime datum { get; set; }
            public string nev { get; set; }
            public string hianyzas { get; set; }
            public Adat(DateTime datum, string nev, string hianyzas)
            {
                this.datum = datum;
                this.nev = nev;
                this.hianyzas = hianyzas;
            }
            public Adat()
            {

            }
        }

        static void Main(string[] args)
        {
            string[] s = System.IO.File.ReadAllLines("naplo.txt");
            List<Adat> x = new List<Adat>();
            DateTime tempDatum = new DateTime();
            foreach (var item in s)
            {
                string[] tempSplit = item.Split(' ');
                if (tempSplit[0] == "#")
                    tempDatum = new DateTime(1, int.Parse(tempSplit[1]), int.Parse(tempSplit[2]));
                else
                {
                    Adat a = new Adat();
                    a.datum = tempDatum;
                    a.nev = tempSplit[0] + " " + tempSplit[1];
                    a.hianyzas = tempSplit[2];
                    x.Add(a);
                }
            }

            //1. feladat:
            Console.WriteLine("1. feladat:");

            //2. feladat:
            Console.WriteLine("2. feladat:");
            Console.WriteLine("A naplóban " + x.Count + " bejegyzés van.");

            //3. feladat:
            Console.WriteLine("3. feladat:");

            long dbIgazolt = 0;
            long dbIgazolatlan = 0;
            foreach (var item in x)
                foreach (var i in item.hianyzas)
                    if (i == 'X')
                        ++dbIgazolt;
                    else if (i == 'I')
                        ++dbIgazolatlan;

            Console.WriteLine("Az igazolt hiányzások száma " + dbIgazolt + ", az igazolatlanoké " + dbIgazolatlan + " óra.");

            //4. feladat:
            Console.WriteLine("4. feladat:");

            //5. feladat:
            Console.WriteLine("5. feladat:");
            Console.WriteLine("Hónap sorszáma:");
            int honap = int.Parse(Console.ReadLine());
            Console.WriteLine("Nap sorszáma:");
            int nap = int.Parse(Console.ReadLine());
            Console.WriteLine("Azon a napon " + hetnapja(honap,nap) + " volt.");

            //6. feladat:
            Console.WriteLine("6. feladat:");
            Console.WriteLine("A nap neve:");
            string napNev = Console.ReadLine();
            Console.WriteLine("Az óra sorszáma:");
            int oraSorszam = int.Parse(Console.ReadLine());

            long db = 0;
            foreach (var item in x.Where(k => hetnapja(k.datum.Month, k.datum.Day) == napNev))
                if (item.hianyzas[oraSorszam - 1] == 'X' || item.hianyzas[oraSorszam - 1] == 'I')
                    ++db;

            Console.WriteLine("Ekkor összesen " + db + " óra hiányzás történt.");

            //7. feladat:
            Console.WriteLine("7. feladat:");

            Dictionary<string, long> dic = new Dictionary<string, long>();
            foreach (var item in x)
                foreach (var i in item.hianyzas)
                    if (i == 'X' || i == 'I')
                    {
                        if (dic.ContainsKey(item.nev))
                            ++dic[item.nev];
                        else
                            dic.Add(item.nev, 1);
                    }

            (string, long) max = ("",0);
            foreach (var item in dic)
            {
                if (item.Value > max.Item2)
                    max = (item.Key, item.Value);
            }

            Console.Write("A legtöbbet hiányzó tanulók: ");
            foreach (var item in dic)
                if(item.Value == max.Item2)
                    Console.Write(item.Key + " ");
            Console.WriteLine();
        }

        public static string hetnapja(int honap, int nap)
        {
            string[] napnev = { "vasarnap", "hetfo", "kedd", "szerda", "csutortok", "pentek", "szombat" };
            int[] napszam = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 335 };
            int napsorszam = (napszam[honap - 1] + nap) % 7;
            return napnev[napsorszam];
        }
    }
}
