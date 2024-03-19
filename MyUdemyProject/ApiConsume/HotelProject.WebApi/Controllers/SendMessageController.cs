using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService sendMessageService;


        public SendMessageController(ISendMessageService sendMessageService)
        {
            this.sendMessageService = sendMessageService;

        }
        [HttpGet]
        public IActionResult SendMessageList()
        {
            var entities = sendMessageService.TGetList();
            return Ok(entities);
        }
        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {

            sendMessageService.TInsert(sendMessage);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteSendMessage(int id)
        {
            var entity = sendMessageService.TGetByID(id);
            sendMessageService.TDelete(entity);
            return Ok();

        }
        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            sendMessageService.TUpdate(sendMessage);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var entity = sendMessageService.TGetByID(id);

            return Ok(entity);
        }
        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount(int id)
        {
            return Ok(sendMessageService.TGetSendMessageCount());
        }
    }
}
