using Models;
using Services.InMemory;

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
    Product product = new Product
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

int GetInt(string label)
{
    string data = GetString(label);
    return int.Parse(data);
}

float GetFloat(string label)
{
    string data = GetString(label);
    return float.Parse(data);
}

DateTime GetDateTime(string label)
{
    string data = GetString(label);
    return DateTime.Parse(data);
}