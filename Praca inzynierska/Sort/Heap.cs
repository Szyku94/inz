using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praca_inzynierska.Sort
{
    class Heap : Sort
    {
        private void heapify(Bars bars, int n, int i)
        {
            while (isPaused()) ;
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && bars.getValue(left) > bars.getValue(largest))
            {
                accesses++;
                comparisons++;
                bars.setColor(largest, Color.Green);
                bars.setColor(left, Color.Green);
                Thread.Sleep(3);
                largest = left;
            }
            Thread.Sleep(3);
            if (right < n && bars.getValue(right) > bars.getValue(largest))
            {
                accesses++;
                comparisons++;
                bars.setColor(largest, Color.Green);
                bars.setColor(right, Color.Green);
                Thread.Sleep(3);
                largest = right;
            }


            if (largest != i)
            {
                Thread.Sleep(3);
                bars.swap(i, largest);
                accesses++;
                accesses++;
                accesses++;
                heapify(bars, n, largest);
            }
        }
        override public void sort(Bars bars)
        {
            for (int i = bars.size / 2 - 1; i >= 0; i--)
                heapify(bars, bars.size, i);

            for (int i = bars.size - 1; i >= 0; i--)
            {
                while (isPaused());
                Thread.Sleep(3);
                bars.swap(0, i);
                accesses++;
                accesses++;
                accesses++;
                heapify(bars, i, 0);
            }
            finished = true;
        }
    }
}
