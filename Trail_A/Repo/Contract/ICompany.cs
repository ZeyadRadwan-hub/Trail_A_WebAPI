using Trail_A.Models;

namespace JobPortal.Repo.Contract
{
    public interface ICompany
    {
        Task<Company> GetGreatest();
    }
}
