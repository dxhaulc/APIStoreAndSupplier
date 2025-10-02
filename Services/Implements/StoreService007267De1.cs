using DaoXuanHau0072767.DbContexts;
using DaoXuanHau0072767.Dto.Common;
using DaoXuanHau0072767.Dto.Stores;
using DaoXuanHau0072767.Dto.Suppliers;
using DaoXuanHau0072767.Entity;
using DaoXuanHau0072767.Exceptions;
using DaoXuanHau0072767.Services.Abstract;

namespace DaoXuanHau0072767.Services.Implements
{
    public class StoreService0072767De1 : StoreBaseService0072767De1, IStoreService0072767De1
    {
        public StoreService0072767De1(ApplicationDbContext dbContext)
            : base(dbContext) { }

        public StoreDto0072767De1 CreateStore(CreateStoreDto0072767De1 input)
        {
            var store = new Store0072767De1
            {
                //Id = ++_dbContext.StoreId,
                Name = input.Name,
                Address = input.Address,
                OpenTime = input.OpenTime,
                CloseTime = input.CloseTime,
                //IsDeleted = false,
            };
            _dbContext.Stores.Add(store);
            _dbContext.SaveChanges();
            return new StoreDto0072767De1
            {
                Id = store.Id,
                Name = store.Name,
                Address = input.Address,
                OpenTime = input.OpenTime,
                CloseTime = input.CloseTime,
            };
        }

        public List<StoreDto0072767De1> GetAll()
        {
            var result = _dbContext.Stores.Select(s => new StoreDto0072767De1
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                OpenTime = s.OpenTime,
                CloseTime = s.CloseTime,
            });
            return result.ToList();
        }

        public PageResultDto0072767De1<StoreDto0072767De1> GetAll(FilterDto0072767De1 input)
        {
            var result = new PageResultDto0072767De1<StoreDto0072767De1>();
            var query = _dbContext.Stores.Where(e =>
                input.Keyword == null
                || e.Name.ToLower().Contains(input.Keyword.ToLower())
            );

            result.TotalItem = query.Count();
            query = query
                .OrderByDescending(s => s.OpenTime) //sắp xếp theo ngày sinh giảm dần và id giảm dần
                .ThenByDescending(s => s.Id)
                .Skip(input.Skip())
                .Take(input.PageSize);

            result.Items = query
                .Select(s => new StoreDto0072767De1
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    OpenTime = s.OpenTime,
                    CloseTime = s.CloseTime,
                })
                .ToList();
            return result;
        }

        public void UpdateStore(UpdateStoreDto0072767De1 input)
        {
            var storeFind = FindStoreById(input.Id);
            storeFind.Name = input.Name;
            storeFind.Address = input.Address;
            storeFind.OpenTime = input.OpenTime;
            storeFind.CloseTime = input.CloseTime;

            _dbContext.SaveChanges();
        }

        public void DeleteStore(int id)
        {
            var storeFind = FindStoreById(id);
            _dbContext.Stores.Remove(storeFind);
            _dbContext.SaveChanges();
        }

        public List<SupplierWithIntimateDto0072767De1> GetTopIntimateSuppliers(int storeId, int topN = 5)
        {
            var result = _dbContext.StoreSuppliers
                .Where(x => x.StoreId == storeId)
                .OrderByDescending(x => x.Intimate)
                .Take(topN)
                .Join(
                    _dbContext.Suppliers,
                    ss => ss.SupplierId,
                    s => s.Id,
                    (ss, s) => new SupplierWithIntimateDto0072767De1
                    {
                        Name = s.Name,
                        PhoneNumber = s.PhoneNumber,
                        Intimate = ss.Intimate
                    }
                )
                .ToList();

            return result;
        }
    }
}
