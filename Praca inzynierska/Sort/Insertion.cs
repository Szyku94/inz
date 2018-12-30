using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Praca_inzynierska.Sort
{
    class Insertion:Sort
    {
        public override void sort(Bars bars)
        {
            for (int i = 0; i < bars.size; i++)
            {
                int j;
                int value = bars.getValue(i);
                for (j = i - 1; j >= 0 && bars.getValue(j) > value; j--)
                {
                    bars.setColor(j, Color.Blue);
                    bars.setColor(j + 1, Color.Yellow);
                    Thread.Sleep(1);
                    bars.setValue(j + 1, bars.getValue(j));
                    bars.setColor(j, Color.White);
                    bars.setColor(j + 1, Color.White);
                }
                bars.setColor(j + 1, Color.Blue);
                Thread.Sleep(1);
                bars.setValue(j + 1, value);
                bars.setColor(j + 1, Color.White);
            }
        }
    }
}
