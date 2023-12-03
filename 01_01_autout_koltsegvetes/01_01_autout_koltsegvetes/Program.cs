/*1.1.Feladat.Tervezze meg egy autóút költségvetését! Ehhez kérje be az autó fogyasztását
100 km-re vonatkozólag, a tervezett út hosszát km-ben, az esetleges útdíjak összegét,
valamint a tankolt üzemanyag literenkénti árát!
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_01_autout_koltsegvetes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Az auto fogyasztása (100 km): ");
            float consum100;
            //            consum100 = float.Parse(Console.ReadLine());
            while (!float.TryParse(Console.ReadLine(), out consum100))
            {
                Console.WriteLine("Hibás érték! Add meg ujra! ");
            }

            Console.Write("A tervezett ut hossza km): ");
            ushort distanceKm;
            while (!ushort.TryParse(Console.ReadLine(), out distanceKm))
            {
                Console.WriteLine("Hibás érték! Add meg ujra! ");
            }

            Console.Write("Utdijak: ");
            ushort trafficTaxes;
            while (!ushort.TryParse(Console.ReadLine(), out trafficTaxes))
            {
                Console.WriteLine("Hibás érték! Add meg ujra! ");
            }

            Console.Write("tankolt uzemanyag literenkenti ara: ");
            float fuelPrice;
            while (!float.TryParse(Console.ReadLine(), out fuelPrice))
            {
                Console.WriteLine("Hibás érték! Add meg ujra! ");
            }

            ushort totalPrice = (ushort)((distanceKm / 100f) * consum100 * fuelPrice + trafficTaxes);

            Console.WriteLine("A tervezett {0} km es uton, uzemanyag ar: {1} Ft, utdijak: {2} Ft, Fogyasztas: {3} l mellet az osszkoltseg: {4} Ft", distanceKm, fuelPrice, trafficTaxes, consum100, totalPrice);

            Console.ReadLine();
        }
    }
}
