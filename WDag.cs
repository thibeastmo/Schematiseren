using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schematiseren
{
    class WDag
    {
        public string Datum { get; set; }
        public List<Auto> AutoLijst { get; set; }
        public WDag()
        {
            AutoLijst = new List<Auto>();
        }
    }
}
