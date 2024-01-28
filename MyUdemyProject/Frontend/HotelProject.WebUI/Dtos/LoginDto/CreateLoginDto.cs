using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class CreateLoginDto
    {
        [Required(ErrorMessage ="lütfen kullanıcı adınızı giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "lütfen şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
