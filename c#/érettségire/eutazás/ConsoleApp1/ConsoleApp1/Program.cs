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
            public int megalloSorszam { get; set; }
            public DateTime datum { get; set; }
            public int azonosito { get; set; }
            public string tipus { get; set; }
            public (bool, int, DateTime) jegyDBvagyLejaratiDatum { get; set; }
            public Adat()
            {

            }
            public Adat(int a, DateTime b, int c, string d, (bool, int, DateTime) e)
            {
                megalloSorszam = a;
                datum = b;
                azonosito = c;
                tipus = d;
                jegyDBvagyLejaratiDatum = e;
            }
        }
        static void Main(string[] args)
        {
            List<Adat> x = new List<Adat>();
            foreach (var item in System.IO.File.ReadAllLines("utasadat.txt"))
            {
                string[] s = item.Split(' ');
                Adat a = new Adat();
                a.megalloSorszam = int.Parse(s[0]);
                a.datum = new DateTime(int.Parse(s[1].Substring(0, 4)), int.Parse(s[1].Substring(4, 2)), int.Parse(s[1].Substring(6, 2)), int.Parse(s[1].Substring(9, 2)), int.Parse(s[1].Substring(11)), 0);
                a.azonosito = int.Parse(s[2]);
                a.tipus = s[3];
                if (s[3] == "JGY")
                    a.jegyDBvagyLejaratiDatum = (true, int.Parse(s[4]), new DateTime());
                else
                    a.jegyDBvagyLejaratiDatum = (false, -1, new DateTime(int.Parse(s[4].Substring(0, 4)), int.Parse(s[4].Substring(4, 2)), int.Parse(s[4].Substring(6, 2))));
                
                x.Add(a);
            }

            //2. feladat:
            Console.WriteLine("2. feladat:");
            Console.WriteLine("A buszra " + x.Select(k=>k.azonosito).Distinct().Count() + " utas akart felszállni.");

            //3. feladat:
            Console.WriteLine("3. feladat:");
            int count = x.Where(k => k.jegyDBvagyLejaratiDatum.Item1== true && k.jegyDBvagyLejaratiDatum.Item2 == 0).Count();
            foreach (var item in x.Where(k => k.jegyDBvagyLejaratiDatum.Item1 == false))
                //if (item.datum > item.jegyDBvagyLejaratiDatum.Item3)
                if (new DateTime(item.datum.Year, item.datum.Month, item.datum.Day).CompareTo(item.jegyDBvagyLejaratiDatum.Item3) > 0)
                    ++count;

            Console.WriteLine("A buszra " + count + " utas nem szállhatott fel.");

            //4. feladat:
            Console.WriteLine("4. feladat:");
            int max = 0;
            int maxhely = 0;
            for (int i = 0; i < x.Select(k => k.megalloSorszam).Distinct().Count(); i++)
            {
                int temp = x.Where(k => k.megalloSorszam == i).Count();
                if(temp >max)
                {
                    max = temp;
                    maxhely = i;
                }
            }
            Console.WriteLine("A legtöbb utas (" + max + " fő) a " + maxhely + ". megállóban próbált felszállni.");

            //5. feladat:0
            Console.WriteLine("5. feladat:");

            //ingyenes
            count = x.Where(k => (k.tipus == "NYP" || k.tipus == "RVS" || k.tipus == "GYK") && k.jegyDBvagyLejaratiDatum.Item1 == true && k.jegyDBvagyLejaratiDatum.Item2 > 0).Count();
            foreach (var item in x.Where(k => (k.tipus == "NYP" || k.tipus == "RVS" || k.tipus == "GYK") && k.jegyDBvagyLejaratiDatum.Item1 == false))
                //if (item.datum <= item.jegyDBvagyLejaratiDatum.Item3)
                if (new DateTime(item.datum.Year, item.datum.Month, item.datum.Day).CompareTo(item.jegyDBvagyLejaratiDatum.Item3) <= 0)
                    ++count;

            Console.WriteLine("Ingyenesen: " + count);

            //kedvezményes:
            count = x.Where(k => (k.tipus == "TAB" || k.tipus == "NYB" ) && k.jegyDBvagyLejaratiDatum.Item1 == true && k.jegyDBvagyLejaratiDatum.Item2 > 0).Count();
            foreach (var item in x.Where(k => (k.tipus == "TAB" || k.tipus == "NYB") && k.jegyDBvagyLejaratiDatum.Item1 == false))
                //if (item.datum <= item.jegyDBvagyLejaratiDatum.Item3)
                if (new DateTime(item.datum.Year, item.datum.Month, item.datum.Day).CompareTo(item.jegyDBvagyLejaratiDatum.Item3) <= 0)
                    ++count;

            Console.WriteLine("Kedvezményes: " + count);

            //6. feladat:
            Console.WriteLine("6. feladat:");

            //7. feladat:
            Console.WriteLine("7. feladat:");
            using (System.IO.StreamWriter f = new System.IO.StreamWriter("figyelmeztetes.txt"))
            {
                foreach (var item in x.Where(k => k.jegyDBvagyLejaratiDatum.Item1 == false))
                {
                    if (3 <= Math.Abs(napokszama(item.datum.Year, item.datum.Month, item.datum.Day, item.jegyDBvagyLejaratiDatum.Item3.Year, item.jegyDBvagyLejaratiDatum.Item3.Month, item.jegyDBvagyLejaratiDatum.Item3.Day)))
                        f.WriteLine(item.azonosito + " " + item.jegyDBvagyLejaratiDatum.Item3.ToString("yyyy-MM-dd"));
                }
            }
        }

        public static double napokszama(double e1, double h1, double n1, double e2, double h2, double n2)
        {
            h1 = (h1 + 9) / 12.0;
            e1 = Math.Floor(e1 - h1 / 10);
            double d1 = 365 * e1 + Math.Floor(e1 / 4) - Math.Floor(e1 / 100) + Math.Floor(e1 / 400) + Math.Floor((h1 * 306 + 5) / 10) + n1 - 1;
            h2 = (h2 + 9) / 12.0;
            e2 = (h2 + 9) / 12.0;
            double d2 = 365 * e2 + Math.Floor(e2 / 4) - Math.Floor(e2 / 100) + Math.Floor(e2 / 400) + Math.Floor((h2 * 306 + 5) / 10) + n2 - 1;
            return d2-d1;
        }
    }
}
