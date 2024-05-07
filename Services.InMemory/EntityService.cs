using Models;

namespace Services.InMemory
{
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
            int maxId = 0;

            foreach (T e in _entities)
            {
                if(maxId < e.Id)
                    maxId = e.Id;
            }

            maxId = maxId + 1;
            entity.Id = maxId;

            _entities.Add(entity);
        }

        public T? Read(int id)
        {
            /*for(int i= 0; i < _entities.Count; i = i + 1 )
            {
                Entity e = _entities[i];
                if (e.Id == id)
                {
                    return e;
                }
            }*/

            foreach (T e in _entities)
            {
                if (e.Id == id)
                {
                    return e;
                }
            }

            /*IEnumerator<T> enumerator = _entities.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if(enumerator.Current.Id == id)
                {
                    return enumerator.Current;
                }
            }*/

            return null;
        }

        public List<T> Read()
        {
            return new List<T>(_entities);
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
            T? e = Read(id);
            if (e == null)
                return false;

            return _entities.Remove(e);
        }


    }
}
