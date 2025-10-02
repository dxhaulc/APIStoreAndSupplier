using DaoXuanHau0072767.DbContexts;
using DaoXuanHau0072767.Entity;
using DaoXuanHau0072767.Exceptions;

namespace DaoXuanHau0072767.Services.Implements
{
    public class StoreSupplierBaseService0072767De1
    {
        protected readonly ApplicationDbContext _dbContext;

        public StoreSupplierBaseService0072767De1(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //các công việc chung cho quản lý sinh viên và lớp môn học

        //hàm tìm kiếm sinh viên theo id
        public StoreSupplier0072767De1 FindStoreSupplierById(int storeSupplierId)
        {
            var storeSupplierFind = _dbContext.StoreSuppliers.FirstOrDefault(s => s.Id == storeSupplierId);
            if (storeSupplierFind == null)
            {
                throw new UserFriendlyException0072767De1($"Không tìm thấy sinh viên có id {storeSupplierId}");
            }

            return storeSupplierFind;
        }
    }
}
