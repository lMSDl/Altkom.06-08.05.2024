using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates.Events
{
    internal class EventsExample
    {
        public delegate void OddNumber();
        //event <nazwa delegata którego opakowujemy> <nazwa eventu>
        public event OddNumber OddNumberEvent;

        public OddNumber OddNumberDelegate { get; set; }

        public void Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine(result);

            if (result % 2 != 0)
            {
                OddNumberDelegate?.Invoke();
                OddNumberEvent?.Invoke();
            }
        }

        private int _counter;
        private void CountOdd()
        {
            _counter++;
        }

        public EventsExample()
        {
            OddNumberDelegate += CountOdd;
            OddNumberEvent += CountOdd;
        }

        public void Test()
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Add(i, j);
                }
            }

            Console.WriteLine("Counter: " + _counter);
        }

    }
}
