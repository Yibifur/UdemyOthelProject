using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class AdminRoomController : Controller
    {
        private IHttpClientFactory _httpClientFactory { get; set; }

        public AdminRoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

       /* public async Task< IActionResult> Index()
        {
            
        }*/
    }
}
