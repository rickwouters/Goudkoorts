using Goudkoorts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Tracks
{
	class EmptyBlock : Block
	{

		public new char getChar()
		{
			return ' ';
		}

	}
}
