using System.ComponentModel.DataAnnotations;

namespace BlogLab.Models.BlogComment
{
    public class BlogCommentCreate
    {
        public int BlogCommentId { get; set; }
        public int? ParentBlogCommentId { get; set; }
        public int BlogId { get; set; }
        [Required(ErrorMessage = "İçerik alanı gereklidir")]
        [MinLength(10, ErrorMessage = "10-300 karakter arasında olmaldıır")]
        [MaxLength(300, ErrorMessage = "10-300 karakter arasında olmaldıır")]
        public string Content { get; set; }


    }
}
