using Models;
using Warehouse;


//wykorzystanie dziedziczenia i generyczności
//stosujmeny wyrażenia lambda do utworzenia wskaźników na funkcje anonimowe (czyli takie, które nie posiadają nazw)
GenericProgram<Pet> program = new DelegateProgram<Pet>(
    () =>
        new Pet
        {
            Name = GenericProgram<Pet>.GetString("Name"),
            Age = GenericProgram<Pet>.GetInt("Age")
        },
    old => new Pet
    {
        Name = GenericProgram<Pet>.GetString($"Name ({old.Name})"),
        Age = GenericProgram<Pet>.GetInt($"Age ({old.Age})")
    });

program.Run();

