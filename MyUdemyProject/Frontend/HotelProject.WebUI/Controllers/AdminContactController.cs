using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult >Inbox()
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5231/api/Contact");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5231/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client2.GetAsync("http://localhost:5231/api/SendMessage/GetSendMessageCount");
            if (responseMessage3.IsSuccessStatusCode)
            {

                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();

                ViewBag.sendMessageCount = jsonData3;

            }
            if (responseMessage2.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage2.Content.ReadAsStringAsync();

                ViewBag.contactCount = jsonData;

            }
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData2);
                return View(values);
            }
          
            

            return View();
            
        }
        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5231/api/SendMessage");
           
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData2);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddSendMessage()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
        {
            model.SenderMail = "yibifur2002@gmail.com";
            model.SenderName = "Yiğit Birkan Furkan";
            model.Date= DateTime.Parse(DateTime.Now.ToShortDateString());
            
            var client= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage=await client.PostAsync("http://localhost:5231/api/SendMessage", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Sendbox");
            }
            return View();
        }
        public  PartialViewResult SideBarAdminContactPartial()
        {
           
            
            
        
            return PartialView();
        }
        public PartialViewResult SideBarAdminContactCategoriesPartial()
        {
            return PartialView();
        }
        
        public async Task< IActionResult> SendboxMessageDetail(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5231/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);
                return View(values);
            }
            
            return View();
        }
        public async Task<IActionResult> InboxMessageDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5231/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }

            return View();
        }
        
    }
}
