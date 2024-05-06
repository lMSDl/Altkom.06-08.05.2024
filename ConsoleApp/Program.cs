

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

Product product1 = new Product() { Price = 33 };
Product product2 = new Product("marchew", 23);

product1.SetName("Test");
Console.WriteLine( product1.GetName() );

//product2.SetName("marchew");
Console.WriteLine(product2.GetName());


product1.Price = 12;
//product2.Price = 23;

product1.ExpirationDate = new DateTime(2024, 4, 12);
//product2.ExpirationDate = new DateTime(2024, 6, 22);
Console.WriteLine(product1.ExpirationDate);
Console.WriteLine(product2.ExpirationDate);

Console.WriteLine(product2.CreateDescription());


Person person1 = new Person
{
    LastName = "Monikowska",
    FirstName = "Monika"
};
//person1.BirthDate = new DateTime(2000,2,2);

Person person2 = new Person("Ewa", "Ewowska", new DateTime(2000, 1, 1));


Console.WriteLine(person1.Bio());
Console.WriteLine(  person2.Bio());


Pizza pizza1 = new Pizza() { Cheese = true, Ham = true };

Pizza pizza2 = new Pizza() { Sauce = true, Ham = true, Tomato = true };

static void Nullable()
{
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
}



//}
//}
//}
