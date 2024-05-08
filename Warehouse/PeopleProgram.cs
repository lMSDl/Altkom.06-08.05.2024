using Models;
using Services.Interfaces;
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
        public PeopleProgram(IEntityService<Person> service) : base(service)
        {
        }

        protected override Person CreateNew()
        {
            return new Person(GetString(Resources.FistName), GetString(Resources.LastName), GetDateTime(Resources.BirthDate));
        }

        protected override Person CreateUpdate(Person old)
        {
            return new Person(GetString($"{Resources.FistName} ({old.FirstName})"), null, GetDateTime($"{Resources.BirthDate} ({old.BirthDate})"));
        }
    }
}
