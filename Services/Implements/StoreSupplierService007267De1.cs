using DaoXuanHau0072767.DbContexts;
using DaoXuanHau0072767.Dto.Common;
using DaoXuanHau0072767.Dto.StoreSuppliers;
using DaoXuanHau0072767.Entity;
using DaoXuanHau0072767.Exceptions;
using DaoXuanHau0072767.Services.Abstract;

namespace DaoXuanHau0072767.Services.Implements
{
    public class StoreSupplierService0072767De1 : StoreSupplierBaseService0072767De1, IStoreSupplierService0072767De1
    {
        public StoreSupplierService0072767De1(ApplicationDbContext dbContext)
            : base(dbContext) { }

        public StoreSupplierDto0072767De1 CreateStoreSupplier(CreateStoreSupplierDto0072767De1 input)
        {
            var storeSupplier = new StoreSupplier0072767De1
            {
                //Id = ++_dbContext.StoreSupplierId,
                StoreId = input.StoreId,
                SupplierId = input.SupplierId,
                Intimate = input.Intimate,
                //IsDeleted = false,
            };
            _dbContext.StoreSuppliers.Add(storeSupplier);
            _dbContext.SaveChanges();
            return new StoreSupplierDto0072767De1
            {
                Id = storeSupplier.Id,
                StoreId = storeSupplier.StoreId,
                SupplierId = input.SupplierId,
                Intimate = storeSupplier.Intimate,
            };
        }

        public List<StoreSupplierDto0072767De1> GetAll()
        {
            var result = _dbContext.StoreSuppliers.Select(s => new StoreSupplierDto0072767De1
            {
                Id = s.Id,
                StoreId = s.StoreId,
                SupplierId = s.SupplierId,
                Intimate = s.Intimate,
            });
            return result.ToList();
        }

        public PageResultDto0072767De1<StoreSupplierDto0072767De1> GetAll(FilterDto0072767De1 input)
        {
            var result = new PageResultDto0072767De1<StoreSupplierDto0072767De1>();
            var query = _dbContext.StoreSuppliers.Where(e =>
                input.Keyword == null
                // || e.Name.ToLower().Contains(input.Keyword.ToLower()
                || e.Id.ToString().ToLower().Contains(input.Keyword.ToLower())
            );

            result.TotalItem = query.Count();
            query = query
                // .OrderByDescending(s => s.OpenTime) //sắp xếp theo ngày sinh giảm dần và id giảm dần
                // .ThenByDescending(s => s.Id)
                .OrderByDescending(s => s.Id)
                .Skip(input.Skip())
                .Take(input.PageSize);

            result.Items = query
                .Select(s => new StoreSupplierDto0072767De1
                {
                    Id = s.Id,
                    StoreId = s.StoreId,
                    SupplierId = s.SupplierId,
                    Intimate = s.Intimate,
                })
                .ToList();
            return result;
        }

        public void UpdateStoreSupplier(UpdateStoreSupplierDto0072767De1 input)
        {
            var storeSupplierFind = FindStoreSupplierById(input.Id);
            storeSupplierFind.StoreId = input.StoreId;
            storeSupplierFind.SupplierId = input.SupplierId;
            storeSupplierFind.Intimate = input.Intimate;

            _dbContext.SaveChanges();
        }

        public void DeleteStoreSupplier(int id)
        {
            var storeSupplierFind = FindStoreSupplierById(id);
            _dbContext.StoreSuppliers.Remove(storeSupplierFind);
            _dbContext.SaveChanges();
        }
    }
}
