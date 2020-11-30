using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class MulticastDelegates
    {
        public delegate void ShowMessage(string @string);

        public void Message1(string msg)
        {
            Console.WriteLine($"1st message: {msg}");
        }

        public void Message2(string msg)
        {
            Console.WriteLine($"2st message: {msg}");
        }

        public void Test()
        {
            ShowMessage messageDelegate = null;
            messageDelegate += Message1;
            messageDelegate += Message2;
            messageDelegate += Console.WriteLine;

            messageDelegate("Hello");
            messageDelegate("Hi");

            messageDelegate -= Message2;
            messageDelegate("Hello");

            messageDelegate = null;

            messageDelegate += Message1;
            messageDelegate += Message2;
            messageDelegate = Console.WriteLine;


            messageDelegate += Message1;
            messageDelegate += Message1;
            messageDelegate += Message1;

            messageDelegate -= Message1;

            messageDelegate("Hello");
        }
    }
}
