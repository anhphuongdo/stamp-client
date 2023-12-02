using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_STAMP.Models
{
    [Table("User")]
    public class Us : IdentityUser
    {
        [Required]
        [Display(Name = "Số thứ tự")]
        public int STT { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Họ và Tên không được để trống")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "MSSV không được để trống")]
        [Display(Name = "MSSV")]
        public string UsMssv { get; set; }

        [Display(Name = "School ID")]
        public int SchoolId { get; set; }
        [Display(Name = "School")]
        [ForeignKey("SchoolId")]
        public School? School { get; set; }

        [Display(Name = "User Image")]
        public byte[]? UsImgUrl { get; set; }

        public List<UserGroupRelationship>? Relationship { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
        public Us() { }
        public Us(string fullname, string mssv, int schoolId, School School, byte[]? imgUrl, List<UserGroupRelationship> relationship, bool isDeleted)
        {
            FullName = fullname;
            this.UsMssv = mssv;
            this.SchoolId = schoolId;
            this.School = School;
            this.Relationship = relationship;
            this.UsImgUrl = imgUrl;
            this.IsDeleted = isDeleted;
        }
              
    }
}
