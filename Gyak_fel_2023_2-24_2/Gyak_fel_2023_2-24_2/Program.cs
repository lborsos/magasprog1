/*
2. Feladat. 

Készítsen konzolos alkalmazást, mely egy asztali számítógép összeállítását
szimulálja! A RAM-ok beszerelésének folyamatát implementálja az alábbiak szerint!

a) Kérje be a felhasználótól, hogy hány RAM slot van az alaplapon! Ellenőrizze, hogy legalább 2, legfeljebb 6 legyen!

b) Kérje be a felhasználótól, hogy az egyes slot-okba mekkora RAM-okat illeszt be!

c) Csak 2, 4, 6, illetve 8 GB-os RAM-okat fogadjon el!

d) Figyeljen, hogy a RAM-ok összege ne lépje túl a 32 GB-os felső határt!

e) Írja ki, hogy végül hány slot-ba, összesen hány GB RAM került! */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak_fel_2023_2_24_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ramSlot;
            int ramMeret;
            List<int> ramCapacity = new List<int> { 0, 2, 4, 6, 8 };
            do
            {
                Console.Write("Hany RAM Slot van az alaplapon: ");
            } while (!int.TryParse(Console.ReadLine(), out ramSlot) || ramSlot < 2 || ramSlot > 6);
            
            int[] ramASlottokba = new int[ramSlot];
            int currentSlot = 0;
            do {
                do
                {
                    Console.Write("A {0} slotba tevodo memoria merete (0, 2, 4, 6, 8) Gb: ", currentSlot + 1);
                } while (!int.TryParse(Console.ReadLine(), out ramASlottokba[currentSlot]) || !ramCapacity.Contains(ramASlottokba[currentSlot]) || checkRam(ramASlottokba) > 32);
                currentSlot++;
            } while (currentSlot < ramSlot && checkRam(ramASlottokba) != 32);
            Console.WriteLine("{0} slotba {1} Gb RAM kerult!", ramSlot, checkRam(ramASlottokba));
        }

        static int checkRam(int[] rams)
        {
            int totRam = 0;
            for (int i = 0; i < rams.Length; i++)
            {
                totRam += rams[i];
            }
            return totRam;
        }
    }
}
