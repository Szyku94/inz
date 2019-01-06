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
        }
        public void random()
        {
            for (int i = 0; i < size; i++)
            {
                bars.Add(new Bar(i));
            }
            shuffle();
        }
        public void zeros()
        {
            for (int i = 0; i < size; i++)
            {
                bars.Add(new Bar(0));
            }
        }
        public void fewUnique(int number)
        {
            for (int i = 0; i < size; i++)
            {
                bars.Add(new Bar((int)((i% (double)number / number + 1F / number) *(size))-1));
                Console.WriteLine(getValue(i));
            }
            shuffle();
        }
        public void shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                swap(random.Next(size), random.Next(size));
            }
        }
        public void reverseSort()
        {
            bars.Clear();
            for (int i = 0; i < size; i++)
            {
                bars.Add(new Bar(size-i));
            }
        }
        public void swap(int a,int b)
        {
            setColor(a, Color.Red);
            setColor(b, Color.Red);
            Bar tmp = new Bar(bars.ElementAt(a).value);
            bars.ElementAt(a).value = bars.ElementAt(b).value;
            bars.ElementAt(b).value = tmp.value;
        }
        public int getValueOnly(int i)
        {
            return bars.ElementAt(i).value;
        }
        public int getValue(int i)
        {
            setColor(i, Color.White);
            return bars.ElementAt(i).value;
        }
        public void setValue(int i, int value)
        {
            setColor(i, Color.Red);
            bars.ElementAt(i).value = value;
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
