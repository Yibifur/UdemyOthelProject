using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Net.Http.Headers;
namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult>Index(string cityName)
        {
            if(!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiLocationSearchViewModel> models = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={cityName}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "5e123ecab3mshdc58c05d1a5d02fp107c74jsn651c493645b7" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel>(body);
                    return View(values);
                }
            }
            else
            {
                List<BookingApiLocationSearchViewModel> models = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query=paris&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "5e123ecab3mshdc58c05d1a5d02fp107c74jsn651c493645b7" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel>(body);
                    return View(values);
                }
            }
          
           
        }
    }
}
