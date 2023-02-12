using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackAppPFE.Models
{
    [Table("Types",Schema = "HR")]
    public class Type
    {
        [Key]
        [Display(Name = "ID")]
        public int TypeId { get; set; }

        [Required]
        [Display(Name = "Type Name")]
        [Column(TypeName = "varchar(200)")]
        public string TypeName { get; set; } = string.Empty;

    }
}
