using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }
        [HttpPost] 
        public async Task<IActionResult>AddBooking(CreateBookingDto model) {
            model.Status = "Onay Bekliyor";
          var client=_httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(model);   
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5231/api/Booking", stringContent);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Booking");
            }
            
            return View(model);
        }
    }
}
/* var client=_httpClientFactory.CreateClient();
           var response = await client.GetAsync("http://localhost:5231/api/Booking");
           if(response.IsSuccessStatusCode)
           {
               var jsonData=await response.Content.ReadAsStringAsync();
               var values=JsonConvert.DeserializeObject<string>(jsonData);
               return View(values);
           }

           return View();*/