using Abc.Data.Shop;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra {
    public class ShopDbContext : DbContext {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options) { }
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderItemData> OrderItems { get; set; }
        public DbSet<CatalogData> Catalogs { get; set; }
        public DbSet<BrandData> Brands { get; set; }
        public DbSet<BuyerData> Buyers { get; set; }
        public DbSet<ProductData> Products { get; set; }
        public DbSet<BasketItemData> BasketItems { get; set; }
        public DbSet<BasketData> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b) {
            b.Entity<BasketData>().ToTable(nameof(Baskets));
            b.Entity<BasketItemData>().ToTable(nameof(BasketItems))
                .HasKey(x => new { x.BasketId, x.ProductId });
            b.Entity<ProductData>().ToTable(nameof(Products))
                .Property(x => x.Price)
                .HasColumnType("decimal(16,4)");
            b.Entity<OrderData>().ToTable(nameof(Orders));
            b.Entity<OrderItemData>().ToTable(nameof(OrderItems))
                .HasKey(x => new { x.OrderId, x.ProductId });
            b.Entity<BrandData>().ToTable(nameof(Brands));
            b.Entity<CatalogData>().ToTable(nameof(Catalogs));
            b.Entity<BuyerData>().ToTable(nameof(Buyers));
        }
    }
}
