/* 3. Feladat. A karácsony előtti időszakban a LivingPine fenyőfákkal kereskedő cég 14
napon keresztül termeli ki a fákat (természetesen földlabdával, kaspóban), majd ezeket
értékesíti. Minden fa magassága 1,5 és 3 méter közé esik. Az Ön feladata a fenyőfák adatait
(méretét) tároló és azt elemző program elkészítse el az alábbiak szerint!
a) Kérjen be ellenőrzötten a felhasználótól egy 35 és 55 közötti számot, mely azt mondja
meg hogy mennyi fát tudnak kitermelni egy nap alatt!
b) Hozzon létre egy akkora egész értékű tömböt, melyben elfér a 14 nap alatt kitermelt
összes fa magassága!
c) Töltse fel a tömböt véletlen egész értékekkel a [150, 300] intervallumból! Tekintse
ezeket a számokat úgy, mint az egyes fenyőfák sorfolytonosan tárolt méreteit cm-ben
mérve! Például, ha egy nap 50 fenyőt termelnek ki, akkor az első 2 nap adatai:
----------------------------------------+--------------------------------
nap        |             1              |                2
----------------------------------------+--------------------------------
sorszam     1   2   3   ... 48  49  50  |   1   2   3   ... 48  49  50
index       0   1   2   ... 47  48  49  |   0   1   2   ... 47  48  49
Meret (cm)  257 149 298 ... 151 167 254 |   265 179 170 ... 223 231 290
-------------------------------------------------------------------------

d) Határozza meg minden napon az átlagmagasságot és írja ki méterben!
e) Határozza meg és írja ki a képernyőre, hogy melyik napon termelték ki a legkisebb
fát, és mekkora volt a magassága! (Ha többször is előfordul ez az érték a mintában,
elég csak egyszer kiírni.)
f) A fenyők ára 5000 Ft/m, és az eladáskor a fákat minden megkezdett 10 cm után
kell kifizetni. Például, ha egy fa 186 cm, akkor az ára 18 · 500 = 9000 Ft.
– Számítsa ki és jelenítse meg a képernyőn, hogy ha minden fát eladnánk, akkor
naponta mennyi bevételre számíthatunk!
– Jelenítse meg melyik napon volt a legnagyobb összértékű kitermelés! */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta_ZH1_2023__03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const ushort kitermelesiNapokSzama = 14;
            const ushort fenyokAra = 5000;
            ushort napiFakitermelesekSzama;
            do
            {
                Console.Write("Add meg a napi fakitermelesek szamat (35 - 50): ");
            } while (!ushort.TryParse(Console.ReadLine(), out napiFakitermelesekSzama) || napiFakitermelesekSzama < 35 || napiFakitermelesekSzama > 50);

            ushort[] kitermelesek = new ushort[kitermelesiNapokSzama * napiFakitermelesekSzama];
            Random rnd = new Random();
            for (int i = 0; i < kitermelesek.Length; i++)
            {
                kitermelesek[i] = (ushort)rnd.Next(150, 301);
            }

            double napiAtlag;
            for (int i = 0; i < kitermelesiNapokSzama; i++)
            {
                napiAtlag = 0;
                for (int j = 0; j < napiFakitermelesekSzama; j++)
                {
                    napiAtlag += kitermelesek[i * kitermelesiNapokSzama + j];
                }
                Console.WriteLine("A(z) {0} nap atlaga a: {1} m", i + 1, Math.Round(napiAtlag / napiFakitermelesekSzama / 100, 2));
            }

            ushort minKitermeles = ushort.MaxValue;
            ushort minKitermSorsz = 0;
            for (int i = 0; i < kitermelesiNapokSzama; i++)
            {
                for (int j = 0; j < napiFakitermelesekSzama; j++)
                {
                    if (kitermelesek[i * kitermelesiNapokSzama + j] < minKitermeles)
                    {
                        minKitermeles = kitermelesek[i * kitermelesiNapokSzama + j];
                        minKitermSorsz = (ushort)(i + 1);
                    }
                }
            }
            Console.WriteLine("\nA(z) {0} napon termeltek ki a legkisseb fat, magassaga {1} cm\n", minKitermSorsz, minKitermeles);

            int napiBevetel;
            int maxBevetel = 0;
            ushort maxBevetelSorszama = 0;
            for (int i = 0; i < kitermelesiNapokSzama; i++)
            {
                napiBevetel = 0;
                for (int j = 0; j < napiFakitermelesekSzama; j++)
                {
                    napiBevetel += (int)(kitermelesek[i * kitermelesiNapokSzama + j]/10) * fenyokAra/10;
                }
                if (maxBevetel < napiBevetel)
                {
                    maxBevetel = napiBevetel;
                    maxBevetelSorszama = (ushort)(i + 1);
                }
                Console.WriteLine("A(z) {0} nap bevetele: {1} Ft", i + 1, napiBevetel);
            }
            Console.WriteLine("\nA maximum bevetel a {0} nap volt: {1} Ft", maxBevetelSorszama, maxBevetel);
            Console.ReadLine();
        }
    }
}
