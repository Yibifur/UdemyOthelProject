using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var entities = _bookingService.TGetList();
            return Ok(entities);
        }
        [HttpPost]
        public IActionResult AddBooking(Booking Booking)
        {

            _bookingService.TInsert(Booking);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var entity = _bookingService.TGetByID(id);
            _bookingService.TDelete(entity);
            return Ok();
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking Booking)
        {
            _bookingService.TUpdate(Booking);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var entity = _bookingService.TGetByID(id);


            return Ok(entity);
        }
        [HttpPut("UpdateRezervation")]
        public IActionResult UpdateRezervation(Booking Booking)
        {
            _bookingService.TBookingStatusChangedApproved(Booking);
            return Ok();    
        }
        [HttpPut("UpdateRezervationForID")]
        public IActionResult UpdateRezervationForID(int id)
        {
            _bookingService.TBookingStatusChangedApproved2(id);
            return Ok();
        }

    }
}
