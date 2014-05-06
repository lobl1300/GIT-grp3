using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymverksamhet_G3
{
    class Instruktor
    {
        //PROPERTIES
        public string Personnummer { get; set; }
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public string Telefonummer { get; set; }
        public string Mailadress { get; set; }
        public string Gatuadress { get; set; }

        //METODER
        public override string ToString()
        {
            return Fornamn + " " + Efternamn;
        }


    }
}
