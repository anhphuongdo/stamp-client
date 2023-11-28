using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_STAMP.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Display(Name = "Product name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not null")]
        public string ProductName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not null")]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Product Image")]
        [BindNever]
        public byte[]? ImageUrl { get; set; }

        [Display(Name = "Product SourceFile")]
        public byte[]? ProductFile { get; set; }


        [Display(Name = "Product Video")]
        public string? VideoUrl { get; set; }

        public bool? IsPublished { get; set; }

        public int VoteAmount { get; set; } = 0;

        [Required]
        public bool IsDeleted { get; set; } = false;
        public Product() { }

        public Product(int productId, string productName, string productDescription, byte[]? imageUrl, byte[]? productFile, string videoUrl, bool? isPublished, bool isDeleted)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            this.ImageUrl = imageUrl;
            this.ProductFile = productFile;
            this.VideoUrl = videoUrl;
            this.IsPublished = isPublished;
            this.IsDeleted = isDeleted;
        }
    }
}
