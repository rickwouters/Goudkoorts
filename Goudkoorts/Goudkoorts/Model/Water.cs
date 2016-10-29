using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Water
    {

        private char output = '~';

        public Water next { get; set; }

        public char Print()
        {

            return output;

        }

    }
}
