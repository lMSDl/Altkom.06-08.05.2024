using Models;
using Services.InMemory;
using Warehouse;

//wykorzystanie dziedziczenia i generyczności
GenericProgram<Pet> program = new PetsProgram();

program.Run();

