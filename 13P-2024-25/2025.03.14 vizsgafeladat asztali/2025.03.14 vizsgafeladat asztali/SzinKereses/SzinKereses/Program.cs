using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzinKereses
{
    internal class Program
    {
        static Jatekos[] jatekosok;
        static void Main(string[] args)
        {
            jatekosok = JatekosokCSVbol("eredmenyek.csv");
            fa();
            fb();
            fc();
            fd();
            fe();
            ff();
        }

        //4.	Készítsen metódust az adatok beolvasására a kapott fájlból saját adatszerkezetébe.
        static Jatekos[] JatekosokCSVbol(string fajlnev)
        {
            List<Jatekos> jatekosLista = new List<Jatekos>();

            StreamReader sr = new StreamReader(fajlnev);
            sr.ReadLine();
            string[] sorok = sr.ReadToEnd().Split('\n').ToArray();
            //soronként Játékká alakítjuk
            foreach (string sor in sorok)
            {
                string[] s = sor.Split(';');
                int id = int.Parse(s[0]);
                string nev = s[1];
                int jatek_id = int.Parse(s[2]);
                int lepes = int.Parse(s[3]);
    
                //hh:mm:ss, remélem jól átalakul másodperccé
                TimeSpan timeSpan = TimeSpan.Parse(s[4]);
                int mp = (int)timeSpan.TotalSeconds;

                Jatek jatek = new Jatek(jatek_id, lepes, mp);

                //megnézzük hogy már van e ilyen játékos, ha igen, akkor ahhoz adjuk hozzá a játékot, ha nem, új játékoshoz
                Jatekos jatekos = jatekosLista.FirstOrDefault(j => j.id == id);
                if (jatekos == null)
                {
                    jatekos = new Jatekos(id, nev);
                    jatekosLista.Add(jatekos);
                }

                jatekos.jatekok.Add(jatek);
            }

            return jatekosLista.ToArray();
        }

        //5.
        // a.	hány játékos játszott a programmal,
        static void fa()
        {
            Console.WriteLine($"5.a. feladat: {jatekosok.Length} db játékos játszott a játékkal.");
        }

        //b.hány játékot játszottak,
        static void fb()
        {
            Console.WriteLine($"5.b. feladat: {jatekosok.Select(j => j.jatekok.Count()).Sum()} db játékot játszottak összesen.");
        }


        //c.mennyi volt a játékosok legrövidebb játékainak átlagideje,
        static void fc()
        {
            Console.WriteLine($"5.c feladat: A játékosok lejrövidebb játéka átlagosan {jatekosok.Average(j => j.minIdo())} mp hosszú volt.");
        }

        //d.hány lépésben oldották meg a játékosok(legrövidebb lépésszámuk szerint) átlagosan a játékot,
        static void fd()
        {
            Console.WriteLine($"5.d feladat: A játékosok lejrövidebb játéka átlagosan {jatekosok.Average(j => j.minLepesszam())} lépésből állt.");
        }


        //e.listázza ki a játékosokat a legrövidebb idejük alapján növekvő sorrendben(2/e, 2/f metódus felhasználásával)
        static void fe()
        {
            Array.Sort(jatekosok, (j1, j2) => j1.CompareByTime(j2));
            Console.WriteLine("5.e. feladat: Játékosok legrövidebb idejük alapján növekvő sorrendben:");
            Console.WriteLine("\tnév, játékok száma, min. lépés, min. idő");
            foreach (var j in jatekosok)
            {
                Console.WriteLine($"\t{j}");
            }
        }

        //f. legrövidebb lépésszámuk alapján növekvő sorrendben 
        static void ff()
        {
            Array.Sort(jatekosok, (j1, j2) => j1.CompareBySteps(j2));
            Console.WriteLine("5.f. feladat: Játékosok legrövidebb lépésszámuk alapján növekvő sorrendben:");
            Console.WriteLine("\tnév, játékok száma, min. lépés, min. idő");
            foreach (var j in jatekosok)
            {
                Console.WriteLine($"\t{j}");
            }
        }

    }
}
