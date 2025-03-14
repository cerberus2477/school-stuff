using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzinKereses
{
    internal class Jatekos
    {
        public int id { get; set; }
        public string nev { get; set; }

        public List<Jatek> jatekok { get; set; }

        public Jatekos(int id, string nev)
        {
            this.id = id;
            this.nev = nev;
            jatekok = new List<Jatek>();
        }



        //b.ki tudja választanai a legrövidebb lépésszám szerinti játékot és visszaadja a lépésszámot
        public int minLepesszam()
        {
            return jatekok.Select(j => j.lepes).Min();
        }


        //c.ki tudja választanai az idő szerinti legrövidebb játékot és visszaadja a játék idejét
        public int minIdo()
        {
            return jatekok.Select(j => j.ido).Min();
        }


        //d.össze tudja hasonlítani a játékos legkevesebb lépésszámát másik játékos lépésszámával
        public int CompareBySteps(Jatekos jatekos)
        {
            if (jatekos.minLepesszam() == this.minLepesszam()) return 0;
            return jatekos.minLepesszam() > this.minLepesszam() ? -1 : 1;
        }

        //e.össze tudja hasonlítani a játékos legkevesebb ido
        public int CompareByTime(Jatekos jatekos)
        {
            if (jatekos.minIdo() == this.minIdo()) return 0;
            return jatekos.minIdo() > this.minIdo() ? -1 : 1;
        }


        //f.kérésre visszaadja a játékos adatait(név, játékok száma, legrövidebb- lépésű, idejű játék)
        public override string ToString()
        {
            return $"{nev}, {jatekok.Count()}, {minLepesszam()}, {minIdo()}";
        }
    }
}
