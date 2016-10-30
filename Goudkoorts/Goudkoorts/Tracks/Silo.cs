using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Tracks
{
    class Silo : Track
    {
        public override char getChar()
        {
            return 'X';
        }

        public Minecart spawnCart()
        {
            Minecart cart = new Minecart(this);
            cart.Move();
            return cart;
        }
    }
}
