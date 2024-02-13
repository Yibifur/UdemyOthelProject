using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _GuestService;
        public GuestController(IGuestService GuestService)
        {
            _GuestService = GuestService;

        }
        [HttpGet]
        public IActionResult GuestList()
        {
            var entities = _GuestService.TGetList();
            return Ok(entities);
        }
        [HttpPost]
        public IActionResult AddGuest(Guest Guest)
        {

            _GuestService.TInsert(Guest);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteGuest(int id)
        {
            var entity = _GuestService.TGetByID(id);
            _GuestService.TDelete(entity);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateGuest(Guest Guest)
        {
            _GuestService.TUpdate(Guest);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var entity = _GuestService.TGetByID(id);


            return Ok(entity);
        }

    }
}
