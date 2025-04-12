using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Battleships
{
    public class Field : Button
    {
        public int value;

        public Field()
        {
            value = 0;
            Width = 30;
            Height = 30;
        }
    }
}
