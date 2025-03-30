using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotelManagement.Business.IService;
using MotelManagement.Common;
using MotelManagement.Data.Models;
using System.Collections.Generic;

namespace MotelManagement.Pages
{
    public class ListRoomModel : PageModel
    {
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IContractService _contractService;

     //   Design : Hiện nút booking : 
     //   TH1 : room và user chưa nằm trong bảng booking
     //   TH2 : room và user nằm trong bảng booking nhưng trạng thái là status là 0 và không có trạng thái 1 (đã hủy booking trước đó ) 
        public bool isShowBooking(Room room, int userId)
        {
            if(room.Bookings == null)
               return true;
            else
            {
                Booking booking = room.Bookings.Where(b => b.UserId == userId && 
                                                           b.RoomId == room.RoomId && 
                                                           b.Status == (int)REGISTER_ROOM_STATE.REGISTER).FirstOrDefault();
                if (booking == null)
                    return true;
            }
            return false; 
        }
        public bool isShowCancelBooking(Room room, int userId)
        {
            if (room.Bookings == null)
                return false;
            Booking booking = room.Bookings.Where(b => b.UserId == userId &&
                                                           b.RoomId == room.RoomId &&
                                                           b.Status == (int)REGISTER_ROOM_STATE.REGISTER).FirstOrDefault();
            if (booking != null)
                return true;
            return false;
        }

        // Check nếu như là member của phòng này 
        public async Task<bool> isMemberOfRoom(Room room, int userId)
        {
            return await _contractService.isMemberOfRoom(room.RoomId, userId); 
        }

        public ListRoomModel(IRoomService roomService, IRoomTypeService roomTypeService, IContractService contractService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _contractService = contractService; 
        }
        public async Task<IActionResult> OnGetAsync(string nameRoom, int? roomTypeId, int? status, string price, string sizePerson, int pageIndex)
        {
            List<Status> statusList = new List<Status>();
            statusList.Add(new Status { StatusId = (int)ROOM_STATE.RENTED, Name = "Đã Thuê"} );
            statusList.Add(new Status { StatusId = (int)ROOM_STATE.PROCESSING, Name = "Còn Trống" });
            statusList.Add(new Status { StatusId = (int)ROOM_STATE.PASSING, Name = "Muốn Pass" });
            ViewData["statusList"] = statusList;
            List<RoomType> roomTypes = await _roomTypeService.GetAll();
            ViewData["roomTypes"] = roomTypes;
            if(pageIndex <= 0)
                pageIndex = 1;
            List<Room> rooms = await _roomService.advancedSearchRoomList(nameRoom, roomTypeId, status, price, sizePerson, pageIndex);
            int totalPage = await _roomService.totalPage(nameRoom, roomTypeId, status, price, sizePerson);
            List<Room> roomsRecommendeds = await _roomService.roomRecommended(); 
            string url = "List?";
            string url_param = Request.QueryString.ToString();
            if (url_param != null && url_param.Length > 0)
            {
                url = "List";
                if (url_param.EndsWith("pageIndex=" + pageIndex))
                {
                    url_param = url_param.Replace("pageIndex=" + pageIndex, "");
                }
                if (!url_param.Equals("") && !url_param.EndsWith("&") && !url_param.EndsWith("?"))
                {
                    url_param += "&";
                }
                url += (url_param);
            }
            ViewData["url"] = url;
            ViewData["totalPage"] = totalPage;
            ViewData["pageIndex"] = pageIndex;
            ViewData["rooms"] = rooms;
            ViewData["roomsRecommendeds"] = roomsRecommendeds;
            ViewData["nameRoom"] = nameRoom;
            ViewData["roomTypeId"] = roomTypeId;
            ViewData["status"] = status;
            ViewData["price"] = price;
            ViewData["sizePerson"] = sizePerson; 
            return Page();
        }
    }
}
