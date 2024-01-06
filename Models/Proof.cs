using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_STAMP.Models
{
    public class Proof
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProofId { get; set; }

        [Display(Name = "Like Fanpage Image")]
        [BindNever]
        public byte[]? FanpageImg { get; set; }

        [Display(Name = " Up Story Image")]
        [BindNever]
        public byte[]? StoryImg { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public Us? User { get; set; }

        public Proof() { }
        public Proof(int proofId, byte[]? fanpageImg, byte[]? storyImg, string userId, Us? user)
        {
            ProofId = proofId;
            FanpageImg = fanpageImg;
            StoryImg = storyImg;
            UserId = userId;
            User = user;
        }
    }
}
