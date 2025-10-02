using DaoXuanHau0072767.Dto.Common;
using DaoXuanHau0072767.Dto.Stores;
using DaoXuanHau0072767.Dto.Suppliers;
using DaoXuanHau0072767.Entity;


namespace DaoXuanHau0072767.Services.Abstract
{
    public interface IStoreService0072767De1
    {
        StoreDto0072767De1 CreateStore(CreateStoreDto0072767De1 input);

        void UpdateStore(UpdateStoreDto0072767De1 input);

        List<StoreDto0072767De1> GetAll();

        void DeleteStore(int id);
        PageResultDto0072767De1<StoreDto0072767De1> GetAll(FilterDto0072767De1 input);

        public Store0072767De1 FindStoreById(int storeId);

        public List<SupplierWithIntimateDto0072767De1> GetTopIntimateSuppliers(int storeId, int topN);

    }
}
