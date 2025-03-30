using MotelManagement.Data.Models;

namespace MotelManagement.Business.IService
{
    public interface IEmployeeService
    {
        public Task AddNewEmployee(Employee employee);

        public Task<Employee> GetEmployeeById(int id);
        public Task<List<Employee>> getlistemployee(int pageindex= 1 , int pagesize = 5);

        public Task updateEmployee(Employee employee);
        public Task DeleteEmployee(int id);

        public int CountEmployee();
    }
}
