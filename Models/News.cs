using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_STAMP.Models
{
    [Table("News")]
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "News ID")]
        public int NewsId { get; set; }

        [Required]
        [Display(Name = "News Title")]
        public string Title { get; set; } = null!;

        [Required]
        [Display(Name = "News Short Description")]
        public string ShortDescription { get; set; } = null!;

        [Required]
        [Display(Name = "News Description")]
        public string Description { get; set; } = null!;

        [Display(Name = "News Image")]
        public byte[]? ImageUrl { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public News() { }
        public News(int id, string title, string shortDescription, string description, byte[] imageUrl, bool isDeleted)
        {
            this.NewsId = id;
            this.Title = title;
            this.ShortDescription = shortDescription;
            this.Description = description;
            /*this.ImageUrl = imageUrl;*/
            this.IsDeleted = isDeleted;
        }
    }
}
