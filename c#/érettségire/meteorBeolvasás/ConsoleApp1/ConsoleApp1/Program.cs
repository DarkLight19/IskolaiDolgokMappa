using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleApp1
{
    class telepules
    {
        public string nev { get; set; }
        public DateTime ido { get; set; }
        public string szelirany { get; set; }
        public int szelEro { get; set; } //csomóban
        public int homerseklet { get; set; }
        public telepules(string a, DateTime b, string c, int d, int e)
        {
            this.nev = a;
            this.ido = b;
            this.szelirany = c;
            this.szelEro = d;
            this.homerseklet = e;
        }
        public telepules()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<telepules> x = new List<telepules>();
            using(System.IO.StreamReader f = new System.IO.StreamReader("tavirathu13.txt"))
            {
                while (!f.EndOfStream)
                {
                    string[] s = f.ReadLine().Split(' ');
                    telepules t = new telepules();
                    t.nev = s[0].ToString();
                    string hours = s[1][0].ToString() + s[1][1].ToString();
                    string minutes = s[1][2].ToString() + s[1][3].ToString();
                    t.ido = new DateTime(1,1,1,int.Parse(hours),int.Parse(minutes),0);
                    string SzeliranyTemp = s[2][0].ToString() + s[2][1].ToString() + s[2][2].ToString();
                    t.szelirany = SzeliranyTemp;
                    string SzelEroTemp = s[2][3].ToString() + s[2][4].ToString();
                    t.szelEro = int.Parse(SzelEroTemp);
                    t.homerseklet = int.Parse(s[3]);
                    x.Add(t);
                }
            }

            //1. feladat
            //Console.WriteLine(x.Count);

            //2. feladat
            Console.WriteLine("Város kódja:");
            string a = Console.ReadLine();
            List<telepules> masodikTemp = x.Where(k => k.nev == a).ToList();
            if (masodikTemp.Count != 0)
                Console.WriteLine(masodikTemp[masodikTemp.Count - 1].ido.ToString("HH:mm")); //masodikTemp[masodikTemp.Count-1].ido.Hour + ":" + masodikTemp[masodikTemp.Count - 1].ido.Minute + " " + 

            //3. feladat
            int Min, Max;
            telepules MinTelep;
            telepules MaxTelep;
            /*
            Min = x.Min(k => k.homerseklet);
            Max = x.Max(k => k.homerseklet);*/
            
            MinTelep = x.Where(z => z.homerseklet == x.Min(k => k.homerseklet)).ToList()[0];
            MaxTelep = x.Where(z => z.homerseklet == x.Max(k => k.homerseklet)).ToList()[0];
            Console.WriteLine(MinTelep.nev + " " + MinTelep.ido.ToString("HH:mm") + " " + MinTelep.homerseklet);
            Console.WriteLine(MaxTelep.nev + " " + MaxTelep.ido.ToString("HH:mm") + " " + MaxTelep.homerseklet);

            //4. feladat
            List<telepules> negedikTemp = x.Where(k => k.szelEro == 0 && k.szelirany == "000").ToList();
            if (negedikTemp.Count == 0)
                Console.WriteLine("Nem volt szélcsend a mérések idején.");
            else
                foreach (var item in negedikTemp)
                    Console.WriteLine(item.nev + " " + item.ido.ToString("HH:mm"));

            //5. feladat
            List<string> bannedNames = new List<string>();
            foreach (var item in x)
                if (!bannedNames.Contains(item.nev))
                {
                    bannedNames.Add(item.nev);
                    Console.Write(item.nev + " ");
                    List<telepules> otodikTemp = x.Where(k => k.nev == item.nev).ToList();
                    List<telepules> otodikTempKozep = otodikTemp.Where(z => int.Parse(z.ido.ToString("HH")) == 1 || int.Parse(z.ido.ToString("HH")) == 13 || int.Parse(z.ido.ToString("HH")) == 7 || int.Parse(z.ido.ToString("HH")) == 19).ToList();
                    int tempSum = 0;

                    if(otodikTempKozep.Count < 4 || egyiknincsmeg(otodikTempKozep))
                        Console.Write("NA;");

                    foreach (var i in otodikTempKozep)
                        tempSum += i.homerseklet;
                    Console.Write("Középhőmérséklet: " + Math.Round((double)tempSum/otodikTempKozep.Count) +"; ");
                    Console.Write("Hőmérséklet-ingadozás: " + (int.Parse(otodikTemp.Max(kk => kk.homerseklet).ToString()) - int.Parse(otodikTemp.Min(kk => kk.homerseklet).ToString())));
                    Console.WriteLine();
                }

            //6. feladat
            bannedNames = new List<string>();
            foreach (var item in x)
                if (!bannedNames.Contains(item.nev))
                    using (System.IO.StreamWriter f = new System.IO.StreamWriter(item.nev + ".txt"))
                    {
                        f.WriteLine(item.nev);
                        foreach (var i in x.Where(k => k.nev == item.nev))
                        {
                            f.Write(i.ido.ToString("HH:mm") + " ");
                            for (int j = 0; j < i.szelEro; j++)
                            {
                                f.Write("#");
                            }
                            f.WriteLine();
                        }
                    }

        }

        public static bool egyiknincsmeg(List<telepules> x)
        {
            if (x.Where(z => int.Parse(z.ido.ToString("HH")) == 1).Count() == 0)
                return true;
            if (x.Where(z => int.Parse(z.ido.ToString("HH")) == 7).Count() == 0)
                return true;
            if (x.Where(z => int.Parse(z.ido.ToString("HH")) == 13).Count() == 0)
                return true;
            if (x.Where(z => int.Parse(z.ido.ToString("HH")) == 19).Count() == 0)
                return true;

            return false;
        }
    }
}
