using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoXuanHau0072767.Entity
{
    [Table("StoreSupplier0072767De1")]
    public class StoreSupplier0072767De1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int SupplierId { get; set; }
        public int Intimate { get; set; }
    }
}
