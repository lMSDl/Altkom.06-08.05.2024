using Models;

namespace Services.Interfaces
{
    public interface IEntityService<T> where T : Entity
    {
        void Create(T entity);
        T? Read(int id);
        List<T> Read();
        bool Update(int id, T entity);
        bool Delete(int id);
    }
}
