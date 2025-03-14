using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masodfoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Masodfoku egyenlet megoldása (ax^2 + bx + c = 0)");

            // Prompt user for coefficients
            Console.Write("Adja meg az a együtthatót: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Adja meg a b együtthatót: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Adja meg a c együtthatót: ");
            double c = Convert.ToDouble(Console.ReadLine());

            // Create instance of Masodfoku class with user input
            Masodfoku egyenlet = new Masodfoku(a, b, c);

            // Display the result
            Console.WriteLine(egyenlet.ToString());

            // Keep the console window open until the user closes it
            Console.WriteLine("Nyomjon meg egy gombot a kilépéshez...");
            Console.ReadKey();
        }
    }
}
