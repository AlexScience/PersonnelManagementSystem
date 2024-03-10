using PersonnelManagementSystem.API.Infrastructure;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Services;

public class ObjEntityService<T> :IEntityService<T>
    where T : IEntity
{
    private readonly IDataStorage<T> _objStorage;

    public ObjEntityService(IDataStorage<T> objStorage)
    {
        _objStorage = objStorage;
    }

    public void Create(T obj)
    {
        _objStorage.Save(obj);
    }

    public IEnumerable<T> GetAll()
    {
        return _objStorage.FetchAll();
    }

    public T GetById(Guid id)
    {
        return _objStorage.Fetch(id);
    }
}