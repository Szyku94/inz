using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praca_inzynierska.Sort
{
    abstract class Sort
    {
        private bool step;
        private bool paused = true;
        public abstract void sort(Bars bars);
        public void changePause()
        {
            paused = !paused;
        }
        public bool isPaused()
        {
            if(step)
            {
                step = false;
                paused = true;
            }
            return paused;
        }
        public void nextStep()
        {
            paused = false;
            step = true;
        }
    }
}
