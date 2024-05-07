using Models;
using Services.InMemory;
using Warehouse;


Pet CreateNew()
{
    return new Pet { Name = GenericProgram<Pet>.GetString("Name"), Age = GenericProgram<Pet>.GetInt("Age") };
}

Pet CreateUpdate(Pet old)
{
    return new Pet { Name = GenericProgram<Pet>.GetString($"Name ({old.Name})"), Age = GenericProgram<Pet>.GetInt($"Age ({old.Age})") };
}

//wykorzystanie dziedziczenia i generyczności
GenericProgram<Pet> program = new DelegateProgram<Pet>(CreateNew, CreateUpdate);

program.Run();

