using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates.Lambda
{
    internal class LINQ
    {
        int[] numbers = new[] { 1, 2, 5, 7, 3, 8, 0, 9 };

        List<string> strings = "Ala ma kota i dwa psy".Split(' ').ToList();

        List<Person> people = new List<Person>()
        {
            new Person("Adam","Adamski", DateTime.Now.AddYears(-23) ),
            new Person("Ewa","Adamska", DateTime.Now.AddYears(-32) ),
            new Person("Adam","Ewowski", DateTime.Now.AddYears(-35) ),
            new Person("Ewa","Ewowska", DateTime.Now.AddYears(-63) ),
            new Person("Piotr","Piotrowska", DateTime.Now.AddYears(-33) ),
            new Person("Piotr","Adamski", DateTime.Now.AddYears(-66) ),
            new Person("Ewa","Piotrowska", DateTime.Now.AddYears(-72) ),
            new Person("Piotr","Ewowski", DateTime.Now.AddYears(-42) )
        };


        public void Test()
        {
            //var - typ zmiennej zostanie okreslony po prawej stronie znaku =
            var query1 = from value in numbers where value > 4 select value;
            var query2 = from value in numbers where value < 4 orderby  value descending select value;
            var query3 = from person in people where person.BirthDate.Value.Year > 1980 select (person.FirstName + " " + person.LastName);

            query1 = numbers.Where(value => value > 4)/*.Select(value => value)*/;
            query2 = numbers.Where(value => value < 4).OrderByDescending(value => value);
            query3 = people.Where(person => person.BirthDate.Value.Year > 1980).Select(person => $"{person.FirstName} {person.LastName}");

            var result3 = query3.ToList(); //kończy zapytanie i zwraca kolekcję
            var result4 = people.Where(x => x.FirstName == "Adam")//.Single(); //kończy zapytanie i zwraca JEDYNY rezultat 
                                                                  //.SingleOrDefault(); //orDefault = jeśli nie znaleziono to zwraca wartość domyślną
                                                                  //.First(); // -||- i zwraca pierwszy znaleziony
                                                                .FirstOrDefault();
                                                                //.Last(); // -||- ostatni znaleziony
                                                                //.LastOrDefault();

            var result5 = people.Where(x => x.FirstName == "Adam").Where(x => x.LastName.StartsWith("E")).Single();
            var result6 = people.Where(x => x.FirstName == "Adam" || x.FirstName == "Ewa").ToList();
            //var result6 = people.Where(x => x.FirstName is "Adam" or "Ewa").ToList();

            var result7 = people.Select(x => DateTime.Now.Year - x.BirthDate.Value.Year).Average();

            var result8 = people.Select(x => x.FirstName).Aggregate((a, b) => $"{a}, {b}");

            //1. posortować kolekcję strings po ilości liter w wyrazach
            //2. Zsumować wartości kolekcji numbers
            //3. Z People wybrać osoby, które mają na imię Piotr lub Ewa
            //4. z People wybrać osoby w wieku 50+ i wybrać ich nazwisko małymi literami
            //5. wybrać pojedynczą osobę z imieniem dłuższym niż 3 znaki
        }
    }
}
