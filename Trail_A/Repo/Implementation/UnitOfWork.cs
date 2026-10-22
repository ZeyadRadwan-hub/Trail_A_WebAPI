using JobPortal.Data;
using JobPortal.Repo.Contract;
using Trail_A.Models;

namespace JobPortal.Repo.Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly App_Database_Context _db;

        

        public UnitOfWork(App_Database_Context db, IGenericRepo<User> user, IGenericRepo<Application> application, IGenericRepo<CandidateProfile> candidateProfile, IGenericRepo<Company> company, IGenericRepo<Job> job,IAuthRepo authRepo,IJob customJob,
        ICompany customCompany)
        {
            _db = db;
            User = user;
            Application = application;
            CandidateProfile = candidateProfile;
            Company = company;
            Job = job;
            CustomAuth = authRepo;
            CustomJob = customJob;
            CustomCompany = customCompany;
        }

        public IGenericRepo<User> User { get; }
        public IGenericRepo<Application> Application { get; }
        public IGenericRepo<CandidateProfile> CandidateProfile { get; }
        public IGenericRepo<Company> Company { get; }
        public IGenericRepo<Job> Job { get; }
        public IAuthRepo CustomAuth { get; }
        public IJob CustomJob { get; }
        public ICompany CustomCompany { get; }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
