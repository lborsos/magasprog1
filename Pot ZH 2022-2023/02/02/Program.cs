/*
2. Feladat. 

A mátraderecskei horgászversenyen mindenki egyetlen hallal nevezhet (jellemzően 
mindenki az aznapi legnagyobbat adja be). Ezen halak adatait kell kezelnie a programban.

a) Kérje be ellenőrzötten a felhasználótól, hogy hány versenyző indult! A versenyzők
   száma egy 15 és 100 közötti egész érték!

b) Hozzon létre egy egész értékek tárolására alkalmas tömböt, melyben az összes be-
   nevezett hal tömegét el lehet tárolni!

c) Töltse fel a tömböt véletlen egészekkel a [1500, 25000] intervallumból! Tekintse eze-
   ket az egyes versenyzők által beadott halak gramm-ban mért tömegeinek!

d) Írja ki a képernyőre a halak átlagos tömegét!

e) Készítsen valós értékkel visszatérő függvényt, melynek feladata egy grammban ka-
   pott tömeg kg-ba átváltott értékének visszaadása. A függvénynek egy paramétere
   van, egy egész szám.

1 kg = 1000 g

f) Írja ki a képernyőre a legnagyobb hal tömegét kg-ban és a versenyző sorszámát!

g) A 8 kg-nál kisebb halakat haza lehet vinni 2350 F t/kg áron. Írja ki a képernyőre
   mekkora bevétele lesz a verseny szervezőinek, ha az összes ilyen halat kiárusítják! */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int versenyzokSzama = 0;
            do
            {
                Console.Write("Versenyzok szama (15 - 100): ");
            } while (!int.TryParse(Console.ReadLine(), out versenyzokSzama) || versenyzokSzama < 15 || versenyzokSzama > 100);
            int[] halTomegek = new int[versenyzokSzama];
            Random rnd = new Random();
            for (int i = 0; i < versenyzokSzama ; i++)
            {
                halTomegek[i] = rnd.Next(1500, 25001);
            }

            double atlagTomeg, osszTomeg = 0d;
            for (int i = 0; i < versenyzokSzama - 1; i++)
            {
                osszTomeg += halTomegek[i];
            }
            atlagTomeg = Math.Round(osszTomeg / versenyzokSzama);
            Console.WriteLine("Atlagos tomeg: {0} gr", atlagTomeg);

            int sorsz, legnagyobbTomeg = 0;
            for (int i = 0; i < versenyzokSzama; i++)
            {
                if (halTomegek[i] > legnagyobbTomeg)
                {
                    sorsz = i;
                    legnagyobbTomeg = halTomegek[i];
                }
            }
            Console.WriteLine("Legnagobb hal tomege: {0} kg", grToKg(legnagyobbTomeg));

            int halArKg = 2350;
            int xKIlonalKisseb = 8;

            int osszTomegK8K = 0;
            for (int i = 0; i < versenyzokSzama; i++)
            {
                if (halTomegek[i] < xKIlonalKisseb * 1000)
                {
                    osszTomegK8K += halTomegek[i];
                }
            }
            double bevetel = Math.Round(grToKg(osszTomegK8K) * halArKg);
            Console.WriteLine("Bevetel: {0} Ft",  bevetel);

            Console.ReadLine();
        }
        static double grToKg(int gramm)
        {
            return gramm / 1000d;
        }
    }
}
