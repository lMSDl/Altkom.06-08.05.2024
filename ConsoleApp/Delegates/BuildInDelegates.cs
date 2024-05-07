using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    internal class BuildInDelegatesExample
    {
        public void Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine(result);
        }
        public bool Substract(int a, int b)
        {
            int result = a - b;
            Console.WriteLine(result);
            return result % 2 != 0;
        }


        public void Test()
        {
            Method(Add, Substract);
        }

        //delegate void Method1Deleagate(int a, int b);
        //delegate bool Method2Deleagate(int a, int b);

        //void Method(Method1Deleagate method1, Method2Deleagate method2)

        //Action - wbudowana definicja delegata wskazująca na funkcje nie zwracające rezultatu. Typ i ilość parametów przekazujemy jako parametry generyczne.
        //Func - wbudowana definicja delegata wskazująca na funkcje zwracające jakiś rezultat. Typ rezultatu jest ostatnim (lub jedynym) parametrem generycznym.
        void Method(Action<int, int> method1, Func<int, int, bool> method2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    method1(i, j);
                    if (method2(i, j))
                        Console.WriteLine("@@@");
                }
            }
        }
    }
}
