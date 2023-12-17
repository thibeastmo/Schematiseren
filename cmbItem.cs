using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schematiseren
{
    class cmbItem
    {
        public string Text { get; set; }
        public Object Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
