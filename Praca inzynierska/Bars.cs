using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Praca_inzynierska
{
    class Bars
    {
        List<Bar> bars;
        public int size { get; }
        public Bars(int size)
        {
            this.size = size;
            bars = new List<Bar>();
            for(int i=0;i<size;i++)
            {
                bars.Add(new Bar(i));
            }
        }
        public void shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                swap(random.Next(size), random.Next(size));
            }
        }
        public void swap(int a,int b)
        {
            Bar tmp = bars.ElementAt(a);
            bars.ElementAt(a).color = bars.ElementAt(b).color;
            bars.ElementAt(a).value = bars.ElementAt(b).value;
            bars.ElementAt(b).color = tmp.color;
            bars.ElementAt(b).value = tmp.value;
        }
        public int getValue(int i)
        {
            return bars.ElementAt(i).value;
        }
        public Color getColor(int i)
        {
            return bars.ElementAt(i).color;
        }
        public void setColor(int i, Color color)
        {
            bars.ElementAt(i).color=color;
        }
    }
}
