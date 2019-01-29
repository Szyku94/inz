using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Praca_inzynierska.Sort
{
    class Shell : Sort
    {
        override public void sort(Bars bars)
        {
            int k = 1, step;
            do
            {
                step = Convert.ToInt32(2 * (bars.size / Math.Pow(2, k + 1)) + 1);
                for (int i = 0; i < step; i++)
                {
                    sortInsert(bars, step, i);
                }
                k++;
            } while (step > 1 && !checkIfSorted(bars));
        }
        void sortInsert(Bars bars, int step, int start)
        {
            for (int i = start + step; i < bars.size; i+=step)
            {
                int j;
                int value = bars.getValue(i);
                for (j = i - step; j >= 0 && bars.getValue(j) > value; j-=step)
                {
                    while (isPaused()) ;
                    bars.setValue(j + step, bars.getValue(j));
                    Thread.Sleep(1);
                }
                bars.setValue(j + step, value);
                Thread.Sleep(1);
            }
        }
        bool checkIfSorted(Bars bars)
        {
            for (int i = 1; i < bars.size; i++)
            {
                if (bars.getValue(i - 1) > bars.getValue(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
