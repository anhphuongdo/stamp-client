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
        [Display(Name = "Offline Voting ID")]
        public int ProofId { get; set; }
        [ForeignKey("ProofId")]
        public Proof? Proof { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public OfflineVoting() { }
        public OfflineVoting(int voteId, int productId, Product? product, bool isDeleted, int proofId, Proof? proof)
        {
            VoteId = voteId;
            ProductId = productId;
            Product = product;
            IsDeleted = isDeleted;
            ProofId = proofId;
            Proof = proof;
        }
    }
}
