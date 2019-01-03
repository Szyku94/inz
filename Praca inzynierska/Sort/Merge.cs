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
        }
        private void mergeSort(Bars bars, int p, int r)
        {
            if(p<r)
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
                if (bars.getValue(i) < bars.getValue(j))
                {
                    temp.setValue(k++, bars.getValue(i++));
                }
                else
                {
                    temp.setValue(k++, bars.getValue(j++));
                }
            }
            while (i <= q)
            {
                temp.setValue(k++, bars.getValue(i++));
            }
            while (j <= r)
            {
                temp.setValue(k++, bars.getValue(j++));
            }
            for (i=0; i<temp.size;i++)
            {
                Thread.Sleep(3);
                bars.setValue(p+i, temp.getValue(i));
            }
        }
    }
}
