using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace RealEstate
{
    internal class Ad
    {
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }

        public int GetArea() => Area;
        public bool isFreeOfCharge() => FreeOfCharge;

        public double[] GetCoordinates() => Array.ConvertAll(LatLong.Split(','), s => double.Parse(s, CultureInfo.InvariantCulture));

        public bool IsGroundFloor() => Floors == 0;
        public int GetRooms() => Rooms;

        public string GetSellerName() => Seller.GetName();
        public string GetSellerPhone() => Seller.GetPhone();

        //       4. Szükség esetén az Ad osztály adattagjainak beállítását konstruktor segítségével állítsa
        //be! A paraméterben kapott adatok az adatforrásoktól függően változóak lehetnek
    }
}
