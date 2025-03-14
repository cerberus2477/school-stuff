using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzinKereses
{
    internal class Jatek
    {
        public int jatek_id { get; set; }
        public int lepes { get; set; }
        public int ido { get; set; }

        public Jatek(int jatek_id, int lepes, int ido)
        {
            this.jatek_id = jatek_id;
            this.lepes = lepes;
            this.ido = ido;
        }
    }
}
