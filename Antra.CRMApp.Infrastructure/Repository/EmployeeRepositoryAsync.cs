using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Antra.CRMApp.Infrastructure.Repository
{
    public class EmployeeRepositoryAsync : BaseRepository<Employee>, IEmployeeRepositoryAsync
    {
        private readonly CrmDbContext _context;
        public EmployeeRepositoryAsync(CrmDbContext _dbContext) : base(_dbContext)
        {
            _context = _dbContext;
        }

        public async Task<IEnumerable<Employee>> GetByNameAsync(string name)
        {
            return await _context.Employee.Where(x => x.FirstName.Contains(name)).ToListAsync();
        }
    }
}
