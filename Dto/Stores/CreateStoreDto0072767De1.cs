using System.ComponentModel.DataAnnotations;

namespace DaoXuanHau0072767.Dto.Stores
{
    public class CreateStoreDto0072767De1
    {
        private string _name;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được bỏ trống")]
        //[StringLength(50, ErrorMessage = "Tên dài tối đa 50 ký tự")]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }

        private string _address;
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string Address
        {
            get => _address;
            set => _address = value?.Trim();
        }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }

        //[Range(double.Epsilon, 100)] //lấy bằng đoạn: từ số nhỏ nhất kiểu double lớn hơn 0 tới 100
        //public double Score { get; set; }
    }
}
