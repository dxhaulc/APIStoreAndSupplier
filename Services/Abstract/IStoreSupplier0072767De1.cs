using DaoXuanHau0072767.Dto.Common;
using DaoXuanHau0072767.Dto.StoreSuppliers;
using DaoXuanHau0072767.Entity;


namespace DaoXuanHau0072767.Services.Abstract
{
    public interface IStoreSupplierService0072767De1
    {
        StoreSupplierDto0072767De1 CreateStoreSupplier(CreateStoreSupplierDto0072767De1 input);

        void UpdateStoreSupplier(UpdateStoreSupplierDto0072767De1 input);

        List<StoreSupplierDto0072767De1> GetAll();

        void DeleteStoreSupplier(int id);
        PageResultDto0072767De1<StoreSupplierDto0072767De1> GetAll(FilterDto0072767De1 input);

        public StoreSupplier0072767De1 FindStoreSupplierById(int storeSupplierId);

    }
}
