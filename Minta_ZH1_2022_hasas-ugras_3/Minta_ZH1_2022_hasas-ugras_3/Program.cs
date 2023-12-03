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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta_ZH1_2022_hasas_ugras_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const ushort eredmenyekSzama = 5;
            Console.Write("Add meg a jatekosok szamat (minimum 3):");
            ushort jatekosokSzama;
            jatekosokSzama = ushort.Parse(Console.ReadLine());
            if (jatekosokSzama < 3)
            {
                Console.WriteLine("Kevesebbet irtal be mint 3! ByeBye!");
                Console.ReadLine();
                Environment.Exit(1);
            }
            Console.WriteLine();
            double[,] eredmenyek = new double[jatekosokSzama, eredmenyekSzama + 3];
            Random rnd = new Random();
            for (int i = 0; i < jatekosokSzama; i++)
            {
                Console.Write("Versenyzo {0}: ", (i+1).ToString("00"));
                double atlag = 0;
                double bena = 1;
                double maxPontszam = 0;
                for (int j = 0; j < eredmenyekSzama; j++)
                {
                    double randomPont = Math.Round(rnd.NextDouble() * 5, 2);
                    eredmenyek[i, j] = randomPont;
                    atlag += randomPont;
                    if (randomPont > maxPontszam) maxPontszam = randomPont;
                    if (randomPont >= 2d) bena = 0d;
                    Console.Write("{0} ", randomPont.ToString("0.00"));
                }
                eredmenyek[i, eredmenyekSzama] = Math.Round(atlag / eredmenyekSzama,2);
                eredmenyek[i, eredmenyekSzama + 1] = bena;
                eredmenyek[i, eredmenyekSzama + 2] = maxPontszam;
                Console.WriteLine();
            }
            Console.WriteLine("\nKezdhetjuk... ENTER a folytatas!");
            Console.ReadLine();
            eredmenyekKiirasa(jatekosokSzama, eredmenyekSzama, eredmenyek);
            Console.WriteLine();
            Console.WriteLine("ENTER a kilepeshez... ByeBye :)");
            Console.ReadLine();
        }
        static void eredmenyekKiirasa(ushort jatekosokSzama, ushort eredmenyekSzama, double[,] eredmenyek)
        {
            Console.WriteLine("\nEredmenyek kiirasa:\n");
            double maxPont = 0, maxAtlag = 0;
            ushort maxPontSorszam = 0, maxAtlagSorszam = 0;
            for (ushort i = 0; i < jatekosokSzama; i++)
            {
                Console.WriteLine("Versenyzo {0} atlag: {1}     {2}", 
                    (i + 1).ToString("00"), eredmenyek[i, eredmenyekSzama].ToString("0.00"), eredmenyek[i, eredmenyekSzama + 1] == 1d ? "(bena)" : "");
                if (eredmenyek[i, eredmenyekSzama + 2] > maxPont)
                {
                    maxPont = eredmenyek[i, eredmenyekSzama + 2];
                    maxPontSorszam = i;
                }
                if (eredmenyek[i, eredmenyekSzama] > maxAtlag)
                {
                    maxAtlag = eredmenyek[i, eredmenyekSzama];
                    maxAtlagSorszam = i;
                }
            }
            Console.WriteLine();
            Console.WriteLine("A legmagasabb pontszamot kapott versenyzo a {0} -es, pontszama pedig: {1}", (maxPontSorszam + 1).ToString("00"), maxPont.ToString("0.00"));
            Console.WriteLine();
            Console.WriteLine("A legmagasabb  atlagot kapott  versenyzo a  {0} -es,    atlaga pedig: {1}", (maxAtlagSorszam + 1).ToString("00"), maxAtlag.ToString("0.00"));
        }
    }
}
