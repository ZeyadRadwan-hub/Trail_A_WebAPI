using Trail_A.Models;

namespace JobPortal.Repo.Contract
{
    public interface IJob
    {
        Task<Job> GetThirdHighestSalary();
        Task<Job> GetById(int id);
        Task<List<Job>> Search(string Keyword);
    }
}
