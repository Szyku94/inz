using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praca_inzynierska.Sort
{
    class Merge:Sort
    {
        public override void sort(Bars bars)
        {
            mergeSort(bars, 0, bars.size-1);
            finished = true;
        }
        private void mergeSort(Bars bars, int p, int r)
        {
            while (isPaused()) ;
            if (p<r)
            {
                int q = (p + r) / 2;
                mergeSort(bars, p, q);
                mergeSort(bars, q+1, r);
                merge(bars, p, q, r);
            }
        }
        private void merge(Bars bars, int p, int q, int r)
        {
            Bars temp = new Bars(r - p +1);
            temp.zeros();
            int i = p, j = q+1,k=0;
            while (i<=q && j<=r)
            {
                while (isPaused()) ;
                if (bars.getValue(i) < bars.getValue(j))
                {
                    accesses++;
                    comparisons++;
                    temp.setValue(k++, bars.getValue(i++));
                    accesses++;
                }
                else
                {
                    temp.setValue(k++, bars.getValue(j++));
                    accesses++;
                }
            }
            while (i <= q)
            {
                while (isPaused()) ;
                temp.setValue(k++, bars.getValue(i++));
                accesses++;
                accesses++;
            }
            while (j <= r)
            {
                while (isPaused()) ;
                temp.setValue(k++, bars.getValue(j++));
                accesses++;
                accesses++;
            }
            for (i=0; i<temp.size;i++)
            {
                while (isPaused()) ;
                bars.setValue(p+i, temp.getValue(i));
                accesses++;
                accesses++;
                Thread.Sleep(3);
            }
        }
    }
}
