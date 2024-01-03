/*
3. Feladat. 

Ebben a feladatban a Star Wars filmből jól ismert jedi lovagok adataival kell
dolgoznia. Az adatokat a mellékelt jedik.csv fájlban találja! A fájl minden sorában egy
adott jedi adatait találja a következő struktúrában!
---------------------------------------------------------
Név                 szöveg
---------------------------------------------------------
Midiklorián         szám egész
Fénykard színe      szöveg
Tanácstagság        szöveg (tanácstag vagy nem tanácstag)
---------------------------------------------------------

3.1. Részfeladat. Az input fájl beolvasását az alábbiak szerint végezze el!

a) Készítsen osztályt, mely a fájlban található jedik tárolására alkalmas!
b) Azt, hogy a jedi tanácstag-e logikai típusú változóban tárolja!
c) Készítsen listát, mely az osztály a példányainak tárolására alkalmas!
d) Olvassa be az jedik.csv fájl-t, és a soronként elkészített példányokat mentse el az
   ere a célra létrehozott listába!

3.2. Részfeladat. Írja ki a képernyőre a jedi lovagok átlagos midikloriánszámát!

3.3. Részfeladat. Készítsen jedi lovagokat tartalmazó listával visszatérő metódust, mely-
     nek feladata egy adott színű karddal rendelkező jedik kiválogatása, és azok visszaadása!

A függvénynek két paramétere van:
– jedi lovagok at tartalmazó lista: ez tartalmazza az összes jedit
– szöveg: a keresett kardszín

3.4. Részfeladat. Az előző feladatban létrehozott függvény segítségével válogassa ki a
     kék karddal rendelkező jediket és írja ki a képernyőre az összes adatukat!

3.5. Részfeladat. Írja ki a képernyőre kardszínek szerint csoportosítva a legkevesebb
     midikloriánnal rendelkező jedi lovag nevét és hogy tanácstag-e! */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Jedi> jedik = new List<Jedi>();
            beolvas(jedik);

            int osszM = 0, dbM = 0;
            foreach (Jedi jedi in jedik)
            {
                if (jedi.tanacstag)
                {
                    osszM += jedi.midiklorian;
                    dbM++;
                }
            }
            Console.WriteLine("Atlagos jedik mszama: {0}\n", (double)(osszM / dbM));

            List<Jedi> szurtJedik = new List<Jedi>();
            szurtJedik = jedikSzin(jedik, "kek");
            foreach (Jedi jedi in szurtJedik)
            {
                Console.WriteLine("{0} - {1} - {2}", jedi.midiklorian, jedi.szin, jedi.tanacstag ? "tanacstag" : "nem tanacstag");
            }


            Console.WriteLine("\n3.5\n");
            List<string> szinek = new List<string>();
            foreach (Jedi jedi in jedik)
            {
                if (!containsSzin(szinek, jedi.szin))
                {
                    szinek.Add(jedi.szin);
                }
            }

            foreach (string szin in szinek)
            {
                Jedi minJedi = new Jedi();
                minJedi.midiklorian = int.MaxValue;
                foreach (Jedi jedi in jedik)
                {
                    if (jedi.szin == szin && jedi.midiklorian < minJedi.midiklorian)
                    {
                        minJedi = jedi;
                    }
                }
                Console.WriteLine("{0} - {1} - {2}", minJedi.szin, minJedi.midiklorian, minJedi.tanacstag ? "tanacstag" : "nem tanacstag");
            }

            Console.ReadLine();
        }

        private static bool containsSzin(List<string> szinek, string szin)
        {
            foreach (string szinTmp in szinek)
            {
                if (szinTmp == szin)
                {
                    return true;
                }
            }
            return false;
        }

        private static List<Jedi> jedikSzin(List<Jedi> jedik, string szin)
        {
            List<Jedi> jedikSz = new List<Jedi>();
            foreach (Jedi jedi in jedik)
            {
                if (jedi.tanacstag && jedi.szin == szin)
                {
                    jedikSz.Add(jedi);
                }
            }
            return jedikSz;
        }

        private static void beolvas(List<Jedi> jedik)
        {
            StreamReader sr = new StreamReader("../../jedik.csv", Encoding.UTF8);
            // sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                Jedi ujJedi = new Jedi();
                ujJedi.midiklorian = int.Parse(adatok[0]);
                ujJedi.szin = adatok[1];
                ujJedi.tanacstag = adatok[2] == "tanácstag" ? true : false;
                jedik.Add(ujJedi);
            }
            sr.Close();
        }
    }
}
