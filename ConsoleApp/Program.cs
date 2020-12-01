using ConsoleApp.Lambda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Delegates.Events();
            test.Test();

            test.OddNumber = delegate () { };
            test.OddNumber += delegate () { };
            test.OddNumber = null;

            test.OddNumberEvent += delegate () { };
            test.OddNumberEvent -= delegate () { };

            //test.OddNumberEvent = delegate () { };
            //test.OddNumberEvent = null;

            new Linq().Test();
        }
    }
}
