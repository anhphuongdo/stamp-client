using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_STAMP.Models
{
    public class Proof
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProofId { get; set; }

        [Required]
        [Display(Name = "Offline Voting ID")]
        public int VoteId { get; set; }
        [ForeignKey("VoteId")]
        public OfflineVoting? OfflineVoting { get; set; }

        [Display(Name = "Like Fanpage Image")]
        [BindNever]
        public byte[]? FanpageImg { get; set; }

        [Display(Name = " Up Story Image")]
        [BindNever]
        public byte[]? StoryImg { get; set; }

        public Proof() { }
        public Proof(int proofId, int voteId, OfflineVoting? offlineVoting, byte[]? fanpageImg, byte[]? storyImg)
        {
            ProofId = proofId;
            VoteId = voteId;
            OfflineVoting = offlineVoting;
            FanpageImg = fanpageImg;
            StoryImg = storyImg;
        }
    }
}
