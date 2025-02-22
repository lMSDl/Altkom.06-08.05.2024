﻿using Models;
using Services.InFile;
using Services.InMemory;
using System.Globalization;
using Warehouse;
using Warehouse.Properties;


//ręczna zmiany ustawień regionalnych programu
//Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pl");

//wykorzystanie dziedziczenia i generyczności
//stosujmeny wyrażenia lambda do utworzenia wskaźników na funkcje anonimowe (czyli takie, które nie posiadają nazw)
/*GenericProgram<Pet> program = new DelegateProgram<Pet>(
    () =>
        new Pet
        {
            Name = GenericProgram<Pet>.GetString(Warehouse.Properties.Resources.Name),
            Age = GenericProgram<Pet>.GetInt(Resources.Age)
        },
    old => new Pet
    {
        Name = GenericProgram<Pet>.GetString($"{Resources.Name} ({old.Name})"),
        Age = GenericProgram<Pet>.GetInt($"{Resources.Age} ({old.Age})")
    });*/


//GenericProgram<Person> program = new PeopleProgram(new SymmetricFileEntityService<Person>("data.json", "123456"));
GenericProgram<Person> program = new PeopleProgram(new AsymmetricFileEntityService<Person>("data.json", "CN=localhost"));

program.Run();

