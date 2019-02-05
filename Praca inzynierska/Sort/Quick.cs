using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praca_inzynierska.Sort
{
    class Quick:Sort
    {
        public override void sort(Bars bars)
        {
            quickSort(bars, 0, bars.size - 1);
            finished = true;
        }
        private void quickSort(Bars bars, int p, int r)
        {
            while (isPaused()) ;
            int q;
            if(p<r)
            {
                q = partition(bars, p, r);
                quickSort(bars, p, q);
                quickSort(bars, q + 1, r);
            }
        }
        private int partition(Bars bars, int p, int r)
        {
            int x = bars.getValue(p);
            accesses++;
            int i = p, j = r;
            while(true)
            {
                while (bars.getValue(j) > x)
                {
                    accesses++;
                    comparisons++;
                    while (isPaused()) ;
                    j--;
                }
                while (bars.getValue(i) < x)
                {
                    accesses++;
                    comparisons++;
                    while (isPaused()) ;
                    i++;
                }
                if (i < j)
                {
                    while (isPaused()) ;
                    bars.swap(i++, j--);
                    accesses++;
                    accesses++;
                    accesses++;
                    Thread.Sleep(30);
                }
                else
                    return j;
            }
        }
    }
}
