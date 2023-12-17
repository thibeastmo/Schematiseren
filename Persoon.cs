using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schematiseren
{
    class Persoon
    {
        /// <summary>
        /// 1 = heen
        /// 2 = terug
        /// 3 = heen + terug
        /// 4 = moet vervoerd worden
        /// </summary>
        public string Naam { get; set; }
        public int Maandag { get; set; }
        public int Dinsdag { get; set; }
        public int Woensdag { get; set; }
        public int Donderdag { get; set; }
        public int Vrijdag { get; set; }
        public int Zaterdag { get; set; }
        public int Zondag { get; set; }
    }
}
