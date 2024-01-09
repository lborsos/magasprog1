using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Lego> legok = new List<Lego>();
            beolvas(legok);


            // 2.5
            Lego legtobbE = new Lego(); ;
            Lego legdragabb = new Lego(); ;
            foreach (Lego lego in legok)
            {
                if (lego.elemekSz > legtobbE.elemekSz)
                {
                    legtobbE = lego;
                }
                if (lego.ar > legdragabb.ar)
                {
                    legdragabb = lego;
                }
            }
            if (legtobbE == legdragabb)
            {
                Console.WriteLine("A legtobb elemet tartalmazo lego a legdragabb!");
            }
            else
            {
                Console.WriteLine("NEM a legtobb elemet tartalmazo lego a legdragabb!");
            }

            // 2.7
            List<string> kategoria = new List<string>();
            kategoria = kategABC(legok);

            int keszletNem = 0;
            double osszArKateg = 0;
            int szam = 0;
            double atlag = 0, maxAtlagAr = 0;
            string legdtagabbKateg = "";
            foreach (string kateg in kategoria)
            {
                keszletNem = 0;
                osszArKateg = 0;
                szam = 0;
                foreach (Lego lego in legok)
                {
                    if (lego.kategoria == kateg && !lego.elerheto)
                    {
                        keszletNem += lego.elemekSz;
                    }
                    osszArKateg += lego.ar;
                    szam++;
                    atlag = osszArKateg / szam;
                    if (atlag > maxAtlagAr)
                    {
                        maxAtlagAr = atlag;
                        legdtagabbKateg = kateg;
                    }
                }
                Console.WriteLine("{0} kateg. ben nem elerheto keszletek szama: {1} db", kateg, keszletNem);

            }


            // 2.8

            Console.WriteLine("Legdragabb kategoria: {0}", legdtagabbKateg);



        }

        private static List<string> kategABC(List<Lego> legok)
        {
            List<string> kategoria = new List<string>();
            foreach (Lego lego in legok)
            {
                if (!kategoria.Contains(lego.kategoria))
                {
                    kategoria.Add(lego.kategoria);
                }
            }
            kategoria.Sort();
            return kategoria;
        }

        private static void beolvas(List<Lego> legok)
        {
            StreamReader sr = new StreamReader("../../Input_magyar.csv", Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                Lego ujLego = new Lego();
                ujLego.szorszam = adatok[0];
                ujLego.kategoria = adatok[1];
                ujLego.keszletNev = adatok[2];
                ujLego.elemekSz = int.Parse(adatok[3]);
                ujLego.ar = int.Parse(adatok[4]);
                ujLego.elerheto = adatok[5] == "automata" ? true : false;
                legok.Add(ujLego);
            }
            sr.Close();
        }

    }

}
