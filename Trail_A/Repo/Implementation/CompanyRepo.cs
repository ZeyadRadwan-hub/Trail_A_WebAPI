using JobPortal.Data;
using JobPortal.Repo.Contract;
using Microsoft.EntityFrameworkCore;
using Trail_A.Models;

namespace JobPortal.Repo.Implementation
{
    public class CompanyRepo:ICompany
    {
        private readonly App_Database_Context _db;

        public CompanyRepo(App_Database_Context db)
        {
            _db = db;
        }

        public async Task<Company> GetGreatest()
        {
            var get = await _db.Companies
                .Include(x=>x.Jobs).FirstOrDefaultAsync();
            return get;
        }
    }
}
