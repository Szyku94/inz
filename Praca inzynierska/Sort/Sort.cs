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
        protected bool finished = false;
        protected int comparisons = 0;
        protected int accesses = 0;
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
        public int getComparisons()
        {
            return comparisons;
        }
        public int getAccesses()
        {
            return accesses;
        }
        public bool isFinished()
        {
            return finished;
        }
        public void setFinished(bool finished)
        {
            this.finished = finished;
        }
    }
}
