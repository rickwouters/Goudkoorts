﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Water : Block
    {

        private char output = '~';

		public new Water NextBlock { get; set; }

		public new char getChar()
		{

			return output;

		}

	}
}
