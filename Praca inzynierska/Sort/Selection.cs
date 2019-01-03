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
                int max = findMax(bars,i);
                Thread.Sleep(3);
                if (max != i - 1)
                    bars.swap(i - 1, max);
            }
        }
        private int findMax(Bars bars,int n)
        {
            int max = 0;
            for (int i = 1; i < n; i++)
            {
                bars.setColor(i, Color.Red);
                bars.setColor(max, Color.Green);
                Thread.Sleep(3);
                max = bars.getValue(max) < bars.getValue(i) ? i : max;
            }
                
            return max;
        }
    }
}
