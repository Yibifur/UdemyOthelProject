using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(createLoginDto.Username, createLoginDto.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Staff");
                }
                else
                {
                    return View();
                }
            }
            
           
            return View();
        }
    }
}
