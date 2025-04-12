using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public class Ship : Button
    {
        public int size;
        public bool placed = false;

        public Ship(int size)
        {
            this.size = size;
            this.Width = 20 * size;
        }
    }
}
