using System.Data.Entity;

namespace DeviceManager.Models.DB
{
    public class DeviceManagerDbContext : DbContext
    {
        public DeviceManagerDbContext() : base("DeviceManagerConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Category> Categories { set; get; }
        public DbSet<Delivery> ProductCategories { set; get; }
        public DbSet<DeliveryDetail> DeliveryDetails { set; get; }
        public DbSet<Department> Departments { set; get; }
        public DbSet<Device> Devices { set; get; }
        public DbSet<Provider> Providers { set; get; }
        public DbSet<Receipt> Receipts { set; get; }
        public DbSet<ReceiptDetail> ReceiptDetails { set; get; }
        public DbSet<Status> Statuses { set; get; }
        public DbSet<Unit> Units { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<User> Users { set; get; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
        }
    }
}