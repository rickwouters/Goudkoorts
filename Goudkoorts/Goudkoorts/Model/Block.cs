using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
	public abstract class Block
	{
		public Block NextBlock
		{
			get;
			set;
		}

		public char getChar()
		{
			return 'a';
		}

	}
}
