using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoXuanHau0072767.Entity
{
    [Table("Supplier0072767De1")]
    public class Supplier0072767De1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [Unicode]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Unicode]
        public string Address { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}
