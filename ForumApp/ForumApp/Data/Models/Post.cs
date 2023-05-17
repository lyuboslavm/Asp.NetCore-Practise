using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.DataConstants.Post;

namespace ForumApp.Data.Models
{
    public class Post
    {

        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLenght)]
        public string Content { get; set; } = null!;
    }
}
