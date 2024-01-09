/*
A projekt célja egy olyan alkalmazás megvalósítása, egy használtautó kereskedésben
található gépjárművek adataival dolgozik.
A mellékelt MP1_ZH2_minta_01_autok.csv input fájl minden sorában egy-egy
gépjármű adatait találja pontosvesszővel elválasztva egymástól az alábbi struktúrában.
--------------------------------------------------------
Rendszám                szöveg
Forgalmi érvényesség    dátum év.hónap.nap formátumban
Gyártó                  szöveg
Állapot                 szöveg
Klíma                   szöveg
Váltó                   szöveg (manuális vagy automata)
Ár                      egész szám (az autó eredeti ára)
Évjárat                 egész szám
--------------------------------------------------------
1. Feladat. 
Az input fájl beolvasását az alábbiak szerint végezze el!
a) Készítsen osztályt, mely a fájlban található autók tárolására alkalmas!
b) Az, hogy az autó manuális váltós-e logikai típusú változóban tárolja!
c) Készítsen listát, mely az osztály a példányainak tárolására alkalmas!
d) Olvassa be az MP1_ZH2_minta_01_autok.csv fájl-t, és a soronként elkészített
   példányokat mentse el az ere a célra létrehozott listába! Figyeljen arra, hogy a
   fájl tartalmaz fejlécet!

2. Feladat. 
Írja ki a képernyőre azon gépjárműveket, melyeknek lejárt a forgalmi engedélyük!
Az eredményeket a minta szerint jelenítse meg!
XYZ-345 - BMW (2021 október 20)
XYZ-346 - Renault (2021 november 21)

3. Feladat. 
Készítsen logikai függvényt, mely eldönti, hogy van-e a paraméterben kapott
járművek között olyan, melynek adott a gyártója és az állapota. A függvény neve kezdődjön
az "F3_" prefixummal! Az függvény paraméterei:
– Az összes járművet tartalmazó lista: ezt vizsgáljuk
– Gyártó
– Állapot

4. Feladat. 
Írja ki a képernyőre a vásárló számára érdekes járműveket az alábbiak szerint!
a) Kérje be a felhasználótól a gyártót!
b) Kérje be a felhasználótól az állapotot!
c) A 3. feladatban elkészített függvény segítségével döntse el, hogy van-e olyan jármű
   a listában, ami az inputnak megfelel. Ha nincs, értesítse erről a felhasználót!
d) Amennyiben van (vagy vannak), úgy írja ki a képernyőre a járművek rendszámát, a
   váltó- és klíma tapusát, valamint az eredeti árat!

5. Feladat. 
Készítsen eljárást, melynek feladata listába gyűjteni azon járműveket, melyek
egy adott gyártó termékei. Az eljárás neve kezdődjön az "F5_" prefixummal! Az eljárás
paraméterei:
– Az összes járművet tartalmazó lista: ebből válogatunk
– Járművek tárolására alkalmas lista: a listát ürítjük, majd ebbe gyűjtjük össze a
feltételnek megfelelő autókat
– Gyártó

6. Feladat. 
A 5. feladatban elkészített eljárás segítségével válogassa ki egy Ön által létrehozott
listába a Nissan autókat, és írja ki azokat a képernyőre az alábbi formátumban,
majd jelenítse meg azok átlagos eredeti árát!
XYZ-123 - újszerű, manuális váltó, évjárat: 2014
XYZ-124 - sérült, manuális váltó, évjárat: 2016
...
Az autók átlagos ára: 2543100,54 Ft.

7. Feladat. 
Törölje a listából az egyik járművet az alábbiak szerint!
a) Kérje be a felhasználótól egy jármű rendszámát! Kezelje azt is, ha a felhasználó nem
csak nagybetűket használ!
b) Amennyiben nincs ilyen jármű a listában, úgy értesítse a felhasználót erről!
c) Törölje a járművet a listából!


8. Feladat. 
Az autóknak a hirdetési árát számítással kapjuk. Attól függően, hogy az
autónak milyen az állapota, évenként amortizálódik az ára, továbbá az egyes klíma típusok
felárat jelentenek. Ezeket az alábbi táblázatokban látja.
------------------------------------
Állapot             Éves amortizáció
újszerű             11%
megkímélt           20%
sérült              35%
hibás               42%
------------------------------------

Klíma               Felár
nincs               0 Ft
manuális            120000 Ft
digitális           245000 Ft
digitális-többzónás 320000 Ft
------------------------------------

A becsült árat az alábbi képlettel kapjuk:

eredetiAr · amortizacioel etkorEvekben + klimaFelar

Az eltelt éveket elég egyszerű kivonással számolni az aktuális évből az évjárat alapján!
Készítsen egész értékkel visszatérő függvényt, melynek neve az "F8_" prefixummal kezdődik!
a) A függvénynek egyetlen paramétere van, egy adott gépjármű.
b) Az eredményt kerekítse egészre és azzal térjen vissza!
9. Feladat. Gyártónként írja ki a képernyőre a legmagasabb hirdetési árral rendelkező
járművet! Ha nem sikerült megoldania a 8. feladatot, akkor számoljon a járművek eredeti
árával!
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MP1_ZH2_minta01_autok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>();
            beolvas(autok);

            // 1.
            foreach (Auto auto in autok)
            {
                if (auto.ervenyesseg < DateTime.Now)
                {
                    Console.WriteLine("{0} - {1} ({2})", auto.rendszam, auto.gyarto, auto.ervenyesseg.ToString("yyyy MMMM dd"));
                }
            }

            // 4.
            // d) Amennyiben van (vagy vannak), úgy írja ki a képernyőre a járművek rendszámát, a
            // váltó - és klíma tapusát, valamint az eredeti árat!

            Console.Write("\nGyarto: ");
            string gyarto = Console.ReadLine();
            Console.Write("\nAllapot: ");
            string allapot = Console.ReadLine();

            bool van = false;
            foreach (Auto auto in autok)
            {
                if (F3_gyartoAllapot(autok, gyarto, allapot))
                {
                    van = true;
                    Console.WriteLine("{0} - {1}, {2}, {3} Ft", auto.rendszam, auto.auomatta ? "automatta" : "manuális", auto.klima, auto.ar);
                }
            }
            if (!van)
            {
                Console.WriteLine("Nem talalhato auto a keresesre!\n");
            }

            // 6.
            // XYZ-123 - újszerű, manuális váltó, évjárat: 2014

            List<Auto> autokGyarto = new List<Auto>();
            F5_gyartoList(autok, autokGyarto, "Nissan");
            foreach (Auto auto in autokGyarto)
            {
                Console.WriteLine("{0} - {1}, {2} váltó, évjárat: {3}", auto.rendszam, auto.allapot, auto.auomatta ? "automatta" : "manuális", auto.evjarat);
            }

            Console.Write("Torlendo jarmu rendszama: ");
            string rendszam = Console.ReadLine().ToUpper();
            int index = -1;
            for (int i = 0; i < autok.Count; i++)
            {
                if (autok[i].rendszam == rendszam)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                Console.WriteLine("Nincs ilyen randszam a listaban!");
            } else
            {
                autok.RemoveAt(index);
            }

            // 9.
            /*
9. Feladat. Gyártónként írja ki a képernyőre a legmagasabb hirdetési árral rendelkező
járművet! Ha nem sikerült megoldania a 8. feladatot, akkor számoljon a járművek eredeti
árával!             */

            List<string> gyartok = new List<string>();
            foreach (Auto auto in autok)
            {
                if (!gyartok.Contains(auto.gyarto))
                {
                    gyartok.Add(auto.gyarto);
                }
            }

            foreach (string gy in gyartok)
            {
                Auto ujAuto = new Auto();
                foreach (Auto auto in autok)
                {
                    if (gy == auto.gyarto && F8_becsutAr(auto) > F8_becsutAr(ujAuto))
                    {
                        ujAuto = auto;
                    }
                }
                Console.WriteLine("{0,-10} - {1, -10} {2,-20} {3:#,##0} Ft", gy, ujAuto.allapot, ujAuto.klima, F8_becsutAr(ujAuto));
            }

            Console.ReadLine();
        }


        private static int F8_becsutAr(Auto auto)
        {
            double szamotAt = 0;
            int amort = 0, felar = 0, eletkor = 0;
            switch (auto.allapot)
            {
                case "újszerű":
                    amort = 11;
                    break;
                case "megkímélt":
                    amort = 20;
                    break;
                case "sérült":
                    amort = 35;
                    break;
                case "hibás":
                    amort = 42;
                    break;
            }

            switch (auto.klima)
            {
                case "nincs":
                    felar = 0;
                    break;
                case "manuális":
                    felar = 120000;
                    break;
                case "digitális":
                    felar = 245000;
                    break;
                case "digitális-többzónás":
                    felar = 320000;
                    break;
            }

            eletkor = DateTime.Now.Year - auto.evjarat;

            szamotAt = auto.ar * (double)amort / 100 * eletkor + felar;

            return (int)(Math.Round(szamotAt));
        }

        private static void F5_gyartoList(List<Auto> autok, List<Auto> autokGyarto, string gyarto)
        {
            autokGyarto.Clear();
            foreach (Auto auto in autok)
            {
                if (auto.gyarto.ToUpper() == gyarto.ToUpper())
                {
                    autokGyarto.Add(auto);
                }
            }
        }
        private static bool F3_gyartoAllapot(List<Auto> autok, string gyarto, string allapot)
        {
            foreach (Auto auto in autok)
            {
                if (auto.gyarto.ToUpper() == gyarto.ToUpper() && auto.allapot.ToUpper() == allapot.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        private static void beolvas(List<Auto> autok)
        {
            StreamReader sr = new StreamReader("../../MP1_ZH2_minta01_autok.csv", Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                Auto ujAuto = new Auto();
                ujAuto.rendszam = adatok[0];
                ujAuto.ervenyesseg = DateTime.Parse(adatok[1]);
                ujAuto.gyarto = adatok[2];
                ujAuto.allapot = adatok[3];
                ujAuto.klima = adatok[4];
                ujAuto.auomatta =  adatok[5] == "automata" ? true : false;
                ujAuto.ar = int.Parse(adatok[6]);
                ujAuto.evjarat = int.Parse(adatok[7]);
                autok.Add(ujAuto);
            }
            sr.Close();
        }
    }
}
