using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
    public class AdminFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream=new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes=stream.ToArray();
            ByteArrayContent content = new ByteArrayContent(bytes);
            content.Headers.ContentType =new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent contentFormData = new MultipartFormDataContent();
            contentFormData.Add(content,"file",file.FileName );
            var httpClient=new HttpClient();
            var responseMessage = await httpClient.PostAsync("http://localhost:5231/api/FileImage", contentFormData);
            if(responseMessage.IsSuccessStatusCode == true )
            {
                return View(responseMessage);
            }
            return View();
        }
    }
}
