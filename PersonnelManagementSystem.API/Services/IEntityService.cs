using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Services;

public interface IEntityService<T>
{
    public void Create(T obj);
    public IEnumerable<T> GetAll();
    public T? GetById(Guid id);
}