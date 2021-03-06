﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Praca_inzynierska.Sort
{
    class Bubble : Sort
    {
        public override void sort(Bars bars)
        {
            for (int i = 0; i < bars.size; i++)
            {
                bool swaped = false;
                for (int j = 0; j < bars.size - 1 - i; j++)
                {
                    while (isPaused());
                    if (bars.getValue(j) > bars.getValue(j+1))
                    {
                        accesses++;
                        comparisons++;
                        bars.swap(j, j + 1);
                        accesses++;
                        accesses++;
                        accesses++;
                        swaped = true;
                    }
                    Thread.Sleep(1);
                }
                if (!swaped)
                {
                    break;
                }
            }
            finished = true;
        }
    }
}
