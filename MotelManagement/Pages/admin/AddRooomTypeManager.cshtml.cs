using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotelManagement.Business.IService;
using MotelManagement.Data.Models;

namespace MotelManagement.Pages.admin
{
    public class AddRooomTypeManagerModel : PageModel
    {
        private readonly IRoomTypeService _service;

        public AddRooomTypeManagerModel(IRoomTypeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAddnewRoomTypeAsync(RoomType roomtype)
        {
            if (roomtype == null)
            {
                TempData["Message"] = "Chưa nhập đủ dữ liệu";
            }
            try
            {
                 await _service.addnewrooomtype(roomtype);
                TempData["Message"] = "Thêm thành công"; 
                return Redirect("/admin/room/list");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Thêm thất bại";
                throw;
            }
        }
        public void OnGet()
        {
        }
    }
}
