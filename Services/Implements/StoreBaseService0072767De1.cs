using DaoXuanHau0072767.DbContexts;
using DaoXuanHau0072767.Entity;
using DaoXuanHau0072767.Exceptions;

namespace DaoXuanHau0072767.Services.Implements
{
    public class StoreBaseService0072767De1
    {
        protected readonly ApplicationDbContext _dbContext;

        public StoreBaseService0072767De1(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //các công việc chung cho quản lý sinh viên và lớp môn học

        //hàm tìm kiếm sinh viên theo id
        public Store0072767De1 FindStoreById(int storeId)
        {
            var storeFind = _dbContext.Stores.FirstOrDefault(s => s.Id == storeId && !s.IsDeleted);
            if (storeFind == null)
            {
                throw new UserFriendlyException0072767De1($"Không tìm thấy sinh viên có id {storeId}");
            }

            return storeFind;
        }
    }
}
