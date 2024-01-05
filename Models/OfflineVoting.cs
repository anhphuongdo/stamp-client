using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BIT_STAMP.Models
{
    [Table("OfflineVoting")]
    public class OfflineVoting
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoteId { get; set;}
        [Required]
        [Display(Name = "Product ID")]

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public Us? User { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public OfflineVoting() { }
        public OfflineVoting(int voteId, int productId, Product? product, string userId, Us? user, bool isDeleted)
        {
            VoteId = voteId;
            ProductId = productId;
            Product = product;
            UserId = userId;
            User = user;
            IsDeleted = isDeleted;
        }
    }
}
