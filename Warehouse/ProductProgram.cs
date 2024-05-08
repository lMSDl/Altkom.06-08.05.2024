using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Properties;

namespace Warehouse
{
    internal class ProductProgram : GenericProgram<Product>
    {
        protected override Product CreateNew()
        {
            return new Product()
            {
                Name = GetString(Resources.Name),
                Price = GetFloat(Resources.Price),
                ExpirationDate = GetDateTime(Resources.ExpirationDate)
            };
        }

        protected override Product CreateUpdate(Product old)
        {
            return new Product
            {
                Name = GetString($"{Resources.Name} ({old.Name})"),
                Price = GetFloat($"{Resources.Price} ({old.Price})"),
                ExpirationDate = GetDateTime($"{Resources.ExpirationDate} ({old.ExpirationDate})")
            };
        }
    }
}
