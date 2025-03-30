using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotelManagement.Business.IService;
using MotelManagement.Business.Service;
using MotelManagement.Common;
using MotelManagement.Data.Models;

namespace MotelManagement.Pages.admin
{
    public class UpdateRoomManagerModel : PageModel
    {

        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        public UpdateRoomManagerModel(IRoomService roomService, IRoomTypeService roomTypeService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
        }


        public async Task<IActionResult> OnPostUpdateRoomAsync(Room room)
        {
            int roomid = room.RoomId;
            await _roomService.updateRoom(room);
            return Redirect("/admin/room/list");
        }


        public async Task OnGetAsync(int? id)
        {
            List<RoomType> roomTypes = await _roomTypeService.GetAll();
            List<Status> statusList = new List<Status>();
            statusList.Add(new Status { StatusId = (int)ROOM_STATE.RENTED, Name = "Đã Thuê" });
            statusList.Add(new Status { StatusId = (int)ROOM_STATE.PROCESSING, Name = "Còn Trống" });
            statusList.Add(new Status { StatusId = (int)ROOM_STATE.PASSING, Name = "Muốn Pass" });
            ViewData["statusList"] = statusList;
            ViewData["roomTypes"] = roomTypes;

            if (id.HasValue && id > 0)
            {
                Room room = await _roomService.getRoomById(id.Value);
                if (room != null)
                {
                    ViewData["room"] = room;
                }
            }
        }
    }
}
