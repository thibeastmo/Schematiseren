using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schematiseren
{
    class Heen
    {
        public string Bestuurder { get; set; }
        public List<string> Passagiers { get; set; }
        public Heen()
        {
            Passagiers = new List<string>();
        }
    }
}
