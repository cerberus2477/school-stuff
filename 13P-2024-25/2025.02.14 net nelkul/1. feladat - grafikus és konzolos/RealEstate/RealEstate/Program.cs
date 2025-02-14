using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

//A képernyőre írást igénylő részfeladatok eredményének megjelenítése előtt írja a 
//képernyőre a feladat sorszámát (például: 3.feladat:)!
namespace RealEstate
{
    internal class Program
    {
        public static List<Ad> AdsList;
        static void Main(string[] args)
        {
            AdsList = LoadAdsFromJson("realestates.json");

            //6.Határozza meg és írja ki a minta szerint az eladásra kínált földszinti ingatlanok átlagos
            //alapterületét! két tizedesjegy 
            double avgGroundFloorArea = AdsList.Where(a => a.IsGroundFloor()).Average(a => a.GetArea());
            Console.WriteLine($"1. Földszinti ingatlanok átlagos alapterülete: {avgGroundFloorArea}");


            //8.tavolsagos
            double mesevarX = 47.4164220114023;
            double mesevarY = 9.066342425796986;
            //freeofcharge
            double minDistanceFromMesevar = AdsList.Where(a => a.isFreeOfCharge()).Min(a => DistanceTo(mesevarX, mesevarY, a));
            Ad closestAdToMesevar = AdsList.Single(a => DistanceTo(mesevarX, mesevarY, a) == minDistanceFromMesevar);
            Console.WriteLine("A Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai:");
            Console.WriteLine($"\t{"Eladó neve",-15} : {closestAdToMesevar.GetSellerName()}");
            Console.WriteLine($"\t{"Eladó telefonja",-15} : {closestAdToMesevar.GetSellerPhone()}");
            Console.WriteLine($"\t{"Alapterület",-15} : {closestAdToMesevar.GetArea()}");
            Console.WriteLine($"\t{"Szobák száma",-15} : {closestAdToMesevar.GetRooms()}");

        }

        //3. A metódus visszatérési értéke az Ad osztályból képzett
        //lista legyen! 
        //TODO: át kéne írnom az összes class fieldet publicra (get, private set) hogy fel tudja tölteni adatokkal és ne csak null legyen
        private static List<Ad> LoadAdsFromJson(string filename)
        {
            string json = File.ReadAllText(filename);
            //List<Ad> adlist = JsonSerializer.Deserialize<List<Ad>>(json);
            return JsonConvert.DeserializeObject<List<Ad>>(json);
        }


        private static double DistanceTo(double startX, double startY, Ad ad)
        {
            double[] adCoordinates = ad.GetCoordinates();
            return Math.Sqrt(Math.Pow(startX-adCoordinates[0], 2) + Math.Pow(startX - adCoordinates[1], 2));
        }
    }
}
