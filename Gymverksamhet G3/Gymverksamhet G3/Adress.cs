﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymverksamhet_G3
{
    class Adress
    {
        //PROPERTIES
        public string Gatuadress { get; set; }
        public string Postnummer { get; set; }
        public string Ort { get; set; }
        public string land { get; set; } // bara en test i GIT
                                         //Lotta testar med! Mera mera mera bgfgfgdgfg
        
        //METODER
        public override string ToString()
        {
            return Postnummer + " " + Ort;
        }
    }
}
