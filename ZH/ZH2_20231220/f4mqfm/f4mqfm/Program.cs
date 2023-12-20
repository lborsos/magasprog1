using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace f4mqfm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Etel> etelek = new List<Etel>();
            readCsvAndFillEtelek(etelek);

            // 3.
            Console.WriteLine("Fulos etelek a het vegere:");
            foreach (Etel etel in etelek)
            {
                if (etel.rendData >= new DateTime(2023,12,14) && etel.rendData <= new DateTime(2023,12,15) && F2_energiaertek(etel) > 700)
                {
                    Console.WriteLine("{0} ({1}) - {2} kcal, {3} Ft", etel.nev, etel.normal ? "normál" : "kicsi", etel.tomeg, F2_energiaertek(etel), etel.ar);
                }
            }

            //  4.
            Etel kis = new Etel();
            Etel normal = new Etel();
            foreach (Etel etel in etelek)
            {
                if (!etel.normal && etel.kategoria == "rántott")
                {
                    if (etel.ar > kis.ar)
                    {
                        kis = etel;
                    }
                }
                if (etel.normal && etel.kategoria == "főzelék")
                {
                    if (etel.ar > normal.ar)
                    {
                        normal = etel;
                    }
                }
            }
            Console.WriteLine("\n4 feldat");
            Console.WriteLine("A legolcsobb kis adag rántott a {0}, az ara pedig {1}", kis.nev, kis.ar);
            Console.WriteLine("A legolcsobb normál adag főzelék a {0}, az ara pedig {1}", normal.nev, normal.ar);
            Etel dragabb = new Etel();
            dragabb = kis.ar > normal.ar ? kis : normal;
            Console.WriteLine("A {0} a drágább.", dragabb.nev);

            Console.WriteLine("\n 6.");
            string allergen;
            List<string> allergenek = new List<string>();
            do
            {
                Console.Write("Allergen: ");
                allergen = Console.ReadLine();
                if (allergen == "-")
                {
                    break;
                }
                else
                {
                    allergenek.Add(allergen);
                }
            } while (true);


            Console.WriteLine("Az on szamara javasolt etelek:");
            foreach (Etel etel in etelek)
            {
                if (!F5_allergene(etel, allergenek))
                {
                    Console.Write("{0} - allergének: ", etel.nev);
                    foreach (string allerg in etel.allergenek)
                    {
                        Console.Write("{0}, ", allerg);
                    }
                    Console.WriteLine();
                }
            }


            // 8
            Console.WriteLine("\n 8 eladat\n");
            List<string> kategoriak = new List<string>();
            kategoriak = F7_kategoriak(etelek);
            foreach (string kateg in kategoriak)
            {
                Etel alacsonyEnergia = new Etel();
                foreach (Etel etel in etelek)
                {
                    if (F2_energiaertek(etel) > F2_energiaertek(alacsonyEnergia) && etel.kategoria.Contains(kateg) && !etel.kategoria.Contains("gomba"))
                    {
                        alacsonyEnergia = etel;
                    }
                }
                Console.WriteLine("{0}: {1} ({2} gramm), {3} kcal - {4} Ft", kateg, alacsonyEnergia.nev, alacsonyEnergia.tomeg, F2_energiaertek(alacsonyEnergia), alacsonyEnergia.ar);
            }

        }

        static List<string> F7_kategoriak(List<Etel> etelek)
        {
            List<string> kateg = new List<string>();

            foreach (Etel etel in etelek)
            {
                string[] kateggg = etel.kategoria.Split(',');
                foreach (string item in kateggg)
                {
                    if (!kateg.Contains(item))
                    {
                        kateg.Add(item);
                    }
                }
            }
            kateg.Sort();
            return kateg;
        }

        static bool F5_allergene(Etel etel, List<string> allergenek)
        {
            bool van = false;
            foreach (string allergen in allergenek)
            {
                if (etel.allergenek.Contains(allergen))
                {
                    van = true;
                    break;
                }
            }
            return van;
        }
        static int F2_energiaertek(Etel etel)
        {
            return (int)((etel.tomeg * etel.energia) / 100);
        }
        static void readCsvAndFillEtelek(List<Etel> etelek)
        {
            StreamReader sr = new StreamReader("../../MP1_2023_24_ZH2_input.csv", Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                Etel ujEtel = new Etel();
                ujEtel.nev = adatok[0];
                ujEtel.kategoria = adatok[1];
                ujEtel.normal = adatok[2] == "normál" ? true : false;
                ujEtel.tomeg = int.Parse(adatok[3]);
                ujEtel.rendData = DateTime.Parse(adatok[4]);
                ujEtel.allergenek = adatok[5].Split(',');
                ujEtel.energia = int.Parse(adatok[6]);
                ujEtel.ar = int.Parse(adatok[7]);

                etelek.Add(ujEtel);
            }
            sr.Close();
        }

    }

}
