namespace JobPortal.Repo.Contract
{
    public interface IGenericRepo<T> where T : class
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task Create(T obj);
        void Delete(int id);
        void Update(T obj);
    }
}
