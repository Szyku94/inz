using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praca_inzynierska.Sort
{
    class Selection:Sort
    {
        public override void sort(Bars bars)
        {
            for (int i = bars.size; i >= 2; i--)
            {
                int max = 0;
                for (int j = 1; j < i; j++)
                {
                    while (isPaused()) ;
                    bars.setColor(j, Color.Red);
                    bars.setColor(max, Color.Green);
                    Thread.Sleep(3);
                    max = bars.getValue(max) < bars.getValue(j) ? j : max;
                }
                Thread.Sleep(3);
                if (max != i - 1)
                    bars.swap(i - 1, max);
            }
        }
    }
}
