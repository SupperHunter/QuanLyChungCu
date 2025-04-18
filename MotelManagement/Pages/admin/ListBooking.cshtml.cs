﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotelManagement.Business.IService;
using MotelManagement.Data.Models;

namespace MotelManagement.Pages.admin
{
    public class ListBookingModel : PageModel
    {
        private readonly IBookingService _bookingService;
        public List<Booking> bookings { get; set; }
        public ListBookingModel(IBookingService booking)
        {
            _bookingService = booking;
        }
        public async Task<IActionResult> OnGetAsync(int? roomId, string? nameBooking, string? emailBooking, string? phoneBooking, string? fromBooking, string? toBooking)
        {            bookings  = await _bookingService.BookingsAvailableSearching(roomId,nameBooking,emailBooking,phoneBooking,fromBooking,toBooking);
            bool isRoomRented = await _bookingService.isRoomRented(roomId);
            ViewData["isRoomRented"] = isRoomRented;
            ViewData["roomId"] = roomId;
            ViewData["nameBooking"] = nameBooking;
            ViewData["emailBooking"] = emailBooking;
            ViewData["phoneBooking"] = phoneBooking; 
            ViewData["fromBooking"] = fromBooking;
            ViewData["toBooking"] = toBooking; 

            return Page(); 
        }
        public async Task<IActionResult> OnPostAllUserAsync(DateTime? meetingdate, int? roomId)
        {
             await _bookingService.UpdateMeetingDateAllUser(meetingdate, roomId);
            return Redirect("/admin/room/booking/list?roomId=" + roomId);
        }
        public async Task<IActionResult> OnGetChangeMeetingAsync(DateTime? meetingDate, int? bookingId, int? roomId)
        {
            await _bookingService.UpdateMeetingForUser(meetingDate, bookingId, roomId);
            return Redirect("/admin/room/booking/list?roomId=" + roomId);
        }
        // Set User to be Member 
        public async Task<IActionResult> OnGetSetMemberToRoomAsync(int roomId, int userId, decimal price, int bookingId)
        {
            // set member to room
            await _bookingService.SetUserBeMember(userId, roomId, price,bookingId); 
            return Redirect("/admin/room/booking/list?roomId=" + roomId);
        }
    }
}
