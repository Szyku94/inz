using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_inzynierska
{
    class Run
    {
        static void Main(string[] args)
        {
            using (SortWindow win = new SortWindow(800, 600))
            {
                win.Run(30.0);
            }
        }
    }
}
