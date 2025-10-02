using Microsoft.EntityFrameworkCore;
using DaoXuanHau0072767.Entity;

namespace DaoXuanHau0072767.DbContexts
{
    /// <summary>
    /// Dùng để kết nối db
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Store0072767De1> Stores { get; set; }
        public DbSet<Supplier0072767De1> Suppliers { get; set; }
        public DbSet<StoreSupplier0072767De1> StoreSuppliers { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //map entity với bảng
            //cách 1
            modelBuilder.Entity<Store0072767De1>(entity =>
            {
                entity.ToTable("Store0072767De1"); //Option
                entity.HasKey(e => e.Id);
                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id") //Option
                    .ValueGeneratedOnAdd() //identity(1,1)
                    .IsRequired(); //required field

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(true).IsRequired(); //cách 1
                                                                                             //entity.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired(); //cách 2

                // 👉 Thêm dòng này để đảm bảo Name là duy nhất không bị trùng
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Supplier0072767De1>(entity =>
            {
                entity.ToTable("Supplier0072767De1"); //Option
                entity.HasKey(e => e.Id);
                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id") //Option
                    .ValueGeneratedOnAdd() //identity(1,1)
                    .IsRequired(); //required field

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(true).IsRequired(); //cách 1
                                                                                             //entity.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired(); //cách 2

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10);
                // 👉 Thêm dòng này để đảm bảo Name là duy nhất không bị trùng
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<StoreSupplier0072767De1>(entity =>
            {
                entity.ToTable("StoreSupplier0072767De1"); //Option
                entity.HasKey(e => e.Id);
                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id") //Option
                    .ValueGeneratedOnAdd() //identity(1,1)
                    .IsRequired(); //required field

                entity.Property(e => e.StoreId)
                    .IsRequired();

                entity.Property(e => e.SupplierId)
                    .IsRequired();

                entity.Property(e => e.Intimate)
                    .IsRequired();
            });

            //cách 2 cấu hình trong entity

            //khoá ngoại

            //cách 1:
            modelBuilder
                .Entity<StoreSupplier0072767De1>() //”Class many”
                .HasOne<Store0072767De1>() //”class one”
                .WithMany()
                .HasForeignKey(sc => sc.StoreId);

            //cách 2:
            //modelBuilder.Entity<Student>()
            //    .HasMany<StudentClassroom>()
            //    .WithOne()
            //    .HasForeignKey(sc => sc.StudentId);

            //navigation property ?

            modelBuilder
                .Entity<StoreSupplier0072767De1>() //”Class many”
                .HasOne<Supplier0072767De1>() //”class one”
                .WithMany()
                .HasForeignKey(sc => sc.SupplierId);
        }
    }
}
