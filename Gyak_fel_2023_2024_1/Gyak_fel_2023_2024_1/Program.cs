/*
 1. Feladat. (Bemelegítés) 

Egy ház építéséhez szeretnénk megbecsülni, hogy hány téglát
kell vásárolnunk a külső falak felépítéséhez. Az épület alakja téglalap alakú, és lesz rajta
néhány ablak és ajtó.
Kérje be a felhasználótól a tervezett épület szélességét, hosszát és magasságát méterben,
valamint az ajtók és ablakok számát ellenőrzötten!

Egy ajtó 2,4, míg egy ablak 1,8 négyzetméter. Az épület tetején és alján nem lesz
tégla! Csak a falakat építjük!

Ha bármelyik érték negatív vagy nulla, vagy ha az ablakok és ajtók területe meghaladja
az épület falának 30%-át, akkor kérjük be újra az egyes adatokat!

Számítsa ki és írja ki a képernyőre, hogy vélhetőleg hány téglára lesz szükség, ha egy
darab tégla szélessége, hosszúsága és magassága rendre 200mm × 500mm × 250mm! 
A feladat megoldásához a hosszúság és magasság adatokból számolja a tégla külső felületét!

A téglákat raklapon árulják, melynek alapterülete 120cm × 120cm. Számítsa ki és
jelenítse meg, hány raklapra lesz szükség, ha egy raklap terhelhetősége 2,1tonna és az
utolsó raklap kivételével csak teljes "rétegnyi" téglát raknak rá! Egy tégla tömege 17,68kg.

 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak_fel_2023_2024_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double ajto_m2 = 1.8, ablak_m2 = 2.4;
            const int teglaSz = 200, teglaH = 500, teglaM = 250;
            const double teglaTomeg = 17.68;
            const int raklapH = 120, raklapSz = 120;
            const double raklapTerhelhetoseg = 2.1;
            double szelesseg, hosszusag, magassag, epulet_m2, ajtoAblak_m2;
            int ajto = 0, ablak = 0;
            bool ok = true;
            do
            {
                do
                {
                    Console.Write("Az epulet szelessege: (m): ");
                } while (!double.TryParse(Console.ReadLine(), out szelesseg) || szelesseg <= 0);

                do
                {
                    Console.Write("Az epulet hosszusaga: (m): ");
                } while (!double.TryParse(Console.ReadLine(), out hosszusag) || hosszusag <= 0);

                do
                {
                    Console.Write("Az epulet magassag: (m): ");
                } while (!double.TryParse(Console.ReadLine(), out magassag) || magassag <= 0);
                do
                {
                    Console.Write("Ajtok szama: ");
                } while (!int.TryParse(Console.ReadLine(), out ajto) || ajto <= 0);
                do
                {
                    Console.Write("Ablakok szama: ");
                } while (!int.TryParse(Console.ReadLine(), out ablak) || ablak <= 0);
                epulet_m2 = (szelesseg + hosszusag) * magassag * 2;
                ajtoAblak_m2 = ajto_m2 * ajto + ablak_m2 * ablak;
                if (ajtoAblak_m2 > epulet_m2 * .3)
                {
                    Console.WriteLine("Az ajto / ablak m2 nagyobb mint az epulet m2 30% anal!");
                    Console.WriteLine("egy bilentyu leutessel kezd elorrol!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else ok = false;
            } while (ok);
            double tegla_m2 = teglaH * teglaM / 1e6;
            int teglakSzama = (int)Math.Ceiling((epulet_m2 - ajtoAblak_m2) / tegla_m2);
            Console.WriteLine("Az epulethez {0} tegla kell!", teglakSzama);

            double raklapTerulet = raklapH * raklapSz / 1e4;
            int raklapSorTeglaDb = (int)Math.Floor(raklapTerulet / (teglaSz * teglaH / 1e6));
            int raklapraFertSor = (int)Math.Floor(raklapTerhelhetoseg * 1e3 / raklapSorTeglaDb / teglaTomeg);
            int raklapSzukseg = (int)Math.Ceiling((double)teglakSzama / raklapraFertSor / raklapSorTeglaDb);
            Console.WriteLine("Szukseges raklapok szama: {0} db", raklapSzukseg);

            Console.ReadLine();
        }
    }
}
