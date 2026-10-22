using JobPortal.Data;
using JobPortal.Repo.Contract;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repo.Implementation
{
    public class GenreicRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly App_Database_Context _db;

        public GenreicRepo(App_Database_Context db)
        {
            _db = db;
        }

        public async Task Create(T obj)
        {
           await _db.Set<T>().AddAsync(obj);
        }

        public void Delete(int id)
        {
            var get = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(get);
        }

        public async Task<List<T>> GetAll()
        {
            var get = await _db.Set<T>().ToListAsync();
            return get;
        }

        public async Task<T> GetById(int id)
        {
            var get = await _db.Set<T>().FindAsync(id);
            if (get == null)
                return null;
            return get;
        }

        public void Update(T obj)
        {
            _db.Set<T>().Update(obj);
        }
    }
}
