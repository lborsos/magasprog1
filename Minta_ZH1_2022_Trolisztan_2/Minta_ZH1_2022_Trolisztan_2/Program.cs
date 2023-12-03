/*
2. Feladat. Mint említettük, Trollisztán fizetőeszköze a guba. A használatban lévő valuták:
10 guba,
20 guba,
50 guba,
100 guba,
200 guba.
Az Ön feladata, hogy egy adott összeg kifizetését szimulálja az alábbiak szerint!
a) Kérjen be a felhasználótól egy 10-zel osztható, 2000-nél kisebb, vagy egyenlő pozitív
egész számot ellenőrzötten! Tekintse ezt a kifizetendő összegnek!
b) Kérjen be a felhasználótól ellenőrzötten érvényes trollisztáni valutákat addig, amíg
azokkal ki nem tudja fizetni a korábban bekért összeget!
c) Minden elfogadott valuta után írja ki, hogy mekkora összeget kell még kifizetni!
d) Figyeljen rá, hogy ne történhessen túlfizetés!
e) A program, miután befejezte működését, értesítse a felhasználót, hogy az adott
pénzösszeg kifizetésre került.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta_ZH1_2022_Trolisztan_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ushort[] gubaCimletek = {10, 20, 50, 100, 200 };
            ushort osszeg;
            Console.Write("Add meg az összeget (10 el ösztható és 2000 nél kissebb vagy egyenlő) :");
            while (true) { 
                if (!ushort.TryParse(Console.ReadLine(), out osszeg)) {
                    Console.Write("Hibás bevitel! add meg újra: ");
                    continue; 
                }
                if (osszeg % 10 != 0 || osszeg > 2000) {
                    Console.Write("Az összeg 10 el osztható kell legyen és 2000 nél kisseb vagy egyenlő! add meg újra: ");
                    continue;
                }
                break;
            }
            Console.Write("Az összeg {0} guba, ezt kell befizetned guba cimletekbe! nyomj egy gombot és kezdjük!", osszeg);
            Console.ReadLine();
            ushort befizetesek = 0;
            while (true) {
                if (befizetesek == osszeg) break;
                Console.WriteLine("\nAz eddigi befizetéswd {0} guba a {1} guba összegből, maradt még {2} guba befizetnibalod!", befizetesek, osszeg, osszeg - befizetesek);
                Console.Write("Add meg a guba cimletet ({0}): ", gubaCimletekToString(gubaCimletek));
                ushort bekertGuba;
                while (true)
                {
                    if (!ushort.TryParse(Console.ReadLine(), out bekertGuba))
                    {
                        Console.Write("Hibás bevitel! add meg újra: ");
                        continue;
                    }
                    if (!cimletEllenorzo(bekertGuba, gubaCimletek))
                    {
                        Console.Write("Nem megfelelő guba cimletet adtál meg! a megfeleő cimletek: ({0}), add meg újra: ", gubaCimletekToString(gubaCimletek));
                        continue;
                    }
                    if (befizetesek + bekertGuba > osszeg)
                    {
                        Console.Write("A fennmaradó összeg amit be kell fizetned: {0} guba, te pedig {1} guba -t akartál befizetni! add meg ujra: ", osszeg - befizetesek, bekertGuba);
                        continue;
                    }
                    befizetesek += bekertGuba;
                    break;
                }
                Console.Write("Sikeres befizetes! ByeBye :)");
            }
            Console.ReadLine();
        }
        static string gubaCimletekToString(ushort[] gubaCimletek)
        {
            string cimletekString = "";
            foreach (ushort cimlet in gubaCimletek)
            {
                cimletekString += cimlet.ToString() + ", ";
            }
            return cimletekString.Substring(0, cimletekString.Length -2);
        }

        static bool cimletEllenorzo(ushort beekertCimlet, ushort[] gubaCimletek)
        {
            foreach (ushort cimlet in gubaCimletek)
            {
                if (cimlet == beekertCimlet) return true;
            }
            return false;
        }
    }
}
