/*
 
A projekt célja egy olyan alkalmazás megvalósítása, mely egy input fájlban levo filmes
adatbázist beolvas, majd azon különbözo lekérdezéseket, feladatokat valósít meg.
A mellékelt filmek.csv input fájl minden sorában egy-egy film adatait találja pontosvesszovel
elválasztva egymástól az alábbi struktúrában.
-------------------------------------------------------------------------------
Rendezo                 szöveg
Film címe               szöveg
Premier éve             egész szám
Premier hónapja         egész szám
Premier napja           egész szám
Kategória               szöveg (vesszovel elválasztva többet is tartalmazhat)
IMDB értékelés          1 és 10 közötti valós szám
Korhatár                egész szám (7, 12, 16 vagy 18)
Feliratos értéke        "feliratos" vagy "nem feliratos"
-------------------------------------------------------------------------------
1. Feladat. Az input fájl beolvasását az alábbiak szerint végezze el!

a) Készítsen osztályt, mely a fájlban található filmek tárolására alkalmas!
b) Az év, hónap, nap adatok esetén használjon dátum és ido tárolására alkalmas típust!
c) Az, hogy a film feliratos-e logikai típusú változóban tárolja!
d) Készítsen listát, mely az osztály a példányainak tárolására alkalmas!
e) Olvassa be az adatok.csv fájl-t, és a soronként elkészített példányokat mentse el az ere a célra létrehozott listába!

2. Feladat. Írja ki a képernyore azon filmek adatait, melyeknek még nem volt premierjük!

A filmeket az alábbi mintának megfeleloen jelenítse meg!
Denis Villeneuve - Dune: Part II (2023 október 20)

3. Feladat. Készítsen függvényt, mely eldönti, hogy van-e a paraméterben kapott filmek
   között olyan, mely egy adott rendezo alkotása. Az függvény paraméterei:
– Az összes filmet tartalmazó lista: ezt vizsgáljuk
– Rendezo neve: azt kell eldönteni, hogy van-e filmje a listában

4. Feladat. Írja ki a képernyore a felhasználó kedvenc filmjeit az alábbiak szerint!

a) Kérje be a felhasználótól a kedvenc rendezojének nevét!
b) A 3. feladatban elkészített függvény segítségével döntse el, hogy van-e általa készített
   film a listában. Ha nincs, értesítse errol a felhasználót!
c) Amennyiben vannak a rendezonek filmjei a listában, úgy írja ki a képernyore a filmek címét és a megjelenés évét!

5. Feladat. Készítsen eljárást, melynek feladata listába gyujteni azon filmeket, melyek
   egy adott kategóriába sorolhatók. Az eljárás paraméterei:
– Az összes filmet tartalmazó lista: ebbol válogatunk
– Filmek tárolására alkalmas lista: a listát ürítjük, majd ebbe gyujtjük össze a feltételnek megfelelo filmeket
– Kategória

6. Feladat. A 5. feladatban elkészített eljárás segítségével válogassa ki egy Ön által
létrehozott listába a sci-fi filmeket, és írja ki azokat a képernyore az alábbi formátumban.
Denis Villeneuve - Dune (szinkronos)
Denis Villeneuve - Dune: Part II (feliratos)    

7. Feladat. Törölje a listából az egyik filmet az alábbiak szerint!

a) Kérje be a felhasználótól egy film rendezojét és címét!
b) Törölje a filmet a listából!
c) Amennyiben nincs ilyen film a listában, úgy értesítse a felhasználót errol!

8. Feladat. Írjon függvényt, mely a felhasználó által kedvelt kategóriákat beolvassa és
   listába gyujtve visszaadja az alábbiak szerint!
a) A függvénynek nincs paramétere.
b) A felhasználótól folyamatosan kérjük be a kategóriákat, amíg azt nem írja be "vége"
c) A kategóriákat tároljuk el egy listába és térjünk vissza vele.

9. Feladat. A felhasználó többedmagával szeretne filmet nézni, listázza ki az összes lehetséges filmet számukra!
a) Kérje be a legfiatalabb személy életkorát!
b) Kérje be a felhasználótól a társaság által kedvelt kategóriákat a 8 függvény segítségével!
c) Kérje be a felhasználótól, hogy szóba jöhet-e feliratos film!
d) Írja ki a képernyore az összes olyan film címét, mely megfelel a bekért adatoknak!

10. Feladat. Kategóriánként írja ki a képernyore a legmagasabb IMDB értékelést kapott
    filmet! Csak azokat a filmeket vegye figyelembe, amelyeknek már volt premierjük!

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics.SymbolStore;

namespace Minta_ZH2_2021_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Film> filmek = new List<Film>(); // 1.d)
            readCsvAndFillFilmek(filmek); // 1.e)
            noPremier(filmek); // 2

            // 4
            Console.Write("\nAdd meg a kedvenc rendezodot: ");
            string kerRendezoName = Console.ReadLine(); // 4.a)
            if (kerRendezo(filmek, kerRendezoName)) // 4.b)
            {
                // 4.c)
                Console.WriteLine("\nA {0} filmjei:", kerRendezoName);
                foreach (Film film in filmek)
                {
                    if (film.rendezo == kerRendezoName) Console.WriteLine("{0} - {1}", film.cim, film.premier.ToString("yyyy"));
                }
            } else Console.WriteLine("A {0} rendezonek nincsenek filmjei!", kerRendezoName);

            // 6
            List<Film> filmekSciFi = new List<Film>();
            filmekKategoria(filmek,  filmekSciFi, "sci-fi");
            Console.WriteLine("\nFilmek amik a sci-fi kategoriaba tartoznak:");
            foreach (Film film in filmekSciFi)
            {
                Console.WriteLine("{0} - {1}", film.rendezo, film.cim);
            }


            // 7 a)
            Console.Write("\nA torolni kivant film cime: ");
            string torCim = Console.ReadLine();
            Console.Write("A torolni kivant film rendezojenek a neve: ");
            string torRendezo = Console.ReadLine();
            int index = -1;
            for (int i = 0; i < filmek.Count; i++)
            {
                if (filmek[i].cim == torCim && filmek[i].rendezo == torRendezo)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1) Console.WriteLine("Nem talalhato a torlessel eggyezo adat a listaba!"); // 7.c)
            else 
            {
                filmek.RemoveAt(index); // 7.b)
                Console.WriteLine("A film torolve az adatbazisbol!");
            }

            // Denis Villeneuve

            // 9
            Console.Write("Add meg a legfiatalabb eletkorat: ");
            int eletkor = int.Parse(Console.ReadLine());
            List<string> kategoriak = kategoriakBeolvasasa();
            Console.Write("0 - felirat nelkul; barmi mas - felirattal, valassz (0, ...): ");
            string felirat = Console.ReadLine();
            foreach (Film film in filmek)
            {
                bool talalat = false;
                if (film.korhatar >= eletkor && film.feliratos == (felirat != "0"))
                {
                    foreach (string kateg in film.kategoria)
                    {
                        if (kategoriak.Contains(kateg))
                        {
                            talalat = true;
                            break;
                        }
                    }
                }
                if (talalat) Console.WriteLine("{0}", film.cim);
            }

            // 10
            Console.WriteLine("\nEgyedi kategoriak listaja ami a maximum imdb szamot tartalmazza:");
            kategoriak.Clear(); // felhasznalom a mar letezo listat!
            foreach (Film film in filmek) foreach (string kateg in film.kategoria) if (!kategoriak.Contains(kateg)) kategoriak.Add(kateg);
            
            // foreach (Film film in filmek) foreach (string kateg in film.kategoria) kategoriak.Add(kateg);
            // kategoriak.Distinct();

            // foreach (var item in kategoriak) Console.WriteLine(item);

            foreach (string kategoria in kategoriak)
            {
                Film filmTmp = new Film();
                foreach (Film film in filmek)
                {
                    if (film.kategoria.Contains(kategoria) && filmTmp.imdb < film.imdb) filmTmp = film;
                }
                if (filmTmp.imdb > 0) Console.WriteLine("{0} - maximum imdb: {1}", kategoria, filmTmp.imdb);
            }

            Console.ReadLine();
        }

        // 8
        static List<string> kategoriakBeolvasasa()
        {
            List<string> kategoriak = new List<string>();
            Console.WriteLine("Add meg a kategoriakat (vege - Exit): ");
            string kategoria;
            while (true)
            {
                Console.Write(">");
                kategoria = Console.ReadLine();
                if (kategoria == "vege") break;
                if (!kategoriak.Contains(kategoria)) kategoriak.Add(kategoria);
            }
            return kategoriak;
        }

        // 5
        static void filmekKategoria(List<Film> filmek, List<Film> filmekKategoria, string kategoria)
        {
            filmekKategoria.Clear();
            foreach (Film film in filmek)
            {
                if (film.kategoria.Contains(kategoria)) filmekKategoria.Add(film);
            }
        }
        static void noPremier(List<Film> filmek)
        {
            Console.WriteLine("Filmek aminek meg nem volt premierje!\n");
            foreach (Film film in filmek)
            {
                if (film.premier > new DateTime(2020,01,01))
                {
                    Console.WriteLine("{0} - {1} ({2})", film.rendezo, film.cim, film.premier.ToString("yyyy MMMM d"));
                }
            }
        }

        // 3
        static bool kerRendezo(List<Film> filmek, string kerRendezoName)
        {
            foreach (Film film in filmek)
            {
                if (film.rendezo == kerRendezoName) return true;
            }
            return false;
        }

        static void readCsvAndFillFilmek(List<Film> filmek)
        {
            StreamReader sr = new StreamReader("ZH2_2021_22 - input.csv", Encoding.Default);
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                Film ujFilm = new Film();
                ujFilm.rendezo = adatok[0];
                ujFilm.cim = adatok[1];
                ujFilm.premier = DateTime.Parse(String.Format("{0}.{1}.{2}", adatok[2], adatok[3], adatok[4]));
                ujFilm.kategoria = adatok[5].Split(',');
                ujFilm.imdb = double.Parse(adatok[6]);
                ujFilm.korhatar = int.Parse(adatok[7]);
                ujFilm.feliratos = adatok[8] == "feliratos" ? true : false;

                filmek.Add(ujFilm);
            }
            sr.Close();
        }
    }
}
