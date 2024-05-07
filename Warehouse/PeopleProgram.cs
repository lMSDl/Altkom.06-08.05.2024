using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    internal class PeopleProgram : GenericProgram<Person>
    {
        protected override Person CreateNew()
        {
            return new Person(GetString("Imię"), GetString("Nazwisko"), GetDateTime("Data urodzenia"));
        }

        protected override Person CreateUpdate(Person old)
        {
            return new Person(GetString($"Imię ({old.FirstName})"), GetString($"Nazwisko ({old.LastName})"), GetDateTime($"Data urodzenia ({old.BirthDate})"));
        }
    }
}
