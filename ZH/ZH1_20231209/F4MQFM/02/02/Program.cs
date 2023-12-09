/*
 
2. Feladat. 

Egy cukorkákat forgalmazó kimérős bolt számára fejlesztünk alkalmazást. 
A cukorkákat a felhasználó válogatja össze díszdobozba, melyek mindegyikébe 150 gramm
termék helyezhető el. Minden egyes díszdoboz ára 110 Ft. A megvásárolható cukorkákat
az alábbi táblázatban foglaltuk össze.
-------------------------------------------------------------
Megnevezések                        Tömeg           Ár
-------------------------------------------------------------
sima, savanyú                       10 gramm        120 Ft
epres, narancsos, málnás, kivis     20 gramm        180 Ft
étcsokis, tejcsokis                 30 gramm        250 Ft
-------------------------------------------------------------
Extra feladat: Az egyes terméktípusokat tárolja tömbökben a program könnyű bővíthetőségének
érdekében, és az egyes feladatokat ezek segítségével oldja meg!

A dobozokat nem csak teljesen megtöltve lehet megvásárolni, viszont egy dobozt mindig
teljesen fel kell tölteni, mielőtt új dobozt nyitnánk! Ha egy cukorkát beraktunk a dobozba, már nem vehetjük ki!
Készítsen alkalmazást, mely a cukorkák összeválogatását és a végső ár kiszámítását végzi az alábbiak szerint!

a) Folyamatosan kérje be a felhasználótól, hogy milyen cukorkákat szeretne megvásárolni!

b) A termékek bekérését és a fizetési szándékot a "fizetnék" kifejezés beírásával jelzi a felhasználó.

c) Jelenítse meg a képernyőn, hogy a felhasználó hány dobozt kezdett meg, és mennyi a fizetendő végösszeg!

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const ushort dobozAr = 110;
            const ushort dobozFer = 150;
            string[] cukorkak = { "1. sima, savanyú                     10 gramm    120 Ft",
                                  "2. epres, narancsos, málnás, kivis   20 gramm    180 Ft",
                                  "3. étcsokis, tejcsokis               30 gramm    250 Ft" };
            ushort[] cukorkaAr = { 120, 180, 250 };
            ushort[] cukorkaTomeg = { 10, 20, 30 };
            ushort[] bekertCukorka = { 0, 0, 0};

            bool vege = false;
            int kiszamoltAr = 0;
            ushort kiszamoltDoboz = 0;
            ushort dobozbaFerMeg = dobozFer;
            do
            {
                string bekertErtek;
                ushort kivalasztotElem;
                Console.WriteLine("\nEddig rendeles erteke: {0} Ft, Felhasznalt doboz: {1} db; Fer meg a dobozba: {2} gramm {3}\n", kiszamoltAr, kiszamoltDoboz, dobozbaFerMeg, dobozFer);
                cukorkakKiirasa(cukorkak);
                do
                {
                    bekertErtek = Console.ReadLine();
                    if (bekertErtek == "fizetek")
                    {
                        vege = true;
                        break;
                    }
                    if (ushort.TryParse(bekertErtek, out kivalasztotElem) && kivalasztotElem > 0 && kivalasztotElem <= cukorkak.Length)
                    {
                        if (dobozbaFerMeg >= cukorkaTomeg[kivalasztotElem - 1])
                        {
                            bekertCukorka[kivalasztotElem - 1]++;
                            break;
                        } else Console.WriteLine("A kivalasztott cukorka mar nem fer be a dobozba, valassz masikot!");
                    }
                    Console.Write("Rosszul megadott adat!, add meg ujra: ");

                } while (true);
                kiszamoltAr = kiszamol(cukorkaAr, cukorkaTomeg, bekertCukorka, dobozAr, dobozFer, out kiszamoltDoboz, out dobozbaFerMeg);
            } while (!vege);

            Console.WriteLine("Fizetendo: {0} Ft, felhasznalt doboz: {1}", kiszamoltAr, kiszamoltDoboz);
        }

        static void cukorkakKiirasa(string[] cukorkak)
        {
            foreach (string item in cukorkak)
            {
                Console.WriteLine(item);

            }
            Console.Write("Valassz (1...{0}) (\"fizetek\" kilep): ", cukorkak.Length);
        }

        
        static int kiszamol(ushort[] cukorkaAr, ushort[] cukorkaTomeg, ushort[] bekertCukorka, ushort dobozAr, ushort dobozFer, out ushort kiszamoltDoboz, out ushort dobozbaFerMeg)
        {
            int ar = 0;
            int gramm = 0;
            int maradek = 0;
            for (int i = 0; i < cukorkaAr.Length; i++)
            {
                ar += cukorkaAr[i] * bekertCukorka[i];
                gramm += cukorkaTomeg[i] * bekertCukorka[i];
            }
            kiszamoltDoboz = (ushort)(gramm / dobozFer);
            
            maradek = (ushort)(gramm % dobozFer);
            if (maradek != 0)
            {
                dobozbaFerMeg = (ushort)(dobozFer - maradek);
                kiszamoltDoboz++;
            }
            else dobozbaFerMeg = dobozFer;
            ar += kiszamoltDoboz * dobozAr;
            return ar;
        }
    }
}
