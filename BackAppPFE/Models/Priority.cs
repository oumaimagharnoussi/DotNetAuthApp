using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackAppPFE.Models
{
    [Table("Prioritys", Schema = "HR")]
    public class Priority
    {
        [Key]
        [Display(Name = "PriorityID")]
        public int PriorityId { get; set; }

        [Required]
        [Display(Name = "Priority Name")]
        [Column(TypeName = "varchar(200)")]
        public string PriorityName { get; set; } = string.Empty;
    }
}
