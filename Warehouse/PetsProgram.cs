using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    internal class PetsProgram : GenericProgram<Pet>
    {
        protected override Pet CreateNew()
        {
            return new Pet { Name = GetString("Name"), Age = GetInt("Age") };
        }

        protected override Pet CreateUpdate(Pet old)
        {
            return new Pet { Name = GetString($"Name ({old.Name})"), Age = GetInt($"Age ({old.Age})") };
        }
    }
}
