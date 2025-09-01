using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Common_Enteties
{
   public class PasukNach:Location
    {
        public string Book { get; set; }
        public string Perek { get; set; }
        public string Pasuk { get; set; }
        public string Text { get; set; }


    }
}
