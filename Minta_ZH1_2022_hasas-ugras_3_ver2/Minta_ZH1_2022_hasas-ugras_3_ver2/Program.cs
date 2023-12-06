/*
3. Feladat. A skandináv hasas-ugrás világbajnokságon minden versenyző 5 db értékelést
kap, melyek mindegyike 0.00 és 5.00 közé esik. Az Ön feladata a verseny eredményét tároló
és azt elemző program elkészítse el az alábbiak szerint!
a) Kérje be a felhasználótól, hogy hány versenyző indult! Amennyiben 3-nál kevesebb,
úgy adjon hibaüzenetet, majd Enter lenyomása után állítsa le a programot!
b) Hozzon létre egy akkora valós értékű tömböt, melyben elfér minden versenyző mind
az 5 db értékelése!
c) Töltse fel a tömböt 2 tizedesjegy pontosságú véletlen értékekkel a [0, 5] intervallumból!
Tekintse ezeket a számokat úgy, mint az egyes versenyzők sorfolytonosan tárolt
eredményeit! Például:
1 versenyzo: 4.43, 4.12, 0.44, 1.00, 2.98
2 versenyzo: 1.30, 3.02, 4.99, 2.66, 4.33
...

d) Határozza meg az egyes versenyzők átlagos pontszámát és írja ki a képernyőre!
e) Határozza meg, hogy melyik versenyző kapta a legmagasabb pontszámú (nem átlagos)
értékelést és írja ki a képernyőre a versenyző sorszámát, valamint az elért
pontszámot!
f) Egy versenyző béna, ha csak 2.00 alatti értékelései vannak. Minden versenyzőről
döntse el, hogy béna-e, vagy sem, majd jelenítse meg az eredményt a képernyőn!
g) A versenyt az az ugró nyeri, akinek a legmagasabb az átlagos értékelése. Határozza
meg, hogy melyik ugró, milyen átlagos pontszámmal nyerte a versenyt! Feltételezheti,
hogy bármely két versenyzőnek különbözik az átlagos értékelése!
*/


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta_ZH1_2022_hasas_ugras_3_ver2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const ushort ertekelesekSzama = 5;

            // a)
            Console.Write("Indulo versenyzok szama (min. 3): ");
            ushort versenyzokSzama;
            versenyzokSzama = ushort.Parse(Console.ReadLine());
            if (versenyzokSzama < 3)
            {
                Console.WriteLine("Nem megfelelo fersenyzok szama! ByeBye.");
                Environment.Exit(1);
            }

            // b)
            double[] ertekelesek = new double[versenyzokSzama * ertekelesekSzama];

            // c)
            Random rnd = new Random();
            for (int i = 0; i < ertekelesek.Length; i++)
            {
                ertekelesek[i] = rnd.Next(501) / 100d;
            }

            // d)
            double maxAtlag = 0;
            ushort maxAtlagJatekos = 0;
            for (int i = 0; i < versenyzokSzama; i++)
            {
                double osszPont = 0;
                for (int j = 0; j < ertekelesekSzama; j++)
                {
                    osszPont += ertekelesek[i * ertekelesekSzama + j];
                }
                Console.WriteLine("A{2} {0,3} versenzo atlaga: {1:0.00}", (i + 1), osszPont / ertekelesekSzama, az(i+1));
                if (osszPont / ertekelesekSzama > maxAtlag)
                {
                    maxAtlag = osszPont / ertekelesekSzama;
                    maxAtlagJatekos = (ushort)(i + 1);
                }
            }
            // Console.WriteLine("");

            // e)
            double maxPontszam = 0;
            ushort maxPontJatekos = 0;
            for (int i = 0; i < ertekelesek.Length; i++)
            {
                if (ertekelesek[i] > maxPontszam)
                {
                    maxPontszam = ertekelesek[i];
                    maxPontJatekos = (ushort)(i / ertekelesekSzama + 1);
                }
            }
            Console.WriteLine("\nA maximum pontot a{2} {0} jatekos erte el {1:0.00} pontal!\n", maxPontJatekos, maxPontszam, az(maxPontJatekos));

            // f)
            ushort benaCount = 0;
            for (int i = 0; i < versenyzokSzama; i++)
            {
                bool bena = true;
                for (int j = 0; j < ertekelesekSzama; j++)
                {
                    if (ertekelesek[i * ertekelesekSzama + j] >= 2)
                    {
                        bena = false;
                    }
                }
                if (bena) { 
                    Console.WriteLine("A{0} {1,3} jatekos {2:0.00}", az(i + 1), i + 1, bena ? "BENA!" : "nem bena");
                    benaCount++;
                }
            }
            if (benaCount==0) Console.WriteLine("Nincs BENA versenyzo!");

            Console.WriteLine("\nA versenyt a{0} {1} jatekos nyerte {2:0.00} atlagos pontal!", az(maxAtlagJatekos), maxAtlagJatekos, maxAtlag);

            Console.WriteLine("\nA versenyzok pontjai:");
            kiir(ertekelesek, ertekelesekSzama, versenyzokSzama);
            Console.ReadLine();
        }

        static void kiir(double[] ertekelesek, ushort ertekelesekSzama, ushort versenyzokSzama)
        {
            for(int i = 0; i < versenyzokSzama; i++)
            {
                Console.Write("A{1} {0,3} jatekos pontjai: ", i+1, az(i+1));
                for (int j = 0; j < ertekelesekSzama; j++)
                {
                    Console.Write("  {0:0.00}", ertekelesek[i * ertekelesekSzama + j]);
                }
                Console.WriteLine();
            }
        }

        static string az(int i)
        {
            return i==1||i==5 ? "z" : " ";
        }
    }
}
