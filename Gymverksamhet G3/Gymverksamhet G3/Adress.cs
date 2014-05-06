using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymverksamhet_G3
{
    class Adress
    {
        public string Gatuadress { get; set; }
        public string Postnummer { get; set; }
        public string Ort { get; set; }

        public override string ToString()
        {
            return Postnummer + " " + Ort;
        }
    }
}
