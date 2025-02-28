using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalapacsvetes
{
    public class Sportolos
    {
        public int helyezes { get; set; }
        public double eredmeny { get; set; }
        public string nev { get; set; }
        public string orszagkod { get; set; }
        public string helyszin { get; set; }
        public string datum { get; set; }

        public Sportolos(string sor)
        {
            string[] s = sor.Split(';');
            helyezes = int.Parse(s[0]);
            eredmeny = Convert.ToDouble(s[1]);
            nev = s[2];
            orszagkod = s[3];
            helyszin = s[4];
            datum = s[5];
        }
    }
}
