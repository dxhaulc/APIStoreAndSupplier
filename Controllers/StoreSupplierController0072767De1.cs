using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DaoXuanHau0072767.DbContexts;
using DaoXuanHau0072767.Dto;
using DaoXuanHau0072767.Dto.Common;
using DaoXuanHau0072767.Dto.StoreSuppliers;
using DaoXuanHau0072767.Entity;
using DaoXuanHau0072767.Services.Abstract;
using DaoXuanHau0072767.Services.Implements;

namespace DaoXuanHau0072767.Controllers
{
    [Route("api/storeSupplier")]
    [ApiController]
    public class StoreSupplierController0072767De1 : ControllerBase
    {
        private readonly IStoreSupplierService0072767De1 _storeSupplierService;
        private readonly ApplicationDbContext _dbContext;

        public StoreSupplierController0072767De1(IStoreSupplierService0072767De1 storeSupplierService, ApplicationDbContext dbContext)
        {
            _storeSupplierService = storeSupplierService;
            _dbContext = dbContext;
        }

        [HttpPost("create")]
        public IActionResult CreateStoreSupplier(CreateStoreSupplierDto0072767De1 input) //tại sao request body lại binding vào hàm này được ?
        {
            try
            {
                var storeSupplier = _storeSupplierService.CreateStoreSupplier(input);
                return Ok(storeSupplier); //http status code 200
            }
            catch (DbUpdateException ex)
            {
                // Các lỗi DB khác (ví dụ: constraint khác)
                return StatusCode(500, "Lỗi khi tạo dữ liệu do chưa tồn tại Id cửa hàng hoặc Id nhà cung cấp.");
            }
        }

        [HttpGet("get-all-list")]
        public IActionResult GetStoreSuppliers()
        {
            return Ok(_storeSupplierService.GetAll());
        }

        [HttpGet("get-all")]
        public IActionResult GetStoreSuppliers2([FromQuery] FilterDto0072767De1 input)
        {
            try
            {
                return Ok(_storeSupplierService.GetAll(input));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse0072767De1
                {
                    Message = ex.Message
                });
            }
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_storeSupplierService.FindStoreSupplierById(id));
        }

        [HttpPut("update")]
        public IActionResult UpdateStoreSupplier(UpdateStoreSupplierDto0072767De1 input)
        {
            try
            {
                _storeSupplierService.UpdateStoreSupplier(input);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                // Các lỗi DB khác (ví dụ: constraint khác)
                return StatusCode(500, "Lỗi khi cập nhật dữ liệu do chưa tồn tại Id cửa hàng hoặc Id nhà cung cấp.");
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStoreSupplier(int id)
        {
            _storeSupplierService.DeleteStoreSupplier(id);
            return Ok();
        }
    }
}
