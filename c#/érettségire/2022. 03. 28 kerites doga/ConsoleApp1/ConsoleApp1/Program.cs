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
            public (bool elkeszult, string szin) kerites { get; set; }
            public int hazSzam { get; set; }
            public int telekSzelesseg { get; set; }
            public bool parosE { get; set; }
            public Adat((bool elkeszult, string szin) a, int b, int c, bool d)
            {
                this.kerites = a;
                this.hazSzam = b;
                this.telekSzelesseg = c;
                this.parosE = d;
            }
            public Adat()
            {

            }
        }
        static void Main(string[] args)
        {
            //1.feladat
            Console.WriteLine("1.feladat:");
            string[] s = System.IO.File.ReadAllLines("kerites.txt");
            List<string> lehetsegesSzinek = new List<string>();

            List<Adat> x = new List<Adat>();

            int parosCounter = 0;
            int paratlanCounter = 0;
            foreach (var item in s)
            {
                string[] temp = item.Split(' ');
                Adat a = new Adat();
                if (temp[0] == "0")
                {
                    a.parosE = true;
                    a.hazSzam = parosCounter * 2 + 2;
                    ++parosCounter;
                }
                else
                {
                    a.parosE = false;
                    a.hazSzam = paratlanCounter * 2 + 1;
                    ++paratlanCounter;
                }

                a.telekSzelesseg = int.Parse(temp[1]);

                if (temp[2] == ":")
                    a.kerites = (false, "");
                else if (temp[2] == "#")
                    a.kerites = (true, "");
                else
                {
                    if (!lehetsegesSzinek.Contains(temp[2]))
                        lehetsegesSzinek.Add(temp[2]);
                    a.kerites = (true, temp[2]);
                }

                x.Add(a);
            }

            //2.feladat:
            Console.WriteLine("2.feladat:");
            Console.WriteLine("Az eladott telkek száma: " + x.Count);

            //3. feladat:
            Console.WriteLine("3. feladat:");
            if(x[x.Count-1].parosE)
                Console.WriteLine("A páros oldalon adták el az utolsó telket.");
            else
                Console.WriteLine("A páratlan oldalon adták el az utolsó telket.");
            Console.WriteLine("Az utolsó telek házszáma: " + x[x.Count-1].hazSzam);

            //4. feladat:
            Console.WriteLine("4. feladat:");
            {
                List<Adat> tempX = x.Where(k => k.parosE == false).ToList();

                for (int i = 1; i < tempX.Count; i++)
                {
                    if (tempX[i - 1].parosE || tempX[i].parosE || tempX[i - 1].kerites.szin == "" || tempX[i].kerites.szin == "")
                        continue;

                    if(tempX[i-1].kerites.szin == tempX[i].kerites.szin)
                    {
                        Console.WriteLine("A szomszédossal egyezik a kerítés színe: " + tempX[i - 1].hazSzam);
                        break;
                    }
                }
            }

            //5.feladat:
            Console.WriteLine("5.feladat:");
            Console.Write("Adjon meg egy házszámot! ");
            {
                int hazszam = int.Parse(Console.ReadLine());
                Adat haz = new Adat();
                foreach (var item in x)
                    if (item.hazSzam == hazszam)
                    {
                        haz = item;
                        break;
                    }
                if (!haz.kerites.elkeszult)
                    Console.WriteLine("A kerítés színe / állapota: :");
                else if(haz.kerites.szin == "")
                    Console.WriteLine("A kerítés színe / állapota: #");
                else
                    Console.WriteLine("A kerítés színe / állapota: " + haz.kerites.szin);

                
                List <Adat> tempX = x.Where(k => k.parosE == haz.parosE).ToList();

                if(lehetsegesSzinek.Count <= 3)
                {
                    if(!lehetsegesSzinek.Contains("A"))
                        Console.WriteLine("Egy lehetséges festési szín: A");
                    else if (!lehetsegesSzinek.Contains("B"))
                        Console.WriteLine("Egy lehetséges festési szín: B");
                    else if (!lehetsegesSzinek.Contains("C"))
                        Console.WriteLine("Egy lehetséges festési szín: C");
                    else if (!lehetsegesSzinek.Contains("D")) // ez már tuti jó lesz hiszten csak 3 szín van
                        Console.WriteLine("Egy lehetséges festési szín: D");
                }
                else//tuti találunk egy különböző színt
                {
                    Adat balOldali = new Adat();
                    Adat jobbOldali = new Adat();
                    balOldali.telekSzelesseg = -1;
                    jobbOldali.telekSzelesseg = -1;

                    foreach (var item in x)
                    {
                        if (item.hazSzam == hazszam - 2)
                            balOldali = item;
                        else if (item.hazSzam == hazszam + 2)
                            jobbOldali = item;
                    }

                    if (balOldali.telekSzelesseg != -1 && balOldali.kerites.elkeszult && balOldali.kerites.szin != "")
                        lehetsegesSzinek.Remove(balOldali.kerites.szin);

                    if (jobbOldali.telekSzelesseg != -1 && jobbOldali.kerites.elkeszult && jobbOldali.kerites.szin != "")
                        lehetsegesSzinek.Remove(jobbOldali.kerites.szin);

                    Console.WriteLine("Egy lehetséges festési szín: " + lehetsegesSzinek[0]);
                }
            }

            //6.feladat:
            Console.WriteLine("6.feladat:");
            using (System.IO.StreamWriter f = new System.IO.StreamWriter("utcakep.txt"))
            {
                foreach (var item in x.Where(k=> k.parosE == false))
                {
                    if(!item.kerites.elkeszult)
                        for (int i = 0; i < item.telekSzelesseg; i++)
                        {
                            f.Write(":");
                        }
                    else if (item.kerites.elkeszult && item.kerites.szin == "")
                        for (int i = 0; i < item.telekSzelesseg; i++)
                        {
                            f.Write("#");
                        }
                    else
                        for (int i = 0; i < item.telekSzelesseg; i++)
                        {
                            f.Write(item.kerites.szin);
                        }
                }
                f.WriteLine();

                foreach (var item in x.Where(k => k.parosE == false))
                {
                    f.Write(item.hazSzam);
                    for (int i = 0; i < item.telekSzelesseg-item.hazSzam.ToString().Length; i++)
                    {
                        f.Write(" ");
                    }
                }
            }

        }
    }
}
