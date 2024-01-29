using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        

        public AboutController(IAboutService aboutService)   
        {
            _aboutService = aboutService;
           
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var entities = _aboutService.TGetList();
            return Ok(entities);
        }
        [HttpPost]
        public IActionResult AddAbout(About About)
        {

            _aboutService.TInsert(About);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var entity = _aboutService.TGetByID(id);
            _aboutService.TDelete(entity);
            return Ok();

        }
        [HttpPut]
        public IActionResult UpdateAbout(About About)
        {
            _aboutService.TUpdate(About);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var entity = _aboutService.TGetByID(id);

            return Ok(entity);
        }
    }
}
