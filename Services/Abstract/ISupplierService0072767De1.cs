using DaoXuanHau0072767.Dto.Common;
using DaoXuanHau0072767.Dto.Suppliers;
using DaoXuanHau0072767.Entity;


namespace DaoXuanHau0072767.Services.Abstract
{
    public interface ISupplierService0072767De1
    {
        SupplierDto0072767De1 CreateSupplier(CreateSupplierDto0072767De1 input);

        void UpdateSupplier(UpdateSupplierDto0072767De1 input);

        List<SupplierDto0072767De1> GetAll();

        void DeleteSupplier(int id);
        PageResultDto0072767De1<SupplierDto0072767De1> GetAll(FilterDto0072767De1 input);

        public Supplier0072767De1 FindSupplierById(int supplierId);

    }
}
