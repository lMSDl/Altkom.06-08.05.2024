using Models;
using Services.Interfaces;

namespace Services.InMemory
{
    //klasa generyczna
    // where T : Entity - klasy podstawiane za T muszą dziedziczyć po wskazanej klasie
    // w tym przypadku T musi dziedziczyć po Entity ponieważ potrzebujemy informacji o właściwosći Id
    public class MemoryEntityService<T> : IEntityService<T> where T : Entity
    {
        protected List<T> Entities { get; }

        public MemoryEntityService()
        {
            //_products = new List<T>();
            Entities = new();
        }

        public virtual void Create(T entity)
        {
            entity.Id = Entities.Select(x => x.Id).DefaultIfEmpty().Max() + 1;

            Entities.Add(entity);
        }

        public T? Read(int id)
        {
            return Entities.Where(x => x.Id == id).SingleOrDefault();
            //return _entities.Where(x => x.Id == id).DefaultIfEmpty().Single();
        }

        public List<T> Read()
        {
            return Entities.ToList();
        }

        public virtual bool Update(int id, T entity)
        {
            T? e = Read(id);
            if(e == null)
                return false;

            int index = Entities.IndexOf(e);
            Entities.Remove(e);

            entity.Id = id;
            Entities.Insert(index, entity);
            return true;
        }

        public virtual bool Delete(int id)
        {
            int deleted = Entities.RemoveAll(x => x.Id == id);
            return deleted != 0;
        }


    }
}
