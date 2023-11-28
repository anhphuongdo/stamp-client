using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_STAMP.Models
{
    [Table("School")]
    public class School
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "School ID")]
        public int SchoolId { get; set; }

        [Required]
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public School() { }
        public School(int schoolId, string schoolName, bool isDeleted)
        {
            this.SchoolId = schoolId;
            this.SchoolName = schoolName;
            this.IsDeleted = isDeleted;
        }
    }
}
