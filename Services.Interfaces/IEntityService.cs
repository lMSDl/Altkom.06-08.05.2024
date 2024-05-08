using Models;

namespace Services.Interfaces
{
    //interfejs - posiada metody, które muszą implementować klasy zgodne z nim
    public interface IEntityService<T> where T : Entity
    {
        void Create(T entity);
        T? Read(int id);
        List<T> Read();
        bool Update(int id, T entity);
        bool Delete(int id);
    }
}
