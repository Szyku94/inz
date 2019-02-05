using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praca_inzynierska.Sort
{
    class Counting : Sort
    {
        override public void sort(Bars bars)
        {
            Bars temp = new Bars(bars.size);//tablica pomocnicza
            temp.zeros();
            int[] count = new int[bars.size];//tablica do zliczania ilości wystąpień znaków
            for (int i = 0; i < bars.size; i++)
            {
                count[i] = 0;//zerowanie tablicy
            }
            for (int i = 0; i < bars.size; i++)
            {
                bars.setColor(i, Color.Red);
                while (isPaused()) ;
                Thread.Sleep(3);
                count[bars.getValue(i)]++;
                accesses++;
            }
            for (int i = 1; i < bars.size; i++) //podsumowywanie tablicy aby ukazywała miejsca poszukiwanych znaków
            {
                count[i] += count[i - 1];
                accesses++;
            }
            //przechodzenie tablicy ciągów znaku i zmiana miejsc według tablicy zliczającej
            for (int i = bars.size - 1; i >= 0; i--)
            {
                bars.setColor(i, Color.Red);
                while (isPaused()) ;
                Thread.Sleep(3);
                temp.setValue(--count[bars.getValue(i)],bars.getValue(i));
            }
            for (int i = 0; i < bars.size; i++)//podmiana orginalnej tablicy
            {
                bars.setValue(i, temp.getValue(i));
                accesses++;
                while (isPaused()) ;
                Thread.Sleep(3);
            }
            finished = true;
        }
    }
}