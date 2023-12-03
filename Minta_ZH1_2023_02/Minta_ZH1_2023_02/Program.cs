/* 2. Feladat. 
A MixAPizza étteremben nincsenek előre elnevezett pizzák, hanem mindenki
maga pakolja össze amit éppen szeretne. Az alap 32 cm pizza ára 1350 Ft. Ez az ár
tartalmazza a paradicsomszószt és a sajtot. Minden mást (ha szeretne) a vásárlónak kell rá kérnie.
A feltétek 3 kategóriába sorolhatók, melyek alapárai a következők.

    Kategória       Alapár         Feltétek
-----------------------------------------------------------
1. kategória        200 Ft      sonka, kukorica, gomba
2. kategória        250 Ft      kolbász, ananász, jalapenho
3. kategória        300 Ft      kagyló, articsóka, oliva
-----------------------------------------------------------

Extra: Annak érdekében, hogy a program könnyen bővíthető legyen, az egyes kategóriákba
sorolt feltéteket mentse el 3 darab szöveg alapú tömbbe, és azokkal oldja meg a
feladatot!
Készítsen programot, mely kiszámítja a pizza árát az alábbiak szerint!
a) Írja ki a képernyőre, hogy "Üdvözli Önt a MixAPizza pizzéria!"
b) Egy ciklus segítségével folyamatosan kérje be a felhasználótól, hogy milyen feltéteket
szeretne a pizzára! (Egy feltét többször is megadható. Feltételezheti, hogy a
felhasználó helyesen írja be a feltéteket!) A műveletet két esetben kell befejezni.
– A felhasználó megadott 5 feltétet. (Ennél több nem fér a pizzára)
– A felhasználó a "-" szöveggel jelzi, hogy nem kíván több feltétet megadni.
c) Minden megadott feltét esetén a kategóriának megfelelő árat adja hozzá a pizza alap
árához!
d) Írja ki a képernyőre, hogy a pizzára hány feltét került, illetve, hogy mennyit kell
fizetnie a felhasználónak! */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minta_ZH1_2023_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const ushort alapAr = 1350;
            const ushort feltetekMaxSzama = 5;
            string[] feltetek = { "1. kategória        200 Ft      sonka, kukorica, gomba",
                                  "2. kategória        250 Ft      kolbász, ananász, jalapenho",
                                  "3. kategória        300 Ft      kagyló, articsóka, oliva" };
            ushort[] feltetekAr = { 200, 250, 300 };
            Console.WriteLine("Üdvözli Önt a MixAPizza pizzéria!");
            ushort bekertFeltetekSzama = 0;
            ushort feltetekOsszege = 0;
            bool vege = false;
            do
            {
                string bekertErtek;
                ushort kivalasztotElem;
                Console.WriteLine("Eddig megadott feltetek szama: {0}, eddig a rendeles erteke: {1}\n", bekertFeltetekSzama, feltetekOsszege + alapAr);
                feltetekKiirasa(feltetek);
                do
                {
                    bekertErtek = Console.ReadLine();
                    if (bekertErtek == "-")
                    {
                        vege = true;
                        break;
                    }
                    if (ushort.TryParse(bekertErtek, out kivalasztotElem) && kivalasztotElem > 0 && kivalasztotElem <= feltetek.Length) {
                        bekertFeltetekSzama++;
                        feltetekOsszege += feltetekAr[kivalasztotElem - 1];
                        break;
                    }
                    Console.Write("Rosszul megadott adat!, add meg ujra: ");

                } while (true);
            } while (!vege && bekertFeltetekSzama < feltetekMaxSzama);
            Console.WriteLine("A rendelesed a kovetkezo: Alapar {0} Ft, feltetek szama {1} db, feltetek erteke {2} Ft, vegosszeg: {3} Ft",
                alapAr, bekertFeltetekSzama, feltetekOsszege, feltetekOsszege + alapAr);
        }
        static void feltetekKiirasa(string[] feltetek)
        {
            foreach (string item in feltetek)
            {
                Console.WriteLine(item);
                
            }
            Console.Write("Valassz (1...{0}) (- kilep): ", feltetek.Length);
        }
    }
}
