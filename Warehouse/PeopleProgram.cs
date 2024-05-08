using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Properties;

namespace Warehouse
{
    //dziedziczymy po klasie generycznej i abstakcyjnej dlatego musimy zapewnić ciało dla funkcji abstrakcyjnych z klasy bazowej
    internal class PeopleProgram : GenericProgram<Person>
    {
        protected override Person CreateNew()
        {
            return new Person(GetString(Resources.FistName), GetString(Resources.LastName), GetDateTime(Resources.BirthDate));
        }

        protected override Person CreateUpdate(Person old)
        {
            return new Person(GetString($"{Resources.FistName} ({old.FirstName})"), GetString($"{Resources.LastName} ({old.LastName})"), GetDateTime($"{Resources.BirthDate} ({old.BirthDate})"));
        }
    }
}
