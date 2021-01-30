using System.ComponentModel.DataAnnotations;

namespace BlogLab.Models.Blog
{
    public class BlogCreate
    {
        public int BlogId { get; set; }
        [Required(ErrorMessage = "Başlık gereklidir")]
        [MinLength(10, ErrorMessage = "10-30 karakter arasında olmalıdır")]
        [MaxLength(30, ErrorMessage = "10-30 karakter arasında olmalıdır")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Başlık gereklidir")]
        [MinLength(100, ErrorMessage = "100-3000 karakter arasında olmalıdır")]
        [MaxLength(3000, ErrorMessage = "100-3000 karakter arasında olmalıdır")]
        public string Content { get; set; }
        public int? PhotoId { get; set; }



    }
}
