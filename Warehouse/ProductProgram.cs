using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    internal class ProductProgram : GenericProgram<Product>
    {
        protected override Product CreateNew()
        {
            return new Product()
            {
                Name = GetString("Name"),
                Price = GetFloat("Price"),
                ExpirationDate = GetDateTime("Expiration date")
            };
        }

        protected override Product CreateUpdate(Product old)
        {
            return new Product
            {
                Name = GetString($"Name ({old.Name})"),
                Price = GetFloat($"Price ({old.Price})"),
                ExpirationDate = GetDateTime($"Expiration date ({old.ExpirationDate})")
            };
        }
    }
}
