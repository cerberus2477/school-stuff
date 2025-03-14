using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hattertarolo
{
    internal class DVD_RW : DVD
    {
        public void Unlock()
        {
            isLocked = true;
            Format();
        }
    }
}
