using System.ComponentModel.DataAnnotations;

namespace ChallengeApi.Models
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        public string Username { get; set; }

        [Required(ErrorMessage = "کلمه عبور الزامی است")]
        public string Password { get; set; }
    }
}
