using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotelManagement.Business.IService;
using MotelManagement.Business.Service;
using MotelManagement.Common;
using MotelManagement.Data.Models;

namespace MotelManagement.Pages.admin
{
    public class AddRooomManagerModel : PageModel
    {
        private readonly IRoomService _service;
        private readonly IRoomTypeService _typeService;
        private readonly IImageService _imageService;

        public AddRooomManagerModel(IRoomService service , IRoomTypeService roomTypeService, IImageService imageService)
        {
            _service = service;
            _typeService = roomTypeService;
            _imageService = imageService;
        }


        public async Task OnGetAsync()
        {
            List<RoomType> roomTypes = await _typeService.GetAll();
            List<Status> statusList = new List<Status>();
            statusList.Add(new Status { StatusId = (int)ROOM_STATE.RENTED, Name = "Đã Thuê" });
            statusList.Add(new Status { StatusId = (int)ROOM_STATE.PROCESSING, Name = "Còn Trống" });
            statusList.Add(new Status { StatusId = (int)ROOM_STATE.PASSING, Name = "Muốn Pass" });
            ViewData["statusList"] = statusList;
            ViewData["roomTypes"] = roomTypes;
        }

        public async Task<IActionResult> OnPostAddnewRoomAsync(Room room , List<IFormFile> roomImages)
        {
            if (room == null)
            {
                TempData["Message"] = "Chưa nhập đủ dữ liệu!";
                return Page();
            }
            try
            {
                await _service.AddNewRoom(room);

                if (roomImages != null && roomImages.Count > 0)
                {
                    string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload");

                    // Tạo thư mục nếu chưa tồn tại
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Danh sách ảnh sẽ lưu vào database
                    List<Image> imagesToSave = new List<Image>();

                    foreach (var file in roomImages)
                    {
                        string fileName = $"{Guid.NewGuid()}_{file.FileName}";
                        string filePath = Path.Combine(uploadFolder, fileName);

                        // Lưu file vào thư mục upload
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // Thêm URL ảnh vào danh sách
                        imagesToSave.Add(new Image
                        {
                            RoomId = room.RoomId,
                            Url = fileName
                        });
                    }
                    await _imageService.addnewImage(imagesToSave);
                }



                TempData["Message"] = "Thêm thành công";
                return Redirect("/admin/room/list");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Thêm thất bại";
                return Page();
                throw;
            }
        }
    }
}
