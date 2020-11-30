using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class BuildInDelegates
    {
        public event EventHandler<OddNumberEventArgs> OddNumberEvent;

        public void Add(int a, int b)
        {
            var result = a + b;
            Console.WriteLine(result);

            if (result % 2 != 0)
                OddNumberEvent?.Invoke(this, new OddNumberEventArgs { Result = result });
        }
        public bool Substract(int a, int b)
        {
            var result = a - b;
            Console.WriteLine(result);
            return result % 2 != 0;
        }

        private int _counter = 0;

        void CountOddNumbers()
        {
            _counter++;
        }


        //public delegate void Delegate1(int a, int b);
        //public delegate bool Delegate2(int a, int b);

        private void NewMethod(Action<int, int> a, Func<int, int, bool> b)
        {
            for (var i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    a(i, ii);
                    b(i, ii);
                }
            }
        }

        public void Test()
        {
            OddNumberEvent += BuildInDelegates_OddNumberEvent;
            OddNumberEvent += BuildInDelegates_OddNumberEvent1;

            NewMethod(Add, Substract);

            Console.WriteLine($"Counter = {_counter}");
        }

        private void BuildInDelegates_OddNumberEvent1(object sender, EventArgs e)
        {
            CountOddNumbers();
        }

        private void BuildInDelegates_OddNumberEvent(object sender, OddNumberEventArgs e)
        {
            Console.WriteLine($"** Wykryto liczbę ** {e.Result}");
        }

        public class OddNumberEventArgs : EventArgs
        {
            public int Result { get; set; }
        }
    }
}
