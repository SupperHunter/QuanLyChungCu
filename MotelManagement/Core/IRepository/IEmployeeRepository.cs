using MotelManagement.Data.Models;

namespace MotelManagement.Core.IRepository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        public Task<List<Employee>> GetListEmployee(int pageindex , int pageSize);

        public Task<List<Employee>> SearchQuery(string query);
    }
}
