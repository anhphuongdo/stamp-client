using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_STAMP.Models
{
    [Table("UserGroupRelationship")]

    public class UserGroupRelationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public Us? us { get; set; }

        [Required]
        public int GroupId { get; set; }
        [Required]
        [ForeignKey("GroupId")]
        public GroupUser? GroupUser { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public UserGroupRelationship() { }

        public UserGroupRelationship(int id, string userId, int groupId, GroupUser gr, bool isDeleted)
        {
            this.Id = id;
            this.UserId = userId;
            this.GroupId = groupId;
            this.GroupUser = gr;
            this.IsDeleted = isDeleted;
        }

    }
}
