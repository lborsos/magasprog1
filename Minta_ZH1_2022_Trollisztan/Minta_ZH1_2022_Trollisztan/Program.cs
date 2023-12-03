/*
1.Feladat.Ön Trollisztán állampolgárai számára készít szoftvert, ahol a nemzeti fizetőeszköz
a guba. A program feladata kiszámítani, hogy adott bruttó kereset esetén mennyi
nettó jövedelemre számíthat a munkavállaló! A program működését az alábbiak szerint
implementálja!
a) A minimálbér összege 2100 guba. Kérje be a felhasználó által keresett bruttó bért!
Amennyiben a minimálbérnél kevesebbet írt be, úgy adjon hibaüzenetet, és zárja be
a programot!
A bruttó bérből levont adószázalékot az alábbiak alapján tudja kiszámítani.
b) Attól függően, hogy az illetőnek mennyi a bruttó bére, az alap adószázalék az alábbiak
szerint alakul:
[2100; 4200) guba bruttó bér esetén: 10%
[4200; 8000) guba bruttó bér esetén: 20%
[8000; 15000) guba bruttó bér esetén: 30%
[15000;∞) guba bruttó bér esetén: 40%
c) Kérje be a felhasználótól az eltartott gyermekeinek a számát! Negatív-, illetve 69-
nél nagyobb szám esetén adjon hibaüzenetet, és állítsa le a program futását! Utóbbi
esetben ne jelenjen meg semmilyen nettó fizetés!
d) Attól függően, hogy a munkavállaló hány gyermeket nevel, a bruttó bér alapján
megállapított adószázaléknak csak bizonyos százalékát fogják levonni az alábbiak
szerint:
1 gyermek esetén: 90%
2 gyermek esetén: 80%
3 gyermek esetén: 70%
4 vagy több gyermek esetén: 60%
e) Számítsa ki a nettó bért a fentiek alapján és írja ki a képernyőre 10 gubásra kerekítve!
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minta_ZH1_2022_Trollisztan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const ushort minimalBer = 2100;
            ushort bruttoBer;
            Console.Write("Add meg a bruttó bér: ");
            while(!ushort.TryParse(Console.ReadLine(), out bruttoBer))
            {
                Console.WriteLine("Hibás adat! add meg újra!");
            }
            if (bruttoBer < minimalBer)
            {
                Console.WriteLine("A minimalbér {0} Ft, amit megadtál bruttó bért az {1} Ft, tehát kisseb mint a minimálbér! ByeBye!", minimalBer, bruttoBer);
                Environment.Exit(0);
            }

            ushort gyerekekSzama;
            Console.Write("Add meg a gyerekek számát: ");
            while (!ushort.TryParse(Console.ReadLine(), out gyerekekSzama))
            {
                Console.WriteLine("Hibás adat! add meg újra!");
            }
            if (gyerekekSzama < 0 && gyerekekSzama > 69)
            {
                Console.WriteLine("A gyerekek száma nem lehet kissebb mint 0 illefve vagyobb mint 69! ByeBye!");
                Environment.Exit(0);
            }
            double ado_1st = bruttoBer  *  adoSzazalekKivalaszto(bruttoBer) / 100;
            double ado_2st = ado_1st * adoSzazalekSzazalekKivalaszto(gyerekekSzama) / 100;
            double nettoBer = Math.Round((bruttoBer - ado_2st) / 10) * 10;

            Console.WriteLine("Bruttó bér: {0} Guba, Adó: {1}%, Gyerekek száma: {2}, Gyerekek utani adózási százalék: {3}%, Nettó bér: {4} Guba", 
                bruttoBer, adoSzazalekKivalaszto(bruttoBer), gyerekekSzama, adoSzazalekSzazalekKivalaszto(gyerekekSzama), nettoBer);


        }
        static ushort adoSzazalekKivalaszto(ushort bruttoBer)
        {
            if (bruttoBer < 4200)
            {
                return 10;
            }
            else if (bruttoBer < 8000)
            {
                return 20;
            }
            else if (bruttoBer < 15000)
            {
                return 30;
            }
            return 40;
        }
        static ushort adoSzazalekSzazalekKivalaszto(ushort gyerekekSzama)
        {
            switch (gyerekekSzama)
            {
                case 0:
                    return 100;
                case 1:
                    return 90;
                case 2:
                    return 80;
                case 3:
                    return 70;
                default:
                    return 60;
                // break azért nem kell mert a return al kilép a metodusból!
            }
        }
    }
}
