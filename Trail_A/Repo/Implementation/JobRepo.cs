using JobPortal.Data;
using JobPortal.Repo.Contract;
using Microsoft.EntityFrameworkCore;
using Trail_A.Models;

namespace JobPortal.Repo.Implementation
{
    public class JobRepo:IJob
    {
        private readonly App_Database_Context _db;

        public JobRepo(App_Database_Context db)
        {
            _db = db;
        }

        public async Task<Job> GetById(int id)
        {
            var get = await _db.Jobs.Include(x=>x.Company).FirstOrDefaultAsync(x=>x.Id==id);
            return get;
        }

        public async Task<Job> GetThirdHighestSalary()
        {
            var get = await _db.Jobs
                .OrderByDescending(x => x.Salary)
                .Distinct()
                .Skip(2).FirstOrDefaultAsync();

            return get;
        }

        public async Task<List<Job>> Search(string Keyword)
        {
            var get = await _db.Jobs.Where(x => x.Description.Contains(Keyword) || x.Title.Contains(Keyword)).ToListAsync();
            return get;
        }
    }
}
