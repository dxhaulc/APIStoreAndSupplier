using DaoXuanHau0072767.DbContexts;
using DaoXuanHau0072767.Entity;
using DaoXuanHau0072767.Exceptions;

namespace DaoXuanHau0072767.Services.Implements
{
    public class SupplierBaseService0072767De1
    {
        protected readonly ApplicationDbContext _dbContext;

        public SupplierBaseService0072767De1(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //các công việc chung cho quản lý sinh viên và lớp môn học

        //hàm tìm kiếm sinh viên theo id
        public Supplier0072767De1 FindSupplierById(int supplierId)
        {
            var supplierFind = _dbContext.Suppliers.FirstOrDefault(s => s.Id == supplierId);
            if (supplierFind == null)
            {
                throw new UserFriendlyException0072767De1($"Không tìm thấy sinh viên có id {supplierId}");
            }

            return supplierFind;
        }
    }
}
