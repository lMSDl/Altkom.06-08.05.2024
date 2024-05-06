using Models;

namespace Services.InMemory
{
    public class ProductsService
    {
        private List<Product> _products;

        public ProductsService()
        {
            //_products = new List<Product>();
            _products = new();
        }

        public void Create(Product product)
        {
            int maxId = 0;

            foreach (Product p in _products)
            {
                if(maxId < p.Id)
                    maxId = p.Id;
            }

            maxId = maxId + 1;
            product.Id = maxId;

            _products.Add(product);
        }

        public Product? Read(int id)
        {
            /*for(int i= 0; i < _products.Count; i = i + 1 )
            {
                Product p = _products[i];
                if (p.Id == id)
                {
                    return p;
                }
            }*/

            foreach (Product p in _products)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            /*IEnumerator<Product> enumerator = _products.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if(enumerator.Current.Id == id)
                {
                    return enumerator.Current;
                }
            }*/

            return null;
        }

        public List<Product> Read()
        {
            return new List<Product>(_products);
        }

        public bool Update(int id, Product product)
        {
            Product? p = Read(id);
            if(p == null)
                return false;

            int index = _products.IndexOf(p);
            _products.Remove(p);

            product.Id = id;
            _products.Insert(index, product);
            return true;
        }

        public bool Delete(int id)
        {
            Product? p = Read(id);
            if (p == null)
                return false;

            return _products.Remove(p);
        }


    }
}
