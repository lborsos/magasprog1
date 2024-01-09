/*
A kedvenc online menzánk minden héten közzé teszi az elkövetkezendő heti ételeket,
amelyeket az ügyfelei rendelhetnek. Az Ön feladata beolvasni és eltárolni a jövő heti
ételek adatait, majd az egyes feladatokban megfogalmazott lekérdezéseket és feladatokat
implementálni.
A mellékelt MP1_2023_24_ZH2_input.csv input fájl minden sorában egy-egy
étel adatait találja pontosvesszővel elválasztva egymástól az alábbi struktúrában.
--------------------------------------------------------------------------------
Étel neve 					szöveg
Kategória 					szöveg (leves, saláta, rántott, . . . )
Adag 						normál vagy kicsi
Tömeg (g) 					egész szám
Melyik nap rendelhető 		dátum yyyy.MM.dd formátumban
Allergének 					szöveg (többet is tartalmazhat vesszővel elválasztva)
Energia (kcal/100 g) 		egész szám
Ár 							egész szám
--------------------------------------------------------------------------------

1. Feladat. Az input fájl beolvasását az alábbiak szerint végezze el!
a) Készítsen osztályt, mely a fájlban található ételek tárolására alkalmas!
b) Azt, hogy az étel normál adag-e logikai típusú változóban tárolja!
c) Készítsen listát, mely az osztály példányainak tárolására alkalmas!
d) Olvassa be az MP1_2023_24_ZH2_input.csv fájl-t, és a soronként elkészített
példányokat mentse el az erre a célra létrehozott listába!

2. Feladat. Az egyes ételek esetén az energiatartalom 100gramm-ra vonatkozóan van
megadva. Készítsen egész értékkel visszatérő függvényt, melynek neve az "F2_" prefixummal
kezdődik, és amely kiszámítja a teljes adag energiaértékét! A függvény paramétere:
– Egy étel objektum.

3. Feladat. A hét elején rendesen odatettük magunkat és csak olyan ételeket vettünk,
amelyek alacsony kalóriatartalommal bírnak. Ezen felbuzdulva a hét vége felé (december
14.-től december 15.-ig) olyan ételeket tervezünk rendelni, melyek magas energiatartalommal
bírnak. Listázza ki a mintának megfelelően az ezen időszak alatt rendelhető olyan
ételeket, melyek teljes adagja 700kcal fölött van! Használja a 2. feladatban megírt függvényt
Számítsa ki azt is, hogy mennyi ezek átlagos ára!

3. feladat
Fullos ételek a hét végére:
Csokoládés karamelltorta (normál: 50 g) - 757 kcal, 1250 Ft
Pacalpörkölt galuskával (kicsi: 300 g) - 838 kcal, 1310 Ft
...
A fenti ételek átlagos ára 1150 Ft.

4. Feladat. Állapítsa meg, hogy melyik a drágább? A legolcsóbb kis adag rántott, vagy
a legolcsóbb normál adag főzelék? (Feltételezheti, hogy a rendelhető ételek között van
mindkettőből legalább egy!)
3. feladat
A legolcsóbb kis adag rántott a Rántott halrudi, az
ára pedig 1170 Ft.
A legolcsóbb normál adag főzelék a Tökfőzelék pörkölttel, az ára
pedig 1230 Ft.
A Tökfőzelék pörkölttel drágább.

5. Feladat. Az egyes ételek tartalmazhatnak különböző allergén anyagokat, amiket a
vásárlók bizonyos esetekben szeretnének kiszűrni. Annak eldöntésére, hogy az adott étel
tartalmaz-e bármilyen a felhasználó számára veszélyes allergént készítsen logikai függvényt,
melynek neve az "F5_" prefixummal kezdődik! A függvény az alábbi paraméterekkel
rendelkezik.
– Egy étel objektum.
– Szöveges lista (ez tartalmazza a kiszűrni kívánt allergéneket).

6. Feladat. Segítse a felhasználót abban, hogy kiszűrje a számára veszélyes ételeket!
a) Kérje be a felhasználótól azokat az allergéneket, melyekre érzékeny és tárolja el egy
szöveges listában őket! A bekérés végét a "-" karakterrel jelezze! Ha ezt a részfeladatot
nem tudja implementálni, akkor mentse el egy szöveges listába a "gomba"
és "mogyoró" kifejezéseket!
b) A 5. feladatban implementált függvény segítségével jelenítse meg az alábbi formában
azokat az ételeket, melyek egyik allergént sem tartalmazzák a megadottak közül!

4. feladat
Adja meg az Ön számára veszélyes allergéneket:
gomba
mogyoró
-
Az Ön számára javasolt ételek:
Cézársaláta - allergének: tojás,zeller
Lencsefőzelék - allergének: tej
...

7. Feladat. Írjon szöveges listával visszatérő függvényt, amely listába gyűjti az ételek
kategóriáit! A függvény neve az "F7_" prefixummal kezdődjön!
a) A függvénynek egyetlen paramétere van, egy ételeket tartalmazó lista.
b) A kategóriák kigyűjtésekor mindegyiket csak egyszer helyezze el a listában!
c) A kategóriákat rendezve adja vissza!

8. Feladat. A 7. feladatban megírt függvény felhasználásával gyűjtse ki az ételek kategóriáit
egy Ön által létrehozott listába!
Kategóriánként írja ki a képernyőre a legalacsonyabb teljes adagra vonatkozó energiatartalommal
rendelkező ételt! Csak azokat vegye figyelembe, amelyek nem tartalmaznak
gombát! (Feltételezheti, hogy minden kategóriában van ilyen!)

8. feladat
leves: Zöldborsó leves (300 gramm), 275 kcal - 890 Ft
desszert: Málnás ropogós (120 gramm), 283 kcal - 690 Ft
rántott: Rántott kelkáposzta, barna rizs (300 gramm), 568 kcal - 1250 Ft
...
Extra feladat. Tervezze meg a jövő heti menüt! Napi bontásban készítsen olyan listát,
mely tartalmaz
– levest,
– véletlenszerűen salátát, rántottat vagy főzeléket, és
– desszertet.
Minden esetben a legolcsóbbat válassza! Írja ki a napi összegeket, és a heti menü teljes
árát!

9. feladat
Hétfő (2390 Ft)
leves: Gyümölcsleves - 730 Ft
rántott: Rántott halrudi krumplipürével - 1170 Ft
desszert: Lekváros palacsinta - 490 Ft
Kedd (2290 Ft)
leves: Zöldborsóleves - 710
főzelék: Tökfőzelék fasírozottal - 950 Ft
desszert: Piskótakocka pudinggal - 630 Ft
...
A heti menü teljes ára 16370 Ft.


*/

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace f4mqfm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Etel> etelek = new List<Etel>();
            readCsvAndFillEtelek(etelek);

            // 3.
            Console.WriteLine("Fulos etelek a het vegere:");
            foreach (Etel etel in etelek)
            {
                if (etel.rendData >= new DateTime(2023,12,14) && etel.rendData <= new DateTime(2023,12,15) && F2_energiaertek(etel) > 700)
                {
                    Console.WriteLine("{0} ({1}) - {2} kcal, {3} Ft", etel.nev, etel.normal ? "normál" : "kicsi", etel.tomeg, F2_energiaertek(etel), etel.ar);
                }
            }

            //  4.
            Etel kis = new Etel();
            Etel normal = new Etel();
            foreach (Etel etel in etelek)
            {
                if (!etel.normal && etel.kategoria == "rántott")
                {
                    if (etel.ar > kis.ar)
                    {
                        kis = etel;
                    }
                }
                if (etel.normal && etel.kategoria == "főzelék")
                {
                    if (etel.ar > normal.ar)
                    {
                        normal = etel;
                    }
                }
            }
            Console.WriteLine("\n4 feldat");
            Console.WriteLine("A legolcsobb kis adag rántott a {0}, az ara pedig {1}", kis.nev, kis.ar);
            Console.WriteLine("A legolcsobb normál adag főzelék a {0}, az ara pedig {1}", normal.nev, normal.ar);
            Etel dragabb = new Etel();
            dragabb = kis.ar > normal.ar ? kis : normal;
            Console.WriteLine("A {0} a drágább.", dragabb.nev);

            Console.WriteLine("\n 6.");
            string allergen;
            List<string> allergenek = new List<string>();
            do
            {
                Console.Write("Allergen: ");
                allergen = Console.ReadLine();
                if (allergen == "-")
                {
                    break;
                }
                else
                {
                    allergenek.Add(allergen);
                }
            } while (true);


            Console.WriteLine("Az on szamara javasolt etelek:");
            foreach (Etel etel in etelek)
            {
                if (!F5_allergene(etel, allergenek))
                {
                    Console.Write("{0} - allergének: ", etel.nev);
                    foreach (string allerg in etel.allergenek)
                    {
                        Console.Write("{0}, ", allerg);
                    }
                    Console.WriteLine();
                }
            }


            // 8
            Console.WriteLine("\n 8 eladat\n");
            List<string> kategoriak = new List<string>();
            kategoriak = F7_kategoriak(etelek);
            foreach (string kateg in kategoriak)
            {
                Etel alacsonyEnergia = new Etel();
                foreach (Etel etel in etelek)
                {
                    if (F2_energiaertek(etel) > F2_energiaertek(alacsonyEnergia) && etel.kategoria.Contains(kateg) && !etel.kategoria.Contains("gomba"))
                    {
                        alacsonyEnergia = etel;
                    }
                }
                Console.WriteLine("{0}: {1} ({2} gramm), {3} kcal - {4} Ft", kateg, alacsonyEnergia.nev, alacsonyEnergia.tomeg, F2_energiaertek(alacsonyEnergia), alacsonyEnergia.ar);
            }

        }

        static List<string> F7_kategoriak(List<Etel> etelek)
        {
            List<string> kateg = new List<string>();

            foreach (Etel etel in etelek)
            {
                string[] kateggg = etel.kategoria.Split(',');
                foreach (string item in kateggg)
                {
                    if (!kateg.Contains(item))
                    {
                        kateg.Add(item);
                    }
                }
            }
            kateg.Sort();
            return kateg;
        }

        static bool F5_allergene(Etel etel, List<string> allergenek)
        {
            bool van = false;
            foreach (string allergen in allergenek)
            {
                if (etel.allergenek.Contains(allergen))
                {
                    van = true;
                    break;
                }
            }
            return van;
        }
        static int F2_energiaertek(Etel etel)
        {
            return (int)((etel.tomeg * etel.energia) / 100);
        }
        static void readCsvAndFillEtelek(List<Etel> etelek)
        {
            StreamReader sr = new StreamReader("../../MP1_2023_24_ZH2_input.csv", Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                Etel ujEtel = new Etel();
                ujEtel.nev = adatok[0];
                ujEtel.kategoria = adatok[1];
                ujEtel.normal = adatok[2] == "normál" ? true : false;
                ujEtel.tomeg = int.Parse(adatok[3]);
                ujEtel.rendData = DateTime.Parse(adatok[4]);
                ujEtel.allergenek = adatok[5].Split(',');
                ujEtel.energia = int.Parse(adatok[6]);
                ujEtel.ar = int.Parse(adatok[7]);

                etelek.Add(ujEtel);
            }
            sr.Close();
        }

    }

}
