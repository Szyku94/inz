using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praca_inzynierska.Sort
{
    class Comb:Sort
    {
        public override void sort(Bars bars)
        {
            int gap = bars.size;
            float shrink = 1.3F;
            bool sorted = false;
            while(!sorted)
            {
                gap = (int)Math.Floor(gap / shrink);
                if(gap<=1)
                {
                    gap = 1;
                    sorted = true;
                }
                for (int i = 0; i + gap < bars.size; i++)
                {
                    bars.setColor(i, Color.Green);
                    bars.setColor(i+gap, Color.Green);
                    while (isPaused()) ;
                    Thread.Sleep(10);
                    if (bars.getValue(i)>bars.getValue(i+gap))
                    {
                        bars.swap(i, i + gap);
                        Thread.Sleep(10);
                        sorted = false;
                    }
                }
            }
        }
    }
}
