using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _NewsletterPartial : ViewComponent
    {
        //Kursta burası _SubscribePartial diye geçiyo
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
