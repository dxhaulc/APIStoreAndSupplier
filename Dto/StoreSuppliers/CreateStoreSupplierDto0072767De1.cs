using System.ComponentModel.DataAnnotations;

namespace DaoXuanHau0072767.Dto.StoreSuppliers
{
    public class CreateStoreSupplierDto0072767De1
    {

        [Required(ErrorMessage = "Id cửa hàng không được bỏ trống")]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Id nhà cung cấp không được bỏ trống")]
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "Độ thân mật không được bỏ trống")]
        public int Intimate { get; set; }


        //[Range(double.Epsilon, 100)] //lấy bằng đoạn: từ số nhỏ nhất kiểu double lớn hơn 0 tới 100
        //public double Score { get; set; }
    }
}
