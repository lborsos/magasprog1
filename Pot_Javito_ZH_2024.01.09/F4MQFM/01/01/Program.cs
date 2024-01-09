using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kartonokSzama;
            do
            {
                Console.Write("Add meg hany kartont... (30 - 45): ");
            } while (!int.TryParse(Console.ReadLine(), out kartonokSzama) || kartonokSzama < 30 || kartonokSzama > 45);

            int[] panettone = new int[kartonokSzama * 20];


            Random rnd = new Random();
            for (int i = 0; i < panettone.Length; i++)
            {
                panettone[i] = rnd.Next(680, 821);
            }

            // i)

            double atlag700_740 = atlagol(panettone, 700, 740);
            double atlag690_750 = atlagol(panettone, 690, 750);
            if (atlag700_740 > atlag690_750)
            {
                Console.WriteLine("A 700 - 740 nek nagyobb az atlaga!");
            } else
            {
                Console.WriteLine("A 690 - 750 nek nagyobb az atlaga!");
            }


            for (int i = 0; i < panettone.Length / 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (panettone[i * 20 + j] > 800)
                    {
                        Console.WriteLine("{0} kartonba van 800 gr nal nagyobb!", i + 1);
                        break;
                    }
                }
            }

            double[] karton = new double[kartonokSzama];

            double osszeg = 0;
            for (int i = 0; i < panettone.Length / 20; i++)
            {
                osszeg = 0;
                for (int j = 0; j < 20; j++)
                {
                    osszeg += panettone[i * 20 + j];
                }
                karton[i] = Math.Round((osszeg / 20 / 1000), 2);
            }

            bool eleri = true;
            for (int i = 0; i < kartonokSzama; i++)
            {
                if (karton[i] < 0.78d)
                {
                    eleri = false;
                }
            }

            if (eleri)
            {
                Console.WriteLine("Eleri");
            }
            else
            {
                Console.WriteLine("Nem eri el");
            }

        }


        static double atlagol(int[] pant, int alsoh, int felsoh)
        {
            double atlag = 0;
            int couunt = 0;
            double ossz = 0;
            for (int i = 0; i < pant.Length; i++)
            {
                if (pant[i] >= alsoh && pant[i] <= felsoh)
                {
                    ossz += pant[i];
                    couunt++;
                }
            }
            return Math.Round((ossz / couunt / 1000), 2);

        }

        static double atlag(int[] tomb)
        {
            double osszeg = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                osszeg += tomb[i];
            }
            return Math.Round((osszeg / tomb.Length / 1000), 2);
        }
    }
}
