using Models;
using Services.InMemory;
using System;

ProductsService _service = new ProductsService();



bool exit = false;
do
{
    Console.Clear();
    Show();
    Console.WriteLine( "Commands: create, update, delete, exit" );


    string input  = Console.ReadLine();

    switch (input)
    {
        case "exit":
            exit = true;
            break;
        case "create":
            Create();
            break;
        case "update":
            Update();
            break;
        case "delete":
            Delete();
            break;
        default:
            Console.WriteLine("command not found...");
            Console.ReadLine();
            break;
    }


} while (!exit);

void Update()
{
    int id = GetInt("Id");
    Product old = _service.Read(id);
    if (old == null)
        return;

    Product product = new Product
    {
        Name = GetString($"Name ({old.Name})"),
        Price = GetFloat($"Price ({old.Price})"),
        ExpirationDate = GetDateTime($"Expiration date ({old.ExpirationDate})")
    };

    _service.Update(id, product);
}

void Delete()
{
    int id = GetInt("Id");

    _service.Delete(id);
}

void Show()
{
    foreach (Product p in _service.Read())
    {
        Console.WriteLine( $"{p.Id}\t{p.Name}\t{p.Price}\t{p.ExpirationDate}"  );
    }
}

void Create()
{
    Product product = new Product()
    {
        Name = GetString("Name"),
        Price = GetFloat("Price"),
        ExpirationDate = GetDateTime("Expiration date")
    };

    _service.Create(product);
}

string GetString(string label)
{
    Console.WriteLine($"{label}:");
    string data = Console.ReadLine();
    return data;
}



float GetFloat(string label)
{
    string data = GetString(label);

    //try-catch - służy do obsługi wyjątków.
    //W bloku try umieszczamy kod w którym może potencjalnie wystąpić wyjątek
    //Blok catch zawiera kod, który ma być wykonany jeśli wyjątek wystąpi
    try
    {
        return float.Parse(data);
    }
    //catch - bez parametru - przechwytuje wszystkie wyjątki i nie daje wglądu w obiekt wyjątku
    //catch() - z parametrem - przechwytuje wyjątki zgodne z klasą parametru, dając wgląd w obiekt
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
        return GetFloat(label);
    }
}

int GetInt(string label)
{
    string data = GetString(label);
    try
    {
        //throw new ArgumentException();
        return int.Parse(data);
    }
    //możemy mieć wiele bloków catch w kolejność od szczegółu do ogółu (najbardziej ogólny wyjątek na końcu)
    //dzięki temu możemy wykonywać różne akcje w zależności od klasy wyjątku
    catch (IndexOutOfRangeException) //nazwa parametru jest opcjonalna - jeśli nie potrzebujemy odczytywać właściwości z obiektu wyjątku nie musimy deklarować nazwy 
    {
        return -1;
    }
    catch (FormatException e) //korzystamy z właściwości wyjątku, więc nazywamy jego obiekt jako "e", żeby mieć do niego dostęp
    {
        Console.WriteLine(e.Message);
        return GetInt(label);
    }
    catch (Exception)
    {
        return -2;
    }
}

DateTime GetDateTime(string label)
{
    DateTime date;
    bool success;
    do
    {
        string data = GetString(label);
        //metoda TryParse zamiast rzucać wyjątek przy niepowodzeniu, zwraca informację w postaci bool (true/false) czy parsowanie się powiodło
        //rezultat parzowania możemy użyskać z drugiego parametru
        //parametry, który zwracają dodatkowe informacje z funkcji nazywane są parametrami wyjściowymi i muszą być poprzedzone słowem kluczowym "out" zarówno w definicji funkcji jak i podczas jej wywoływania
        success = DateTime.TryParse(data, out date);
    } while (!success);

    return date;
}