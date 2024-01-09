using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Rendszám                szöveg
Forgalmi érvényesség    dátum év.hónap.nap formátumban
Gyártó                  szöveg
Állapot                 szöveg
Klíma                   szöveg
Váltó                   szöveg (manuális vagy automata)
Ár                      egész szám (az autó eredeti ára)
Évjárat                 egész szám
*/

namespace MP1_ZH2_minta01_autok
{
    internal class Auto
    {
        public string rendszam;
        public DateTime ervenyesseg;
        public string gyarto;
        public string allapot;
        public string klima;
        public bool auomatta;
        public int ar;
        public int evjarat;
    }
}
