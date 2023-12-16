/*
A zárthelyi dolgozat témája egy laptopokat forgalmazó számítástechnikai bolt raktárkészletének
kezelése.
A mellékelt MP1_2022_23_ZH2_A_input.csv input fájl minden sorában egyegy
laptop adatait találja pontosvesszővel elválasztva egymástól az alábbi struktúrában.
-----------------------------------------------------------------------------
Gyártó                  szöveg
-----------------------------------------------------------------------------
Processzor              szöveg
Beszerzés dátuma        dátum yyyy.MM.dd formátumban, ekkortól megvásárolható
GPU                     szöveg
RAM                     egész szám
Tárhely                 egész szám
Tárhely típusa          szöveg
Kiállítási darab        szöveg (igen vagy nem)
Ár                      egész szám
-----------------------------------------------------------------------------

1. Feladat. 

Az input fájl beolvasását az alábbiak szerint végezze el!

a) Készítsen osztályt, mely a fájlban található laptopok tárolására alkalmas!
b) Azt, hogy a laptop kiállítási darab-e logikai típusú változóban tárolja!
c) Készítsen listát, mely az osztály a példányainak tárolására alkalmas!
d) Olvassa be az MP1_2022_23_ZH2_A_input.csv fájl-t, és a soronként elkészített
   példányokat mentse el az ere a célra létrehozott listába!

2. Feladat. 

Az áruházban a Black Friday december 25-től december 27-ig tartott Írja ki
a képernyőre az ez idő alatt a polcokra kitett laptopok adatait a minta szerint, valamint
azt, hogy ezen termékeknek mennyi az átlagos ára!

    2. feladat
    A Black Friday alatt kitett laptopok:
    Asus - Intel i3, 8 GB, 1024 MB HDD, NVIDIA GeForce RTX 3050Ti
    MSI - Intel i7, 16 GB, 256 MB SSD, AMD Radeon
    ...
    A fenti laptopok átlagos ára 325500 Ft.


3. Feladat. 

Némely laptop most kedvezményes áron vásárolható meg az alábbi feltételek
alapján. Minden feltétel független egymástól!
– Amennyiben a termék jó ideje nem kelt el (2022.10.01 előtt lett kitéve), úgy csökkentsük az árát 25%-kal!
– Ha a laptop HDD-vel, vagy SSHD-vel van felszerelve, akkor az ára csökken 12000 Ft-tal!
– Amennyiben a laptop kiállítási darab, úgy csökkentse az árát 15%-kal!
– Amennyiben semmilyen kedvezmény nem jár, úgy a függvény térjen vissza az eredeti árral!

Készítsen egész értékkel visszatérő függvényt, melynek neve az "F3_" prefixummal kezdődik!
a) A függvénynek egyetlen paramétere van, egy adott laptop.
b) Számítsa ki a termék kedvezményes árát és annak egészre kerekített értékével térjen vissza!

4. Feladat. 

Készítsen logikai függvényt, melynek neve az "F4_" prefixummal kezdődik!
A függvény eldönti, hogy van-e a paraméterben kapott laptopok között olyan, mely adott
márkával és adott processzorral rendelkezik! Az függvény paraméterei:
– Az összes laptopot tartalmazó lista: ezt vizsgáljuk
– Gyártó neve
– Processzor típusa

5. Feladat. 

Segítse a vásárlót laptop vásárlási szándékában az alábbiak szerint!

a) Kérje be a felhasználótól a preferált gyártót!
b) Kérje be a felhasználótól a preferált processzort!
c) A 4. feladatban elkészített függvény segítségével döntse el, hogy van-e általa keresett laptop a listában! Ha nincs, értesítse erről a felhasználót!
d) Amennyiben vannak ilyen laptopok a listában, úgy írja ki a képernyőre azok RAMját,
GPU-ját, valamint eredeti és kedvezményes árukat a minta szerint! A kedvezményes
ár kiszámításához használja a 3. feladatban megírt függvényt!

    5. feladat
    Gyártó: Lenovo
    Processzor: Intel i5
    8 GB, NVIDIA GeForce RTX 3050Ti, Ár: 375000 Ft, Kedv. ár: 335000 Ft
    16 GB, AMD Radeon, Ár: 355999 Ft, Kedv. ár: 312999 Ft
    ...


6. Feladat. 

A 4GB RAM-mal rendelkező laptopok nem igazán fogynak! Járja be a laptopok
listáját, és minden 4GB-tal rendelkező laptop RAM-ját módosítsa 8GB-ra, az árat
pedig emelje meg 3000 Ft-tal!

7. Feladat. 

Írjon szöveges listával visszatérő függvényt, listába gyűjti alaptopok gyártóit!
A függvény neve az "F7_" prefixummal kezdődjön!
a) A függvénynek egyetlen paramétere van, az összes laptopot tartalmazó lista.
b) A gyártók kigyűjtésekor mindegyiket csak egyszer helyezze el a listában!

8. Feladat. 

A 7. feladatban megírt függvény felhasználásával gyűjtse ki a laptopok gyártóit
egy Ön által létrehozott listába!
Gyártónként írja ki a képernyőre a legmagasabb kedvezményes árral rendelkező laptop
adatait a minta szerint! Csak a nem kiállítási darabokat vegye figyelembe! (Biztos lehet
benne, hogy minden gyártónak van legalább egy nem kiállítási darab laptopja!)

8. feladat
Asus: 32 GB, NVIDIA GeForce RTX 3050Ti, Kedv ár: 685000 Ft
LEnovo: 64 GB, AMD Radeon, Kedv ár: 586000 Ft
... */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_MP1_2022_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime blackFridayBegin = new DateTime(2022, 12, 25);
            DateTime blackFridayEnd = new DateTime(2022, 12, 27);
            List<Laptop> laptopok = new List<Laptop>();
            beolvas(laptopok);

            // Asus - Intel i3, 8 GB, 1024 MB HDD, NVIDIA GeForce RTX 3050Ti
            // MSI - Intel i7, 16 GB, 256 MB SSD, AMD Radeon
            int db = 0;
            int osszArBF = 0;
            foreach (Laptop laptop in laptopok)
                if (laptop.beszDatum >= blackFridayBegin && laptop.beszDatum <= blackFridayEnd) { 
                    Console.WriteLine("{0} - {1}, {2} GB, {3} MB {5}, {4}", laptop.gyarto, laptop.cpu, laptop.ram, laptop.tarhely, laptop.gpu, laptop.tarhelyTipusa);
                    db++;
                    osszArBF += laptop.ar;
                }
            Console.WriteLine("A fenti laptopok adtlagos ara: {0}\n", osszArBF / db);

            Console.Write("Gyarto: ");
            string gyarto = Console.ReadLine();
            Console.Write("Processzor: ");
            string cpu = Console.ReadLine();


            // 5.
            //  8 GB, NVIDIA GeForce RTX 3050Ti, Ár: 375000 Ft, Kedv. ár: 335000 Ft
            if (F4_vanE(laptopok, gyarto, cpu)) 
            { 
                foreach (Laptop laptop in laptopok) if (laptop.gyarto.ToUpper() == gyarto.ToUpper() && laptop.cpu.ToUpper() == cpu.ToUpper())
                        Console.WriteLine("{0} GB, {1}, Ar: {2} Ft, Kedv. ar: {3} Ft", laptop.ram, laptop.gpu, laptop.ar, F3_kedvAr(laptop));
            }
            else Console.WriteLine("Nincs talalat!");

            // 6.
            for (int i = 0; i < laptopok.Count; i++)
            {
                if (laptopok[i].ram == 4)
                {
                    laptopok[i].ram = 8;
                    laptopok[i].ar += 3000;
                }
            }


            // 8
            /*
                Gyártónként írja ki a képernyőre a legmagasabb kedvezményes árral rendelkező laptop
                adatait a minta szerint! Csak a nem kiállítási darabokat vegye figyelembe! (Biztos lehet
                benne, hogy minden gyártónak van legalább egy nem kiállítási darab laptopja!)

                8. feladat
                Asus: 32 GB, NVIDIA GeForce RTX 3050Ti, Kedv ár: 685000 Ft
                LEnovo: 64 GB, AMD Radeon, Kedv ár: 586000 Ft             */

            Console.WriteLine();
            List<string> gyartok = new List<string>();
            gyartok = F7_gyartok(laptopok);

            foreach (string itemGyarto in gyartok)
            {
                Laptop maxKedvLapi = new Laptop();
                foreach (Laptop laptop in laptopok)
                {
                    if (laptop.gyarto == itemGyarto && !laptop.kialitas)
                    {
                        if (F3_kedvAr(laptop) > F3_kedvAr(maxKedvLapi))
                        {
                            maxKedvLapi = laptop;
                        }
                    }
                }
                Console.Write("{0}: ", itemGyarto);
                Console.WriteLine("{0} GB, {1}, kedv. ar: {2} Ft", maxKedvLapi.ram, maxKedvLapi.gpu, F3_kedvAr(maxKedvLapi));

            }

            Console.ReadLine();
        }


        private static List<string> F7_gyartok(List<Laptop> laptopok)
        {
            List<string> gyLista = new List<string>();
            foreach (Laptop laptop in laptopok)
            {
                if (!gyLista.Contains(laptop.gyarto))
                {
                    gyLista.Add(laptop.gyarto);
                }
            }
            return gyLista;
        }
        private static bool F4_vanE(List<Laptop> laptopok, string gyarto, string cpu)
        {
            bool van = false;
            foreach (Laptop laptop in laptopok) if (laptop.gyarto.ToUpper() == gyarto.ToUpper() && laptop.cpu.ToUpper() == cpu.ToUpper()) van = true;
            return van;
        }

            /*
            – Amennyiben a termék jó ideje nem kelt el(2022.10.01 előtt lett kitéve), úgy csökkentsük az árát 25%-kal!
            – Ha a laptop HDD-vel, vagy SSHD-vel van felszerelve, akkor az ára csökken 12000 Ft-tal!
            – Amennyiben a laptop kiállítási darab, úgy csökkentse az árát 15%-kal!
            – Amennyiben semmilyen kedvezmény nem jár, úgy a függvény térjen vissza az eredeti árral!   */
        private static int F3_kedvAr(Laptop laptop)
        {
            // elméletileg fennálhat az is, hogy mind három feltétel teljesül! ilyenkor nem mindegy a sorrend, hogyan szamoljuk a kedvezményt!
            // azt a sorrendet ahogy a feladat leirásába van aszerint fogom szamolni a kedvezményt!
            double vret = laptop.ar;
            if (laptop.beszDatum < DateTime.Parse("2022.10.01")) vret -= vret * 0.25d;
            if (laptop.tarhelyTipusa == "HDD".ToUpper() || laptop.tarhelyTipusa == "SSHD".ToUpper()) vret -= 12000;
            if (laptop.kialitas) vret -= vret * 0.15d;
            return (int)Math.Round(vret);
        }
        private static void beolvas(List<Laptop> laptopok)
        {
            // Azert tettem ide a csv filet mert a bin/Debug mappaba levo fileokat a git nem verzioköveti (.gitignore file igy van megirva)
            StreamReader sr = new StreamReader("../../MP1_2022_23_ZH2_A_input.csv", Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                Laptop ujLaptop = new Laptop();

                ujLaptop.gyarto = adatok[0];
                ujLaptop.cpu = adatok[1];
                ujLaptop.beszDatum = DateTime.Parse(adatok[2]);
                ujLaptop.gpu = adatok[3];
                ujLaptop.ram = int.Parse(adatok[4]);
                ujLaptop.tarhely = int.Parse(adatok[5]);
                ujLaptop.tarhelyTipusa = adatok[6];
                ujLaptop.kialitas = adatok[7] == "igen" ? true : false;
                ujLaptop.ar = int.Parse(adatok[8]);

                laptopok.Add(ujLaptop);
            }
            sr.Close();
        }
    }
}
