using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotelManagement.Business.IService;
using MotelManagement.Common;
using MotelManagement.Data.Models;

namespace MotelManagement.Pages.admin
{
    public class EmployeeListModel : PageModel
    {

        private readonly IEmployeeService _employeeService;
        
        public EmployeeListModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task OnGetAsync(int pageIndex = 1, int pageSize = 5)
        {

            int totalEmployees = _employeeService.CountEmployee();
            List<Employee> employees = await _employeeService.getlistemployee(pageIndex, pageSize);

            ViewData["employees"] = employees;
            ViewData["pageIndex"] = pageIndex;
            ViewData["totalPage"] = (int)Math.Ceiling((double)totalEmployees / pageSize);

        }
    }
}
