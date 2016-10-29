using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Tracks
{
    class Rail : Track
    {


		public override char getChar()
		{
			if (!ContainsMinecart)
			{
				return '-';
			}
			return '0';
		}

	}
}
