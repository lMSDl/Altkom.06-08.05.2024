using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates.Lambda
{
    internal class LambdaExample
    {
        Func<int, int, int> Calculator { get; set; }
        Func<string> SomeFunc { get; set; }
        Action<int> SomeAction { get; set; }
        Action AnotherAction { get; set; }

        //wyrażenie lambda
        //<opcjonalny parametr> <operator> <ciało>
        // (a, b) => {}

        public void Test()
        {
            Calculator += //delegate (int a, int b) { return a + b; };
                          //(int a, int b) => { return a + b; };
                          //(a, b) => { return a + b; };
                          (a, b) => a + b;

            SomeFunc += //delegate { return "Hello!"; };
                        () => "Hello!";

            SomeAction += //delegate (int a) { Console.WriteLine(a); };
                            //(a) => Console.WriteLine(a);
                            a => Console.WriteLine(a);

            AnotherAction += //delegate { Console.WriteLine(); };
                () => Console.WriteLine();
        }               

    }
}
