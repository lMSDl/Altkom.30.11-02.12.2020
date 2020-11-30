using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class Delegates
    {
        public delegate void NoParametersNoReturnTypeDelegate();
        public delegate void NoReturnTypeDelegate(string @string);
        public delegate bool Delegate(int int1, int int2);


        public void Func1()
        {
            Console.WriteLine(nameof(Func1));
        }
        public void Func2(string param)
        {
            Console.WriteLine($"{nameof(Func2)} {param}");
        }
        public bool Func3(int x, int y)
        {
            Console.WriteLine($"{nameof(Func3)} {x} {y}");
            return x == y;
        }

        public Delegate Delegate3 { get; set; }

        public void Test()
        {
            var delegate1 = new NoParametersNoReturnTypeDelegate(Func1);
            delegate1();


            NoReturnTypeDelegate delegate2 = null;
            delegate2 = Func2;
            //if(delegate2 != null)
                delegate2?.Invoke("param");

            Delegate3 += Func3;

            for (var i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    if (Delegate3(i, ii))
                        Console.WriteLine($"{i} == {ii}");
                    else
                        Console.WriteLine($"{i} != {ii}");
                }
            }
        }
    }
}
