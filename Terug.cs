using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schematiseren
{
    class Terug
    {
        public string Bestuurder { get; set; }
        public List<string> Passagiers { get; set; }
        public Terug()
        {
            Passagiers = new List<string>();
        }
    }
}
