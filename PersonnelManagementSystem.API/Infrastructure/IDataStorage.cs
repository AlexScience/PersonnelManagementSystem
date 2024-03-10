namespace PersonnelManagementSystem.API.Infrastructure;

public interface IDataStorage<T>
{
    public void Save(T obj);
    public T? Fetch(Guid id);
    public IEnumerable<T> FetchAll();
}