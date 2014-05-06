using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymverksamhet_G3
{
    class Medlemskort: Medlem
    {
        public string Medlemskort { get; set; }
        public string Utgangsdatum { get; set; }

        public override string ToString()
        {
            return Utgangsdatum;
        }
    }
}
