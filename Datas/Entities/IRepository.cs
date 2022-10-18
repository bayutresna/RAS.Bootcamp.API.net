namespace RAS.Bootcamp.API.net.Datas.Entities;

public interface IRepository<T> where T:class {
    T Get(int id);
    IEnumerable<T> GetList();
    void Add(T newData);
    void Update(T data);
    void Remove(int id);
    void RemoveRange(IEnumerable<T> datas);

}