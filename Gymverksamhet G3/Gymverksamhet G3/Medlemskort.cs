using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymverksamhet_G3
{
    class Medlemskort: Medlem
    {
        //PROPERTIES
        public string Medlemskortet { get; set; }
        public string Utgangsdatum { get; set; }

        //METODER
        public override string ToString()
        {
            return Utgangsdatum;
        }
    }
}
