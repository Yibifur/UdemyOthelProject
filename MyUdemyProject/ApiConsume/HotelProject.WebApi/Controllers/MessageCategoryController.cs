using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _MessageCategoryService;


        public MessageCategoryController(IMessageCategoryService MessageCategoryService)
        {
            _MessageCategoryService = MessageCategoryService;

        }
        [HttpGet]
        public IActionResult MessageCategoryList()
        {
            var entities = _MessageCategoryService.TGetList();
            return Ok(entities);
        }
        [HttpPost]
        public IActionResult AddMessageCategory(MessageCategory MessageCategory)
        {

            _MessageCategoryService.TInsert(MessageCategory);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteMessageCategory(int id)
        {
            var entity = _MessageCategoryService.TGetByID(id);
            _MessageCategoryService.TDelete(entity);
            return Ok();

        }
        [HttpPut]
        public IActionResult UpdateMessageCategory(MessageCategory MessageCategory)
        {
            _MessageCategoryService.TUpdate(MessageCategory);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetMessageCategory(int id)
        {
            var entity = _MessageCategoryService.TGetByID(id);

            return Ok(entity);
        }
    }
}
