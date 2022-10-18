using RAS.Bootcamp.API.net.Datas.Entities;
namespace RAS.Bootcamp.API.net.Datas.Entities;

public class Repository<T> : IRepository<T> where T:class{
    protected readonly dbmarketContext _dbcontext;

    public Repository(dbmarketContext dbcontext){
        _dbcontext = dbcontext;
    }
    public T Get(int id){
        return _dbcontext.Find<T>(id);
    }
    public IEnumerable<T> GetList(){
        return _dbcontext.Set<T>().ToList();

    }
    public void Add(T newData){
        _dbcontext.Add(newData);
        _dbcontext.SaveChanges();
    }
    public void Update(T data) {
        _dbcontext.Update<T>(data);
        _dbcontext.SaveChanges();
    }
    public void Remove(int id){
        var data = _dbcontext.Find<T>(id);
        if (data == null){
            return;
        }
        _dbcontext.Remove<T>(data);
        _dbcontext.SaveChanges();

    }
    public void RemoveRange(IEnumerable<T> datas){
        _dbcontext.RemoveRange(datas);
    }

}