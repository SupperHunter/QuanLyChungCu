using DocumentFormat.OpenXml.Office2010.Excel;
using MotelManagement.Business.IService;
using MotelManagement.Core.IRepository;
using MotelManagement.Data.Models;

namespace MotelManagement.Business.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewEmployee(Employee employee)
        {
            await _unitOfWork.employeeRepository.AddAsync(employee);
            await _unitOfWork.SaveAsync();
        }

        public int CountEmployee()
        {
            return _unitOfWork.employeeRepository.GetAll().Count();
        }

        public async Task DeleteEmployee(int id)
        {
            await _unitOfWork.employeeRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _unitOfWork.employeeRepository.GetByIdAsync(id);
        }


        public async Task<List<Employee>> getlistemployee(int pageindex = 1, int pagesize = 5)
        {
            return await _unitOfWork.employeeRepository.GetListEmployee(pageindex, pagesize);
        }

        public async Task updateEmployee(Employee employee)
        {
            await _unitOfWork.employeeRepository.UpdateAsync(employee);
        }
    }
}
