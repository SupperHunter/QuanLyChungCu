using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotelManagement.Business.IService;
using MotelManagement.Data.Models;

namespace MotelManagement.Pages.admin
{
    public class AddEmployeeManagerModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        public AddEmployeeManagerModel(IEmployeeService service)
        {
            _employeeService = service;
        }

        public async Task<IActionResult> OnPostAddEmployeeAsync(Employee employee)
        {
            try
            {
               await _employeeService.AddNewEmployee(employee);
                TempData["Message"] = "Thêm thành công";
                return Redirect("/admin/employee/list");
            }
            catch (Exception ex)
            {
                return Page();
                throw;
            }
        }

        public async Task<IActionResult> OnPostUpdateEmployeeAsync(Employee employee)
        {
            try
            {
                await _employeeService.AddNewEmployee(employee);
                TempData["Message"] = "Thêm thành công";
                return Redirect("/admin/employee/list");
            }
            catch (Exception ex)
            {
                return Page();
                throw;
            }
        }

        public async Task OnGetAsync(int id)
        {
            Employee employee = await _employeeService.GetEmployeeById(id);
            if(employee != null)
            {
                ViewData["employee"] = employee;
            }
        }
    }
}
