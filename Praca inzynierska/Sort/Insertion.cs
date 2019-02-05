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
                accesses++;
                for (j = i - 1; j >= 0 && bars.getValue(j) > value; j--)
                {
                    accesses++;
                    comparisons++;
                    while (isPaused());
                    bars.setValue(j + 1, bars.getValue(j));
                    accesses++;
                    accesses++;
                    Thread.Sleep(1);
                }
                bars.setValue(j + 1, value);
                accesses++;
                Thread.Sleep(1);
            }
            finished = true;
        }
    }
}
