﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public string GetName() => Name;
        public string GetPhone() => Phone;
    }
}
