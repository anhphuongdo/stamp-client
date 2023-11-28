using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_STAMP.Models
{
    [Table("Group_User")]
    public class GroupUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Group ID")]
        public int GroupId { get; set; }

        [Required]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }

        [Display(Name = "List User")]
        public List<UserGroupRelationship>? Relationship { get; set; }

        [Required]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public GroupUser() { }

        public GroupUser(int groupId, int productId, List<UserGroupRelationship> relationship, Product product, bool isDeleted)
        {
            this.GroupId = groupId;
            this.Relationship = relationship;
            this.Product = product;
            this.IsDeleted = isDeleted;
            this.ProductId = productId;
        }
    }
}
