using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DaoXuanHau0072767.DbContexts;
using DaoXuanHau0072767.Dto;
using DaoXuanHau0072767.Dto.Common;
using DaoXuanHau0072767.Dto.Stores;
using DaoXuanHau0072767.Entity;
using DaoXuanHau0072767.Services.Abstract;
using DaoXuanHau0072767.Services.Implements;

namespace DaoXuanHau0072767.Controllers
{
    [Route("api/store")]
    [ApiController]
    public class StoreController0072767De1 : ControllerBase
    {
        private readonly IStoreService0072767De1 _storeService;
        private readonly ApplicationDbContext _dbContext;

        public StoreController0072767De1(IStoreService0072767De1 storeService, ApplicationDbContext dbContext)
        {
            _storeService = storeService;
            _dbContext = dbContext;
        }

        [HttpPost("create")]
        public IActionResult CreateStore(CreateStoreDto0072767De1 input) //tại sao request body lại binding vào hàm này được ?
        {
            try
            {
                var store = _storeService.CreateStore(input);
                return Ok(store); //http status code 200
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("IX_Store0072767De1_Name") == true)
                {
                    return BadRequest("Tên cửa hàng đã tồn tại.");
                }

                // Các lỗi DB khác (ví dụ: constraint khác)
                return StatusCode(500, "Lỗi khi tạo dữ liệu.");
            }
        }

        [HttpGet("get-all-list")]
        public IActionResult GetStores()
        {
            return Ok(_storeService.GetAll());
        }

        [HttpGet("get-all")]
        public IActionResult GetStores2([FromQuery] FilterDto0072767De1 input)
        {
            try
            {
                return Ok(_storeService.GetAll(input));
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
            return Ok(_storeService.FindStoreById(id));
        }

        [HttpPut("update")]
        public IActionResult UpdateStore(UpdateStoreDto0072767De1 input)
        {
            try
            {
                _storeService.UpdateStore(input);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("IX_Store0072767De1_Name") == true)
                {
                    return BadRequest("Tên cửa hàng đã tồn tại.");
                }

                // Các lỗi DB khác (ví dụ: constraint khác)
                return StatusCode(500, "Lỗi khi cập nhật dữ liệu.");
            }
            // catch (Exception ex)
            // {
            //     return BadRequest(new ApiResponse
            //     {
            //         Message = ex.Message
            //     });
            // }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStore(int id)
        {
            _storeService.DeleteStore(id);
            return Ok();
        }

        [HttpGet("{storeId}/top-suppliers")]
        public IActionResult GetTopIntimateSuppliers(int storeId)
        {
            var result = _storeService.GetTopIntimateSuppliers(storeId, 1);
            return Ok(result);
        }

    }
}
