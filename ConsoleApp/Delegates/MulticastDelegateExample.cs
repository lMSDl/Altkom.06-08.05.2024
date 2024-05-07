using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    internal class MulticastDelegateExample
    {
        public delegate void MuticastDelegate(string @string);

        public void Message1(string message)
        {
            Console.WriteLine("1st message: " + message);
        }
        public void Message2(string message)
        {
            Console.WriteLine("2nd message: " + message);
        }
        public void Message3(string message)
        {
            Console.WriteLine("3rd message: " + message);
        }

        public void Test()
        {
            MuticastDelegate @delegate = null;

            //+= przypina metodę do delegate (dodaje do listy "subskrypcji")
            @delegate += Message1;
            @delegate += Message2;
            @delegate += Message3;
            @delegate += Console.WriteLine;

            @delegate("ala ma kota");

            //-= odpiuna metodę od delegata
            @delegate -= Message2;

            @delegate("i dwa psy");

            // = - delegat od teraz wskazuje tylko na tę jedną konkretną metodę
            @delegate = Message1;

            @delegate("Bye!");
        }
    }
}
