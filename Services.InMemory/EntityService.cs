using Models;

namespace Services.InMemory
{
    //klasa generyczna
    // where T : Entity - klasy podstawiane za T muszą dziedziczyć po wskazanej klasie
    // w tym przypadku T musi dziedziczyć po Entity ponieważ potrzebujemy informacji o właściwosći Id
    public class EntityService<T> where T : Entity
    {
        private List<T> _entities;

        public EntityService()
        {
            //_products = new List<T>();
            _entities = new();
        }

        public void Create(T entity)
        {
            entity.Id = _entities.Select(x => x.Id).DefaultIfEmpty().Max() + 1;

            _entities.Add(entity);
        }

        public T? Read(int id)
        {
            return _entities.Where(x => x.Id == id).SingleOrDefault();
            //return _entities.Where(x => x.Id == id).DefaultIfEmpty().Single();
        }

        public List<T> Read()
        {
            return _entities.ToList();
        }

        public bool Update(int id, T entity)
        {
            T? e = Read(id);
            if(e == null)
                return false;

            int index = _entities.IndexOf(e);
            _entities.Remove(e);

            entity.Id = id;
            _entities.Insert(index, entity);
            return true;
        }

        public bool Delete(int id)
        {
            int deleted = _entities.RemoveAll(x => x.Id == id);
            return deleted != 0;
        }


    }
}
