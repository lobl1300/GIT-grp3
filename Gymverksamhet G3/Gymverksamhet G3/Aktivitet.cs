using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymverksamhet_G3
{
    class Aktivitet
    {
        //PROPERTIES
        public string Passnummer { get; set; }
        public string Tidsperiod { get; set; } //gjorde om från DateTime till string för test
        public string Ledande_Instruktor { get; set; }
        public string Traningstyp { get; set; }
        public int Lokal { get; set; }

        //METODER
        public override string ToString()
        {
            return Passnummer + "\t" + Tidsperiod + "\n" + Ledande_Instruktor + "\t" + Traningstyp + "\t" + Lokal;
        }
    }
}
