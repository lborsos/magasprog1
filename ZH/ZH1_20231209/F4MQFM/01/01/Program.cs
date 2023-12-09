/*
1. Feladat. 

A nyári időszakban Eger egyik leglátogatottabb helyszíne az Egri Termálfürdő,
vagy ahogyan mindenki ismeri, az Egri strand. Az Ön feladata egy olyan alkalmazás
implementálása, mely segítségével megállapítható az egyén vagy család napi belépőjének
ára. A belépők ára az alábbi táblázatok szerint alakul.

Egyéni árak
-----------------------------------------------
Felnőtt belépő kedvezmények nélkül      3900 Ft
-----------------------------------------------
Kedvezményes jegyek
-----------------------------------------------
Esti belépő (du. 3 óra után)            1700 Ft
Diák                                    1500 Ft
Nyugdíjas, rokkantsági                  1000 Ft
-----------------------------------------------

Családi árak
-----------------------------------------------
2 felnőtt + 1 gyermek                   9700 Ft
2 felnőtt + 2 gyermek                  12100 Ft
2 felnőtt + 3 gyermek                  14500 Ft
Minden további gyermek esetén 
fizetendő kedvezményes ár               2400 Ft
-----------------------------------------------

A program működését az alábbiak szerint implementálja!

a) Kérdezze meg a felhasználótól, milyen típusú jegyet szeretne vásárolni! ("egyéni" vagy "családi")

b) Egyéni jegy esetén kérdezze meg, van-e valamilyen kedvezményre jogosultsága a felhasználónak! ("igen" vagy "nem")

– Ha van, kérdezze meg mi a kedvezmény típusa és ez alapján számolja ki a jegy árát! ("diák" vagy "nyugdíjas" vagy "rokkant")

– Amennyiben nincs, úgy kérdezze meg hány óra van! Oldja meg ellenőrzött
  adatbekéréssel, hogy ez egy 9 és 18 közötti egész szám legyen, majd ennek
  tekintetében számolja ki a belépő árát!

c) Családi jegy esetén kérdezze meg a gyermekek számát! Oldja meg ellenőrzött adatbekéréssel,
   hogy ez egy 1 és 69 közötti egész szám legyen, majd ennek tekintetében számolja ki a belépő árát!

Példa: Ha a családnak 5 gyermeke van, akkor a fizetendő összeg
14500 + 2 · 2400 = 19300 Ft

d) Jelenítse meg a képernyőn a fizetendő összeget!

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // a)
            Console.Write("A jegy tipusa (1 - egyeni; 2 - csaladi: ");
            string jegyTipusa = Console.ReadLine();
            string kedvezmeny = "0";
            string kedvezmenyTipusa = "0";
            ushort ido = 0;
            int belepoAra = 0;
            ushort gyerekekSzam = 0;
            if (jegyTipusa == "1")
            {
                Console.Write("Van kedvezmeny? (0 - nem, 1 - igen): ");
                kedvezmeny = Console.ReadLine();
                if (kedvezmeny == "1")
                {
                    Console.Write("Van kedvezmeny tipusa? (1 - Diak, 2 - Nyugdijjas, 3 - Rokkant): ");
                    kedvezmenyTipusa = Console.ReadLine();
                    if (kedvezmenyTipusa == "1") belepoAra = 1500;
                    if (kedvezmenyTipusa == "2" || kedvezmenyTipusa == "3") belepoAra = 1000;
                }
                else { 
                        do
                        {
                            Console.Write("hany ora van? (9 - 18): ");
                        } while (!ushort.TryParse(Console.ReadLine(), out ido) || ido < 9 || ido > 18);
                        belepoAra = ido < 15 ? 3900 : 1700;
                }
            } else
            {
                do
                {
                  Console.Write("Gyerekek szama? (1 - 69): ");
                } while (!ushort.TryParse(Console.ReadLine(), out gyerekekSzam) || gyerekekSzam < 1 || gyerekekSzam > 69);
                if (gyerekekSzam == 1) {
                    belepoAra = 9700;
                } else if (gyerekekSzam == 2)
                {
                    belepoAra = 12100;
                } else if (gyerekekSzam >= 3)
                {
                    belepoAra = 14500;
                }
                if (gyerekekSzam > 3) belepoAra += (gyerekekSzam - 3) * 2400;
            }

            Console.WriteLine("A belepo ara: {0}: Ft", belepoAra);
        }
    }
}
