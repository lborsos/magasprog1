/*

3. Feladat. 

Egy kisebb kínai egyetem kis kampusza számára fejlesztünk alkalmazást,
mely egy adott épület termeinek kihasználtságáról tárol adatokat és készít statisztikákat.
Az épületben minden emeletén 13 terem található, melyek befogadóképessége 45 fő.

a) Kérje be a felhasználótól az épület emeleteinek számát! Oldja meg ellenőrzött adatbekéréssel,
   hogy ez egy 15 és 30 közötti egész szám legyen!

b) Az egyetemen 18 fő alatt nem indítanak kurzust. Hozzon létre egy egydimenziós
   tömböt, mely képes eltárolni minden emelet minden termének létszámadatait!
   Töltse fel ezt a tömböt 18 és 45 közötti egész értékekkel!

c) Számítsa ki és jelenítse meg a képernyőn százalékos formában, hogy mekkora az
   épület kihasználtsága a férőhelyek tekintetében!

d) Állapítsa meg és jelenítse meg a képernyőn, van-e olyan terem, mely maximális
   kihasználtsággal működik (45 fő)!

e) A további feladatokat az emeletek szerinti csoportosítással kell megoldania!

i) Mekkora az egyes szinteken a legmagasabb és legalacsonyabb kihasználtságú termek közötti különbség?

ii) Van-e olyan emelet, mely minimális kihasználtságú? (Minden teremben 18 fő tanul.) 
 
*/



using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int szintenLevoTermekSzama = 13;
            const int termekBefogadokepessege = 45;
            const int minLetszam = 18;
            int emeletekSzama = 0;
            int errCount = 0;

            // a)
            do
            {
                Console.Write(errCount > 0 ? "Hibasan megadott adat! Add meg ujra!\n\n" :"");
                Console.Write("Add meg az epulet emeleteinek szamat (15 - 30): ");
                errCount++;
            } while (!int.TryParse(Console.ReadLine(), out emeletekSzama) || emeletekSzama < 15 || emeletekSzama > 30);

            // b)
            int[] termekLetszama = new int[emeletekSzama * szintenLevoTermekSzama];
            Random rnd = new Random();
            for (int i = 0; i < termekLetszama.Length; i++)
            {
                termekLetszama[i] = rnd.Next(minLetszam, termekBefogadokepessege + 1);
            }
            kiir(termekLetszama, emeletekSzama, szintenLevoTermekSzama);

            // c)
            int osszLetszam = 0;
            foreach (var item in termekLetszama)
            {
                osszLetszam += item;
                // Console.Write(" {0}", item);
            }
            double epuletKihasznaltsaga = Math.Round((double)osszLetszam / ((szintenLevoTermekSzama * emeletekSzama * termekBefogadokepessege)) * 100d,2);
            Console.WriteLine("\nAz eplet kihasznaltsaga {0} %", epuletKihasznaltsaga);

            // d)
            for (int i = 0; i < termekLetszama.Length; i++)
            {
                if (termekLetszama[i] == termekBefogadokepessege)
                    Console.WriteLine("A {0,3} emeleten a {1,3} -es terem Max kihasznaltsagu!", (i) / szintenLevoTermekSzama + 1, (i) % szintenLevoTermekSzama + 1);
            }
            Console.WriteLine();

            // e)
            bool csak18 = true;
            for (int i = 0; i < emeletekSzama; i++)
            {
                int minItem = termekBefogadokepessege;
                int maxItem = 0;
                int elem;
                for (int j = 0; j < szintenLevoTermekSzama; j++)
                {
                    elem = termekLetszama[i * szintenLevoTermekSzama + j];
                    minItem = elem < minItem ? elem : minItem;
                    maxItem = elem > maxItem ? elem : maxItem;
                    if (elem != minLetszam) csak18 = false;
                }
                Console.WriteLine("A {0,2} emeleten a kihasznaltsagi kulombseg: {1}", i + 1, maxItem - minItem);
            }
            Console.WriteLine(csak18 ? "\nVan minimum kihasznaltsagu emelet!" : "\nNincs minimum kihasznaltsagi emelet!");

            Console.ReadLine();
        }

        static void kiir(int[] termekLetszama, int emeletekSzama, int szintenLevoTermekSzama)
        {
            for (int i = 0; i < termekLetszama.Length; i++)
            {
                Console.Write(" {0,3}", termekLetszama[i]);
                Console.Write(((i + 1) % szintenLevoTermekSzama) == 0 ? "\n" : "");
            }
            Console.WriteLine();
        }
    }
}
