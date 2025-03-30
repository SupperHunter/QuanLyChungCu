using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotelManagement.Business.IService;
using MotelManagement.Data.Models;

namespace MotelManagement.Pages.admin
{
    public class ListPassingModel : PageModel
    {
        private readonly IPassingService _passingService; 
        public List<Passing> bookings { get; set; }
        public ListPassingModel(IPassingService passingService)
        {
            _passingService = passingService;   
        }
        public async Task<IActionResult> OnGetAsync(string? roomBooking, string? nameBooking, string? emailBooking, string? fromBooking, string? toBooking)
        {
            bookings =  await _passingService.PassingsWaitingSearching(roomBooking, nameBooking, emailBooking, fromBooking, toBooking);
            ViewData["nameBooking"] = nameBooking;
            ViewData["emailBooking"] = emailBooking;
            ViewData["roomBooking"] = roomBooking;
            ViewData["fromBooking"] = fromBooking;
            ViewData["toBooking"] = toBooking;

            return Page();
        }
        public async Task<IActionResult> OnGetSetMemberToRoomAsync(int roomId, int userId, decimal price, int bookingId)
        {
            await _passingService.SetUserBeMember(userId, roomId, price, bookingId);
            return Redirect("/admin/room/passing/list");
        }
        public async Task<IActionResult> OnGetRejectPassingAsync(int roomId, int userId, int bookingId)
        {
            await _passingService.RejectPassing(userId, roomId, bookingId);
            return Redirect("/admin/room/passing/list");
        }
    }
}
