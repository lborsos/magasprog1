/*
3. Feladat. 

Egy hentesüzem megkér minket, hogy készítsünk programot, mely mind a
200 füstölt sonkájuk adatát kezeli egy adott időszakban. A programot az alábbiak szerint írja meg!

a) Generálja véletlenszerűen és tárolja el az összes sonka tömegét kg-ban egy tizedesjegy pontossággal! Egy sonka tömege 12 és 30 kg közé esik.

b) Írja ki a képernyőre, hogy hány sonka volt nehezebb, mint az átlagos tömeg 80%-a!

c) Számítsa ki, hogy mennyi pénzért lehetne eladni az összes sonkát, ha az ára 2570 Ft/kg!

d) Írja ki a képernyőre kilogrammonként, hogy hány sonka egészre tört értéke esik egy
csoportba. Pl.:
12 kg: 23 db
13 kg: 15 db
14 kg: 21 db
. . .

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak_fel_2023_2024_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int sonkaDb = 200;
            int sonkaAr = 2750;
            double[] sonkak = new double[sonkaDb];
            Random rnd = new Random();
            for (int i = 0; i < sonkak.Length; i++) sonkak[i] = rnd.Next(120, 301) / 10d;

            double osszTomeg = 0;
            foreach (double sonka in sonkak) osszTomeg += sonka;
            double atlagosTomeg = osszTomeg / sonkaDb;
            int sonkaDb80 = 0;
            foreach (double sonka in sonkak) if (sonka > atlagosTomeg * 0.8) sonkaDb80++;

            Console.WriteLine("{0} sonka volt nehezebb mint az atlagos tomeg 80% a!\n", sonkaDb80);
            Console.WriteLine("A {0} ossztomegu sonkat ({1} Ft/kg) {2} Ft ert lehetne eladni!", osszTomeg, sonkaAr, osszTomeg * sonkaAr);

            for (int i = 12; i <= 30; i++)
            {
                int darab = 0;
                for (int j = 0; j < sonkak.Length; j++)
                {
                    if (Math.Floor(sonkak[j]) == i) darab++;
                }
                Console.WriteLine("{0} Kg: {1,2} db", i, darab);
            }
        }
    }
}
