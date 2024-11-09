using System.ComponentModel.DataAnnotations;

namespace BGAPI.Models
{
    public class BlogPosts
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        [MaxLength(100)]
        public string Quote { get; set; }
    }
}
