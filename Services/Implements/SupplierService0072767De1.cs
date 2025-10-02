using DaoXuanHau0072767.DbContexts;
using DaoXuanHau0072767.Dto.Common;
using DaoXuanHau0072767.Dto.Suppliers;
using DaoXuanHau0072767.Entity;
using DaoXuanHau0072767.Exceptions;
using DaoXuanHau0072767.Services.Abstract;

namespace DaoXuanHau0072767.Services.Implements
{
    public class SupplierService0072767De1 : SupplierBaseService0072767De1, ISupplierService0072767De1
    {
        public SupplierService0072767De1(ApplicationDbContext dbContext)
            : base(dbContext) { }

        public SupplierDto0072767De1 CreateSupplier(CreateSupplierDto0072767De1 input)
        {
            var supplier = new Supplier0072767De1
            {
                //Id = ++_dbContext.SupplierId,
                Name = input.Name,
                Address = input.Address,
                PhoneNumber = input.PhoneNumber,
                //IsDeleted = false,
            };
            _dbContext.Suppliers.Add(supplier);
            _dbContext.SaveChanges();
            return new SupplierDto0072767De1
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = input.Address,
                PhoneNumber = input.PhoneNumber,
            };
        }

        public List<SupplierDto0072767De1> GetAll()
        {
            var result = _dbContext.Suppliers.Select(s => new SupplierDto0072767De1
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
            });
            return result.ToList();
        }

        public PageResultDto0072767De1<SupplierDto0072767De1> GetAll(FilterDto0072767De1 input)
        {
            var result = new PageResultDto0072767De1<SupplierDto0072767De1>();
            var query = _dbContext.Suppliers.Where(e =>
                input.Keyword == null
                || e.Name.ToLower().Contains(input.Keyword.ToLower())
            );

            result.TotalItem = query.Count();
            query = query
                .OrderByDescending(s => s.PhoneNumber) //sắp xếp theo ngày sinh giảm dần và id giảm dần
                .ThenByDescending(s => s.Id)
                .Skip(input.Skip())
                .Take(input.PageSize);

            result.Items = query
                .Select(s => new SupplierDto0072767De1
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    PhoneNumber = s.PhoneNumber,
                })
                .ToList();
            return result;
        }

        public void UpdateSupplier(UpdateSupplierDto0072767De1 input)
        {
            var supplierFind = FindSupplierById(input.Id);
            supplierFind.Name = input.Name;
            supplierFind.Address = input.Address;
            supplierFind.PhoneNumber = input.PhoneNumber;

            _dbContext.SaveChanges();
        }

        public void DeleteSupplier(int id)
        {
            var supplierFind = FindSupplierById(id);
            _dbContext.Suppliers.Remove(supplierFind);
            _dbContext.SaveChanges();
        }
    }
}
