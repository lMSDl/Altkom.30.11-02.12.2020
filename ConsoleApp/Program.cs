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


            var service = new CalculatorService.CalculatorClient();
            Console.WriteLine($"2*5={service.Multiply(2, 5)}");

            Console.WriteLine(string.Join( " ", new EducatorsService.EducatorsServiceClient().Read().Select(x => x.FirstName + x.LastName)));
        }
    }
}
