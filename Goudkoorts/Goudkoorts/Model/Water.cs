using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Water : Block
    {
		public new Water NextBlock { get; set; }

        public Boolean hasShip { get; set; }

        public override char getChar()
        {
            if (hasShip)
                return ']';
            return '~';
        }
	}
}
