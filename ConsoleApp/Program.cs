

//namespace ConsoleApp
//{
    //internal class Program
    //{
        //static void Main(string[] args)
        //{

            //Instrukcja najwyższego poziomu - instrukcja napisana bezpośrednio w pliku bez klasy i namespace
            //Jest to zawsze punkt startowy programu
            //Dopuszczalny jest tylko jeden plik w rpojekcie z instrukcjami najwyższego poziomu
            Console.WriteLine("Hello, World!");


            //? - obiket nullowalny - skrót od Nullable<int>
            int? a = 4;
            a = null;

            //flaga Nullable z konfiguracji powoduje, że wszystkie typy obiektów będą tak samo traktowane względem null
            object? b = new object();
            b = SetValue();

            if (b != null)
                Console.WriteLine(b.ToString());


            static object? SetValue()
            {
                return null;
            }
//}
//}
//}
