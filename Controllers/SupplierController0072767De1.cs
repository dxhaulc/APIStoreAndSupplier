using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DaoXuanHau0072767.DbContexts;
using DaoXuanHau0072767.Dto;
using DaoXuanHau0072767.Dto.Common;
using DaoXuanHau0072767.Dto.Suppliers;
using DaoXuanHau0072767.Entity;
using DaoXuanHau0072767.Services.Abstract;
using DaoXuanHau0072767.Services.Implements;

namespace DaoXuanHau0072767.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController0072767De1 : ControllerBase
    {
        private readonly ISupplierService0072767De1 _supplierService;
        private readonly ApplicationDbContext _dbContext;

        public SupplierController0072767De1(ISupplierService0072767De1 supplierService, ApplicationDbContext dbContext)
        {
            _supplierService = supplierService;
            _dbContext = dbContext;
        }

        [HttpPost("create")]
        public IActionResult CreateSupplier(CreateSupplierDto0072767De1 input) //tại sao request body lại binding vào hàm này được ?
        {
            try
            {
                var supplier = _supplierService.CreateSupplier(input);
                return Ok(supplier); //http status code 200
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("IX_Supplier0072767De1_Name") == true)
                {
                    return BadRequest("Tên nhà cung cấp đã tồn tại.");
                }

                // Các lỗi DB khác (ví dụ: constraint khác)
                return StatusCode(500, "Lỗi khi tạo dữ liệu.");
            }
        }

        [HttpGet("get-all-list")]
        public IActionResult GetSuppliers()
        {
            return Ok(_supplierService.GetAll());
        }

        // [HttpGet("get-all")]
        // public IActionResult GetSuppliers2([FromQuery] FilterDto0072767De1 input)
        // {
        //     try
        //     {
        //         return Ok(_supplierService.GetAll(input));
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(new ApiResponse0072767De1
        //         {
        //             Message = ex.Message
        //         });
        //     }
        // }

        // [HttpGet("get-by-id/{id}")]
        // public IActionResult GetById(int id)
        // {
        //     return Ok(_supplierService.FindSupplierById(id));
        // }

        // [HttpPut("update")]
        // public IActionResult UpdateSupplier(UpdateSupplierDto0072767De1 input)
        // {
        //     try
        //     {
        //         _supplierService.UpdateSupplier(input);
        //         return Ok();
        //     }
        //     catch (DbUpdateException ex)
        //     {
        //         if (ex.InnerException?.Message.Contains("IX_Supplier0072767De1_Name") == true)
        //         {
        //             return BadRequest("Tên nhà cung cấp đã tồn tại.");
        //         }

        //         // Các lỗi DB khác (ví dụ: constraint khác)
        //         return StatusCode(500, "Lỗi khi cập nhật dữ liệu.");
        //     }
        // }

        // [HttpDelete("delete/{id}")]
        // public IActionResult DeleteSupplier(int id)
        // {
        //     _supplierService.DeleteSupplier(id);
        //     return Ok();
        // }
    }
}
