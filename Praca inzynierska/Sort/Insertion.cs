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
            for (int i = 1; i < bars.size; i++)
            {
                int j;
                int value = bars.getValue(i);
                for (j = i - 1; j >= 0 && bars.getValue(j) > value; j--)
                {
                    bars.setValue(j + 1, bars.getValue(j));
                    Thread.Sleep(1);
                }
                bars.setValue(j + 1, value);
                Thread.Sleep(1);
            }
        }
    }
}
