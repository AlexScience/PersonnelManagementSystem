using PersonnelManagementSystem.API.Entities;

namespace PersonnelManagementSystem.API.Services;

public interface IEntityService<T>
{
    public Task Create(T obj);
    public Task<IEnumerable<T>> GetAll();
    public Task<T?> GetById(Guid id);

    public Task Delete(Guid id);
    
    public Task Update(T obj);
}