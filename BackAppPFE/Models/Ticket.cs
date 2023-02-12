using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackAppPFE.Models
{
    [Table("Tickets", Schema = "HR")]
    public class Ticket
    {
        [Key]
        [Display(Name = "ID")]
        public int TicketId { get; set; }

        [Required]
        [Display(Name = "Ticket Subject")]
        [Column(TypeName = "varchar(500)")]
        public string TicketSubject { get; set; } = string.Empty;

        [Display(Name = "Image")]
        [Column(TypeName = "varchar(200)")]
        public User?   Image { get; set; }

        [Display(Name = "DateCible")] [DataType(DataType.Date)]
        public DateTime  DateCible { get; set; }
        [ForeignKey("TypeId")]
        public Type? Type { get; set; }

        [ForeignKey("PriorityID")]
        public Priority? Priority { get; set; }

        [Required]
        [Display(Name = "Description")]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public Site site { get; set; }



       

    }
}
