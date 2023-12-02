using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_STAMP.Models
{
    [Table("Talkshow")]
    public class Talkshow
    {
        [Key]
        public int TalkshowId { get; set; }

        [Required]
        public string UserId { get; set; }
        [Display(Name = "Attendees")]
        [ForeignKey("UserId")]
        public Us? User { get; set; }

        [Display(Name = "Confirm")]
        public bool? IsConfirm { get; set; } = false;

        [Display(Name = "Check in")]
        public bool? IsCheckIn { get; set; } = false;

        [Required]
        public bool IsDeleted { get; set; } = false;
        public Talkshow() { }
        public Talkshow(int TalkshowId, string userID, Us user, bool? isConfirm, bool isCheckIn, bool isDeleted)
        {
            this.TalkshowId = TalkshowId;
            this.UserId = userID;
            this.User = user;
            this.IsConfirm = isConfirm;
            this.IsDeleted = isDeleted;
            this.IsCheckIn = isCheckIn;
        }
    }
}
