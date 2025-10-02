
using Microsoft.EntityFrameworkCore;
using DaoXuanHau0072767.DbContexts;
using DaoXuanHau0072767.Services.Abstract;
using DaoXuanHau0072767.Services.Implements;

namespace DaoXuanHau0072767
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IStoreService0072767De1, StoreService0072767De1>();
            builder.Services.AddScoped<ISupplierService0072767De1, SupplierService0072767De1>();
            builder.Services.AddScoped<IStoreSupplierService0072767De1, StoreSupplierService0072767De1>();
            //builder.Services.AddSingleton<ApplicationDbContext>(); //dùng singleton vì muốn dùng chung một object

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
