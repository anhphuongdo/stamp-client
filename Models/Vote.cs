using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_STAMP.Models
{
    [Table("Vote")]
    public class Vote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Vote ID")]
        public int VoteId { get; set; }

        [Required]
        [Display(Name = "Product ID")]

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? Usr { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public Vote() { }
        public Vote(int Voteid, int productId, Product product, string userId, IdentityUser Usr, bool isDeleted)
        {
            this.VoteId = Voteid;
            this.ProductId = productId;
            this.UserId = userId;
            this.Product = product;
            this.Usr = Usr;
            this.IsDeleted = isDeleted;
        }
    }
}
