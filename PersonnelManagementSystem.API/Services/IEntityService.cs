using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Services;

public interface IEntityService<T>
{
    public Task Create(T obj);
    public Task<IEnumerable<T>> GetAll();
    public Task<T?> GetById(Guid id);
}