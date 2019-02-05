using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praca_inzynierska.Sort
{
    class Cocktail:Sort
    {
        public override void sort(Bars bars)
        {
            int bottom = 0;
            int top = bars.size - 1;
            bool swaped = true;
            while (swaped == true)
            {
                swaped = false;
                for (int i = bottom; i < top; i = i + 1)
                {
                    while (isPaused()) ;
                    if (bars.getValue(i) > bars.getValue(i+1))
                    {
                        accesses++;
                        comparisons++;
                        bars.swap(i, i + 1);
                        accesses++;
                        accesses++;
                        accesses++;
                        Thread.Sleep(1);
                        swaped = true;
                    }
                }
                top = top - 1;
                for (int i = top; i > bottom; i = i - 1)
                {
                    while (isPaused()) ;
                    if (bars.getValue(i) < bars.getValue(i-1))
                    {
                        accesses++;
                        comparisons++;
                        bars.swap(i, i - 1);
                        accesses++;
                        accesses++;
                        accesses++;
                        Thread.Sleep(1);
                        swaped = true;
                    }
                }
                bottom = bottom + 1;
            }
            finished = true;
        }
    }
}
