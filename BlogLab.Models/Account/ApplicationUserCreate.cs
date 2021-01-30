using System.ComponentModel.DataAnnotations;

namespace BlogLab.Models.Account
{
    public class ApplicationUserCreate : ApplicationUserLogin
    {

        [MinLength(10, ErrorMessage = "10-20 karakter arasında olmalıdır")]
        [MaxLength(20, ErrorMessage = "10-20 karakter arasında olmalıdır")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email Girmek Zorunludur")]
        [MaxLength(20, ErrorMessage = "Maksimum 20 karakter olmalıdır")]
        [EmailAddress(ErrorMessage = "Geçersiz email format")]
        public string Email { get; set; }

    }
}
