using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_inzynierska
{
    class Bar
    {
        public int value { set; get; }
        public Color color{ set; get; }
        public Bar(int value, Color color)
        {
            this.value = value;
            this.color = color;
        }
        public Bar(int value)
        {
            this.value = value;
            this.color = Color.White;
        }

    }
}
