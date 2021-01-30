using System.ComponentModel.DataAnnotations;

namespace BlogLab.Models.Account
{
    public class ApplicationUserLogin
    {
        [Required(ErrorMessage = "Kullanıcı Adı Girmek Zorunludur")]
        [MinLength(5, ErrorMessage = "5-20 karakter arasında olmalıdır")]
        [MaxLength(20, ErrorMessage = "5-20 karakter arasında olmalıdır")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Girmek Zorunludur")]
        [MinLength(10, ErrorMessage = "10-20 karakter arasında olmalıdır")]
        [MaxLength(20, ErrorMessage = "10-20 karakter arasında olmalıdır")]
        public string Password { get; set; }


    }
}
