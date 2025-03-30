using Microsoft.EntityFrameworkCore;
using MotelManagement.Core.IRepository;
using MotelManagement.Data.Models;

namespace MotelManagement.Core.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MotelManagementContext context) : base(context)
        {
        }
        public async Task<List<Employee>> GetListEmployee(int pageindex, int pageSize)
        {
           return await _context.Employees
                                .OrderBy(e => e.MaNhanVien)
                                .Skip((pageindex-1) *pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        }

        public async Task<List<Employee>> SearchQuery(string query)
        {
            return await _context.Employees
                                 .Where(e=> e.HoTen.Contains(query) ||
                                            e.Sdt.Contains(query) || 
                                            e.Email.Contains(query)).ToListAsync();
        }
    }
}
