using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Praca_inzynierska.Sort
{
    class Bubble : Sort
    {
        public override void sort(Bars bars)
        {
            for (int i = 0; i < bars.size; i++)
            {
                bool swaped = false;
                for (int j = 0; j < bars.size - 1 - i; j++)
                {
                    bars.setColor(j, Color.Blue);
                    bars.setColor(j+1, Color.Blue);
                    if (bars.getValue(j) > bars.getValue(j+1))
                    {
                        bars.setColor(j,Color.Yellow);
                        bars.setColor(j+1, Color.Yellow);
                        bars.swap(j, j + 1);
                        swaped = true;
                    }
                    Thread.Sleep(1);
                    bars.setColor(j, Color.White);
                    bars.setColor(j + 1, Color.White);
                }
                if (!swaped)
                {
                    break;
                }
            }
        }
    }
}
