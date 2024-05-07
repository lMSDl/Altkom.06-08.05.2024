using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    internal class DelegatesExample
    {
        delegate void VoidWithoutParameters();
        delegate void VoidWithParameters(string someString);
        public delegate bool BoolWithParameters(int x, int y);

        public void Func1()
        {
            Console.WriteLine("1");
        }

        //@ - pozwala użyć zastrzeżonej nazwy dla zmiennych
        public void Func2(string @string)
        {
            Console.WriteLine(@string);
        }
        public bool Func3(int a, int b)
        {
            Console.WriteLine("a = " + a + " ,b = " + b);
            return a == b;
        }

        public BoolWithParameters Delegate3 { get; set; }

        public void Test()
        {
            VoidWithoutParameters delegate1 = new VoidWithoutParameters(Func1);

            delegate1.Invoke();
            delegate1();
            Func1();

            VoidWithParameters delegate2 = null;

            if (delegate2 != null)
                delegate2("Hello!");

            delegate2?.Invoke("Hello!"); //? - sprawdza czy obiekt nie jest null i tylko wtedy wykonuje metodę

            delegate2 = Func2;

            delegate2?.Invoke("Hello!");

            Delegate3 = Func3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var result = Delegate3(i, j);
                    if (result)
                        Console.WriteLine("==");
                }
            }
        }

        public bool Check(BoolWithParameters @delegate, int a, int b)
        {
            return @delegate.Invoke(a, b);
        }
    }
}
