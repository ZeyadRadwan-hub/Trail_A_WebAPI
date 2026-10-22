using Trail_A.Models;

namespace JobPortal.Repo.Contract
{
    public interface IUnitOfWork
    {
        IGenericRepo<User> User { get; }
        IGenericRepo<Application> Application { get; }
        IGenericRepo<CandidateProfile> CandidateProfile { get; }
        IGenericRepo<Company> Company { get; }
        IGenericRepo<Job> Job { get; }
        IAuthRepo CustomAuth {  get; }
        IJob CustomJob { get; }
        ICompany CustomCompany { get; }

        Task<int> SaveAsync();
    }
}
