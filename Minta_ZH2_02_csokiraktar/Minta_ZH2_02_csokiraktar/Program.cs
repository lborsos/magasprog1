/*
A projekt célja egy olyan alkalmazás megvalósítása, egy csokoládékat forgalmazó kereskedésben
található termékek adataival dolgozik.
A mellékelt MP1_ZH2_minta_02_csokiraktar.csv input fájl minden sorában
egy-egy tétel adatait találja pontosvesszővel elválasztva egymástól az alábbi struktúrában.
-----------------------------------------------------------------
Azonosító                   szöveg
Márka                       szöveg
Típus                       szöveg (tej vagy ét)
Ízesítés                    szöveg
Szavatosság                 dátum év.hónap.nap formátumban
Ár                          egész szám (Ft)
Tömeg                       egész szám (gramm)
Raktáron levő mennyiség     egész szám
-----------------------------------------------------------------
1. Feladat. 

Az input fájl beolvasását az alábbiak szerint végezze el!
a) Készítsen osztályt, mely a fájlban található csokoládék tárolására alkalmas!
b) Azt, hogy a csokoládé ét- vagy tejcsokoládé logikai típusú változóban tárolja!
c) Készítsen listát, mely az osztály a példányainak tárolására alkalmas!
d) Olvassa be az MP1_ZH2_minta_02_csokiraktar.csv fájl-t, és a soronként
elkészített példányokat mentse el az ere a célra létrehozott listába! Figyeljen arra,
hogy a fájl tartalmaz fejlécet!

2. Feladat. 

A raktárban ellenőrzést végeznek, hogy véletlenül se kerüljön lejárt termék a
boltok polcaira. Írja ki a képernyőre azon termékeket, melyeknek lejárt a szavatosságuk,
és van belőlük készleten! Az eredményeket a minta szerint jelenítse meg!
Írja ki a képernyőre, hogy ha ezeket a termékeket mind megsemmisítik, akkor mekkora
mennyiségű csokoládé kerül ki a raktárból!

2. feladat

ABCF4T: Milka - töltetlen (ét) (2022 november 20)
DF3D6G: Boci - mogyorós (tej) (2022 december 12)
...
Ezek megsemmisítésével 32,05 kg csokoládé kerül ki a raktárból.

3. Feladat. 

Készítsen logikai függvényt, mely eldönti, hogy van-e a paraméterben kapott
termékek között olyan, melynek adott a gyártója és az ízesítése. A függvény neve kezdődjön
az "F3_" prefixummal! Az függvény paraméterei:
– Az összes csokoládé terméket tartalmazó lista: ezt vizsgáljuk
– Gyártó
– Ízesítés

4. Feladat. 

Egy vásárló csokoládét szeretne venni, de nem minden ízesítés érdekli! Segítse
a vásárlást az alábbi feladatok megoldásával!
a) Kérje be a felhasználótól a gyártót!
b) Kérje be a felhasználótól az ízesítést!
c) A 3. feladatban elkészített függvény segítségével döntse el, hogy van-e olyan termék
   a listában, ami az inputnak megfelel. Ha nincs, értesítse erről a felhasználót!
d) Amennyiben van (vagy vannak), úgy írja ki a képernyőre a csokoládék azonosítóját,
   tömegét, árát, valamint azt, hogy van-e raktáron!

5. Feladat. 

Az ünnepek előtt leárazást fog eszközölni a raktár, de csak a prémium csokoládék
esetében! Készítsen eljárást, melynek feladata listába gyűjteni azon csokoládékat,
melyek egy adott összegnél drágábbak! Az eljárás neve kezdődjön az "F5_" prefixummal!
Az eljárás paraméterei:
– Az összes terméket tartalmazó lista: ebből válogatunk
– Csokoládék tárolására alkalmas lista: a listát ürítjük, majd ebbe gyűjtjük össze a
feltételnek megfelelő termékeket
– Árhatár

6. Feladat. 

A kedvezményes árat annak alapján számoljuk, hogy milyen típusú az adott
csokoládé, és hogy mennyi van belőle készleten.
– Ha a termék lejárt, akkor az ár 0 Ft! Minden egyéb esetben az alábbiak szerint számolunk!
– A tejcsokoládék árát 25%-kal, míg az étcsokoládék árát 30%-kal csökkentjük.
– Ha az adott termékből legalább 60 db van készleten, úgy az árat további 6%-kal csökkentjük!

Készítsen egész értékkel visszatérő függvényt, melynek neve az "F6_" prefixummal kezdődik!
a) A függvénynek egyetlen paramétere van, egy adott termék.
b) Számítsa ki a termék akciós árát és annak egészre kerekített értékével térjen vissza!

7. Feladat. 

A 5. feladatban elkészített eljárás segítségével válogassa ki egy Ön által
létrehozott listába a 650 Ft-nál drágább csokoládékat, és írja ki azokat, melyeknek még
nem járt le a szavatosságuk a képernyőre az alábbi formátumban!

7. feladat FRGH6HJ: Milka (mogyorós) Ár: 760 Ft, Akciós ár: 563 Ft
EB6H8JK: Americana (banános) Ár: 845 Ft, Akciós ár: 648 Ft

8. Feladat. Törölje a listából az NBKL5NQ azonosítóval rendelkező terméket!

9. Feladat. Gyártónként írja ki a képernyőre a legmagasabb eredeti árral rendelkező
termék ízesítését! Írja ki a képernyőre azt is, hogy ha ebből mindent eladnánk, akkor
mennyi bevételünk lenne! (Előfordulhat, hogy ebből éppen nincs raktáron, de ezzel nem
kell foglalkoznia!)
3 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minta_ZH2_02_csokiraktar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime curDate = new DateTime(2022, 11, 01);
            List<Csokolade> csokoladek = new List<Csokolade>();
            beolvas(csokoladek);

            /*
                A raktárban ellenőrzést végeznek, hogy véletlenül se kerüljön lejárt termék a
                boltok polcaira. Írja ki a képernyőre azon termékeket, melyeknek lejárt a szavatosságuk,
                és van belőlük készleten! Az eredményeket a minta szerint jelenítse meg!
                Írja ki a képernyőre, hogy ha ezeket a termékeket mind megsemmisítik, akkor mekkora
                mennyiségű csokoládé kerül ki a raktárból!

                2. feladat

                ABCF4T: Milka - töltetlen (ét) (2022 november 20)
                DF3D6G: Boci - mogyorós (tej) (2022 december 12)
                ...
                Ezek megsemmisítésével 32,05 kg csokoládé kerül ki a raktárból.
             */

            int lejartOsszTomeg = 0;
            Console.WriteLine("2. feladat\n");
            foreach (Csokolade csokolade in csokoladek)
            {
                if (csokolade.szavatossag < curDate && csokolade.keszleten > 0)
                {
                    // Azt nem ertem, hogy a tomeg az 1 csokoladera vonatkozike? vagy az egeszre? 
                    lejartOsszTomeg += csokolade.tomeg; // * csokolade.keszleten;
                    Console.WriteLine("{0}: {1} - {2} ({3}) ({4})", csokolade.id, csokolade.marka, csokolade.izesites, csokolade.tej ? "tej" : "ét", csokolade.szavatossag.ToString("yyyy.MM.dd"));
                }
            }
            Console.WriteLine("Ezek megsemisitesevel {0} kg csokolade kerul ki a raktarbol!\n", lejartOsszTomeg / 1000d);

            Console.Write("Gyarto: ");
            string bekerGyarto = Console.ReadLine();
            Console.Write("Izesites: ");
            string bekerIzesites = Console.ReadLine();

            if (F3_vane(csokoladek, bekerGyarto, bekerIzesites))
            {
                // csokoládék azonosítóját, tömegét, árát, valamint azt, hogy van - e raktáron!
                foreach (Csokolade csokolade in csokoladek)
                {
                    if (csokolade.marka.ToUpper() == bekerGyarto.ToUpper() && csokolade.izesites.ToUpper() == bekerIzesites.ToUpper())
                    {
                        Console.WriteLine("{0}: {1,3} gramm, {2,4} Ft, {3}", csokolade.id, csokolade.tomeg, csokolade.ar, csokolade.keszleten > 0 ? "van raktaron" : "nincs raktaron");
                    }
                }
                
            }
            else Console.WriteLine("Nincs ilyen csokolade!");

            List<Csokolade> szurtCsokik = new List<Csokolade>();
            f5_premium(csokoladek, szurtCsokik, 650);
            /*

                    FRGH6HJ: Milka (mogyorós) Ár: 760 Ft, Akciós ár: 563 Ft
                    EB6H8JK: Americana (banános) Ár: 845 Ft, Akciós ár: 648 Ft             */

            Console.WriteLine("\n 7. feladat");
            foreach (Csokolade csokolade in szurtCsokik)
            {
                if (csokolade.szavatossag <= new DateTime(2022, 09, 01))
                {
                    Console.WriteLine("{0}: {1} ({2}) Ar: {3} Ft, Akcios ar: {4} Ft", csokolade.id, csokolade.marka, csokolade.izesites, csokolade.ar, F6_kedvezmeny(csokolade));
                }
            }

            int index = -1;
            for (int i = 0; i < csokoladek.Count; i++)
            {
                if (csokoladek[i].id == "NBKL5NQ")
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                csokoladek.RemoveAt(index);
            }

            Console.WriteLine("\n 9. feladat");
            List<string> markak = new List<string>();
            foreach (Csokolade csokolade in csokoladek)
            {
                if (!markak.Contains(csokolade.marka))
                {
                    markak.Add(csokolade.marka);
                }
            }
            foreach (string marka in markak)
            {
                Csokolade maxAr = new Csokolade();
                foreach (Csokolade csokolade in csokoladek)
                {
                    if (csokolade.marka == marka && csokolade.ar > maxAr.ar)
                    {
                        maxAr = csokolade;
                    }
                }
                Console.WriteLine("{2} - {0}, ha mindent eladnank akkor {1} Ft bevetelunk lenne!", maxAr.izesites, maxAr.ar * maxAr.keszleten, maxAr.marka);
            }


        }

        private static int F6_kedvezmeny(Csokolade csokolade)
        {
            double kedvAr = csokolade.ar;
            if (csokolade.szavatossag > DateTime.Now)
            {
                if (csokolade.tej)
                {
                    kedvAr -= kedvAr * 0.25d;
                }
                else
                {
                    kedvAr -= kedvAr * 0.3d;
                }
                if (csokolade.keszleten > 60)
                {
                    kedvAr -= kedvAr * 0.06d;
                }
            }
            else kedvAr = 0;
            return (int)Math.Round(kedvAr);
        }
        private static void f5_premium(List<Csokolade> csokoladek, List<Csokolade> szurtCsokik, int arHatar)
        {
            szurtCsokik.Clear();
            foreach (Csokolade csokolade in csokoladek)
            {
                if (csokolade.ar > arHatar)
                {
                    szurtCsokik.Add(csokolade);
                }
            }
        }
        private static bool F3_vane(List<Csokolade> csokoladek, string marka, string izesites)
        {
            bool van = false;
            foreach (Csokolade csokolade in csokoladek)
            {
                if (csokolade.marka.ToUpper() == marka.ToUpper() && csokolade.izesites.ToUpper() == izesites.ToUpper())
                {
                    van = true;
                }
            }
            return van;
        }
        private static void beolvas(List<Csokolade> csokoladek)
        {

                /*
                Azonosító                   szöveg
                Márka                       szöveg
                Típus                       szöveg(tej vagy ét)
                Ízesítés                    szöveg
                Szavatosság                 dátum év.hónap.nap formátumban
                Ár                          egész szám(Ft)
                Tömeg                       egész szám(gramm)
                Raktáron levő mennyiség     egész szám */

            StreamReader sr = new StreamReader("../../MP1_ZH2_minta02_csokiraktar.csv", Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                Csokolade ujCsokolade = new Csokolade();
                ujCsokolade.id = adatok[0];
                ujCsokolade.marka = adatok[1];
                ujCsokolade.tej = adatok[2] == "tej" ? true : false;
                ujCsokolade.izesites = adatok[3];
                ujCsokolade.szavatossag = DateTime.Parse(adatok[4]);
                ujCsokolade.ar = int.Parse(adatok[5]);
                ujCsokolade.tomeg = int.Parse(adatok[6]);
                ujCsokolade.keszleten = int.Parse(adatok[7]);
                csokoladek.Add(ujCsokolade);
            }
            sr.Close();
        }
    }
}
