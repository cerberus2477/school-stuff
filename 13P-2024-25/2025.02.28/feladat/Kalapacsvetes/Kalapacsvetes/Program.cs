using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kalapacsvetes
{
    internal class Program
    {
        static Sportolos[] sportolok;
        static void Main(string[] args)
        {
            sportolok = SportolokCSVbol("kalapacsvetes.txt");
            f4();
            f5();
            f6();
            f7();
            f8();
        }

        //első sorban feljécek!
        static Sportolos[] SportolokCSVbol(string fajlnev)
        {
            StreamReader sr = new StreamReader(fajlnev);
            sr.ReadLine();
            return sr.ReadToEnd().Split('\n').Select(s => new Sportolos(s)).ToArray();
        }

        // Határozza meg és írja ki, hány dobás eredménye található a forrásfájlban! 
        static void f4()
        {
            Console.WriteLine($"4. feladat: {sportolok.Length} dobás eredménye található.");
        }

        // (HUN) sportolók dobásainak átlageredményét! Az eredményt két tizedesre kerekítve írja ki!
        static void f5()
        {
            Console.WriteLine($"4. feladat: A magyar sportolók átlagosan {sportolok.Where(s => s.orszagkod == "HUN").Average(m => m.eredmeny)} métert dobtak.");
        }

        static void f6()
        {
            Console.WriteLine("6. feladat: Adjon meg egy évszámot: ");
            int evszam = int.Parse(Console.ReadLine());
            int dobasok = sportolok.Where(s => int.Parse(s.datum.Substring(0, 4)) == evszam).Count();

            string dobasoktxt = dobasok > 0 ? $"{dobasok} darab dobás" : "Egy dobás sem";
            Console.WriteLine($"\t{dobasoktxt} került be ebben az évben.");
            if (dobasok > 0)
            {
                foreach (var nev in sportolok.Where(s => s.datum.Contains($"{evszam}")).Select(s => s.nev))
                {
                    Console.WriteLine($"\t{nev}");
                }
            }
        }

        //Készítsen statisztikát, hogy melyik országból hány kalapácsvetés eredménye szerepel a 
        //legjobb dobások között
        static void f7()
        {
            Console.WriteLine("7. feladat: Statisztika");
            foreach (string orszag in sportolok.Select(s => s.orszagkod).Distinct())
            {
                Console.WriteLine($"\t{orszag} - {sportolok.Where(s => s.orszagkod == orszag).Count()} dobás");
            }
        }

        //magyar mentés
        public static void f8()
        {
            StreamWriter sw = new StreamWriter("magyarok.txt");
            sw.WriteLine("Helyezés;Eredmény;;Sportoló;Országkód;Helyszín;Dátum");
            foreach (var m in sportolok.Where(s => s.orszagkod == "HUN"))
            {
                sw.WriteLine($"{m.helyezes};{m.eredmeny};{m.nev};{m.orszagkod};{m.helyszin};{m.datum}");
            }
            sw.Close();
        }
    }
}
