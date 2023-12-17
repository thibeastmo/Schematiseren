using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schematiseren
{
    class Auto
    {
        public int AutoNummer { get; set; }
        public string Weekdag { get; set; }
        public Heen heen { get; set; }
        public Terug terug { get; set; }
    }
}
