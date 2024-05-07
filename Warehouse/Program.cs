using Models;
using Services.InMemory;
using Warehouse;

//wykorzystanie dziedziczenia i generyczności
GenericProgram<Person> program = new PeopleProgram();

program.Run();

