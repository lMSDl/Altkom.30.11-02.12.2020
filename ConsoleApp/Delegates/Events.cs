using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class Events
    {
        public delegate void OddNumberDelegate();
        public event OddNumberDelegate OddNumberEvent;
        public OddNumberDelegate OddNumber;


        public delegate void Delegate(object sender, EventArgs args);

        public void Add(int a, int b)
        {
            var result = a + b;
            Console.WriteLine(result);

            if (result % 2 != 0)
                OddNumberEvent?.Invoke();
        }

        private int _counter = 0;

        void CountOddNumbers()
        {
            _counter++;
        }

        public void Test()
        {
            OddNumberEvent = null;
            OddNumberEvent += delegate () { Console.WriteLine("*** Wykryto liczbę ***"); };
            OddNumberEvent += CountOddNumbers;

            for (var i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    Add(i, ii);
                }
            }

            Console.WriteLine($"Counter = {_counter}");
        }
    }
}
