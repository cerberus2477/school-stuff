using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuggohid
{
    internal class Fuggohid
    {
        public int helyezes { get; set; }
        public string nev { get; set; }
        public string hely { get; set; }
        public string orszag { get; set; }
        public int hossz { get; set; }
        public int ev { get; set; }

        public Fuggohid(string sor)
        {
            string[] s = sor.Split('\t');
            helyezes = int.Parse(s[0]);
            nev = s[1];
            hely = s[2];
            orszag = s[3];
            hossz = int.Parse(s[4]);
            ev = int.Parse(s[5]);
        }

        public override string ToString()
        {
            return nev;
        }
    }
}
