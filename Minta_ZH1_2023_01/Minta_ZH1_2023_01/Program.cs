/*

1. Feladat. 
A benzinkúton a benzin ára attól függ, hogy Ön egy céges autót tankol, vagy
egy a saját tulajdonában levőt. Attól függően, hogy mit tankolunk, a pontgyűjtő kártyára
különböző mennyiségű pontot írnak fel. Ettől függően a benzin ára és a gyűjthető pontok
az alábbiak szerint alakulnak.

Típus               Ár (magánszemély)   Ár (céges)  Pontok / 1l
---------------------------------------------------------------
Sima 95-ös          480 Ft              800 Ft      1 pont
Prémium 100-as      830 Ft              830 Ft      5 pont
---------------------------------------------------------------

Írjon alkalmazást, mely egy tankolás után a kasszánál lezajló folyamatot szimulálja az
alábbiak szerint!
a) Kérdezze meg a felhasználót, hogy milyen típusú a gépjármű! Feltételezheti, hogy
csak a cég és magán kifejezések egyikét írja be!
b) Ellenőrzötten kérje be a felhasználótól, hogy milyen típusú benzint tankolt! Csak a
95, illetve 100-as értékek elfogadhatók!
c) Ellenőrzötten kérje be a felhasználótól, hogy mennyit tankolt! Ez egy 1 és 50 közötti
valós érték!
d) Számítsa ki a fizetendő összeget és írja ki a képernyőre egész értékre kerekítve!
e) Kérdezze meg, hogy van-e a felhasználónak pontgyűjtőkártyája! Feltételezheti, hogy
csak az igen és nem kifejezések egyikét írja be!
– Ha nincs, akkor köszönjön el!
– Ha van, akkor számítsa ki és jelenítse meg a képernyőn, hogy hány hűségpontot
írnak fel, majd köszönjön el!


 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta_ZH1_2023_01
{
    internal class Program
    {
        struct Uzemanyag
        {
            public ushort tipus;
            public ushort ar_magan;
            public ushort ar_ceg;
            public ushort pont;

            public Uzemanyag(ushort tipus, ushort ar_magan, ushort ar_ceg, ushort pont)
            {
                this.tipus = tipus;
                this.ar_magan = ar_magan;
                this.ar_ceg = ar_ceg;
                this.pont = pont;

            }
        }

        static void Main(string[] args)
        {
            /* a) Kérdezze meg a felhasználót, hogy milyen típusú a gépjármű!Feltételezheti, hogy csak a cég és magán kifejezések egyikét írja be! */
            Console.Write("Gepjarmu tipusa: (1- ceges; 2- magan) ");
            ushort gepjarmuTipus;
            do
            {
                Console.Write("(1- ceges; 2- magan) ezek kozul ird be az egyiket: ");
            }
            while (!ushort.TryParse(Console.ReadLine(), out gepjarmuTipus) || !(gepjarmuTipus == 1 || gepjarmuTipus == 2));


            /* b) Ellenőrzötten kérje be a felhasználótól, hogy milyen típusú benzint tankolt! Csak a 95, illetve 100-as értékek elfogadhatók! */
            Console.Write("A tankolt uzemanyag tipusa (95, 100): ");
            ushort uzemanyagTipus;
            do
            {
                Console.Write("(95, 100):  ezek kozul ird be az egyiket: ");
            }
            while (!ushort.TryParse(Console.ReadLine(), out uzemanyagTipus) || !(uzemanyagTipus == 95 || uzemanyagTipus == 100));

            /* c) Ellenőrzötten kérje be a felhasználótól, hogy mennyit tankolt! Ez egy 1 és 50 közötti valós érték! */
            Console.Write("A tankolt mennyiseg (l) (1 - 50): ");
            double tankoltMennyiseg;
            do
            {
                Console.Write("Rossz megadott adat, (1.00 - 50.00) irj be egy valos erteket: ");
            }
            while (!double.TryParse(Console.ReadLine(), out tankoltMennyiseg) || !(tankoltMennyiseg >= 1 && tankoltMennyiseg <= 50));

            /* d) Számítsa ki a fizetendő összeget és írja ki a képernyőre egész értékre kerekítve! */
            Uzemanyag[] uzemanyag = { new Uzemanyag(95,480, 800, 1), new Uzemanyag(100, 830, 830, 5) };
            ushort fizetendoOsszeg;
            Uzemanyag kivalasztottUzemanyag = uzemanyagTipus == 95 ? uzemanyag[0] : uzemanyag[1];
            fizetendoOsszeg = (ushort)Math.Round((gepjarmuTipus == 1 ? kivalasztottUzemanyag.ar_ceg : kivalasztottUzemanyag.ar_magan) * tankoltMennyiseg);
            Console.WriteLine("A fizetendo osszeg: {0} Ft", fizetendoOsszeg);


            /* e) Kérdezze meg, hogy van-e a felhasználónak pontgyűjtőkártyája! Feltételezheti, hogy csak az igen és nem kifejezések egyikét írja be!
                – Ha nincs, akkor köszönjön el!
                – Ha van, akkor számítsa ki és jelenítse meg a képernyőn, hogy hány hűségpontot írnak fel, majd köszönjön el! */
            string pontgyujtoKartya;
            bool firstWrite = true;
            do
            {
                Console.Write((firstWrite ? "": "Megkerdem ujra... ") + "van pontgyujto kartyaja? (igen / nem): ");
                pontgyujtoKartya = Console.ReadLine();
                firstWrite = false;
            }
            while (!(pontgyujtoKartya == "igen" || pontgyujtoKartya == "nem"));

            if (pontgyujtoKartya == "nem")
            {
                Console.WriteLine("ByeBye!");
            } else
            {
                Console.WriteLine("A kiszamitott husegpontok szama: {0}, ByeBye!", Math.Round(tankoltMennyiseg * kivalasztottUzemanyag.pont));
            }
            
            Console.ReadLine();
        }
    }
}
