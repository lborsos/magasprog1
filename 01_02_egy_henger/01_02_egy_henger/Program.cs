/* 1.2.Feladat.Egy henger alakú tartály lefestését tervezzük. Írjon programot, mely kiszámítja,
hány doboz festéket kell megvásárolnunk! Ehhez kérje be a tartály átmérőjét és
magasságát méterben, valamint a festék dobozonkénti fedőképességét m2-ben! */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02_egy_henger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Add meg a tartály átmérőjét (m): ");
            ushort tartalyAtmero;
            while (!ushort.TryParse(Console.ReadLine(), out tartalyAtmero))
            {
                Console.WriteLine("Hibás átmérő! add meg újra!");
            }

            Console.Write("Add meg a tartály magassága (m): ");
            ushort tartalyMagassag;
            while (!ushort.TryParse(Console.ReadLine(), out tartalyMagassag))
            {
                Console.WriteLine("Hibás átmérő! add meg újra!");
            }

            Console.Write("Add meg dobozonkánti fedökápesságet (m2): ");
            double fedokepessegM2;
            while (!double.TryParse(Console.ReadLine(), out fedokepessegM2))
            {
                Console.WriteLine("Hibás adat! add meg újra!");
            }

            double feluet = Math.PI * tartalyAtmero * tartalyMagassag;

            ushort dobozDb;
            dobozDb = (ushort)(feluet / fedokepessegM2);
            if (feluet % fedokepessegM2 != 0)
            {
                dobozDb++;
            }
            Console.WriteLine("A felület {0} m2, A szükságes dobozok száma: {1} db", feluet, dobozDb);

            Console.ReadLine();
        }
    }
}
