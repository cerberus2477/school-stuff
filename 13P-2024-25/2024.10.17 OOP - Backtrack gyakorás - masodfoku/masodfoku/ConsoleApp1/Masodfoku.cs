using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace masodfoku
{
    internal class Masodfoku
    {
        private double _a;
        private double _b;
        private double _c;

        //legyenek "komplex typúsú változók"
        private double _eredmeny1;
        private double _eredmeny2;

        private int _megoldasEsetszam;

        public Masodfoku(double a, double b, double c) { 
            _a = a;
            _b = b;
            _c = c;
            //a megoldás azonnal készüljön el
        }

        private void Megold()
        {
            if (_a == 0 && _b == 0 && _c == 0)
            {
                _megoldasEsetszam = 0; 
            }
            else if (_a == 0 && _b == 0 && _c != 0)
            {
                _megoldasEsetszam = 1; 
            }
            else if (_a == 0 && _b != 0)
            {
                _megoldasEsetszam = 2; 
                _eredmeny1 = -_c / _b;
                _eredmeny2 = _eredmeny1; 
            }
            else
            {
                double D = _b * _b - 4 * _a * _c;

                if (D < 0) //Komplex számok innentől
                {
                    _megoldasEsetszam = 3; // Complex conjugate roots
                    double realPart = -_b / (2 * _a);
                    double imaginaryPart = Math.Sqrt(-D) / (2 * _a);
                    _eredmeny1 = realPart;  // valós rész
                    _eredmeny2 = imaginaryPart; // komplex rész (kiíráshoz)
                }
                else if (D == 0)
                {
                    _megoldasEsetszam = 4; // Two identical real roots
                    _eredmeny1 = _eredmeny2 = -_b / (2 * _a);
                }
                else
                {
                    _megoldasEsetszam = 5; // Two distinct real roots
                    _eredmeny1 = (-_b + Math.Sqrt(D)) / (2 * _a);
                    _eredmeny2 = (-_b - Math.Sqrt(D)) / (2 * _a);
                }
            }
        }

        //készítsen egy output operátort
        public override string ToString() => $"Együtthatók: a={_a}, b={_b}, c={_c}. " +
                                             $"Megoldás eredményei: x1={_eredmeny1}, x2={_eredmeny2}.";

    }
}
