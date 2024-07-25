using Microsoft.EntityFrameworkCore;
using ShreeGanpati.API.Data.Entities;

namespace ShreeGanpati.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Jewellery> Jewels { get; set; }
        public DbSet<JewelleryOption> jewelleryOptions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JewelleryOption>().HasKey(io => new { io.JewelleryId, io.Metel, io.AddOns });
        }

        public static void AddSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    Address = "123 Main St",
                    Salt = "random_salt",
                    Hash = "hashed_password"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    Address = "456 Another St",
                    Salt = "random_salt",
                    Hash = "hashed_password"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Alice Johnson",
                    Email = "alice.johnson@example.com",
                    Address = "789 Third St",
                    Salt = "random_salt",
                    Hash = "hashed_password"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Bob Brown",
                    Email = "bob.brown@example.com",
                    Address = "101 Fourth St",
                    Salt = "random_salt",
                    Hash = "hashed_password"
                }
            );

            modelBuilder.Entity<Jewellery>().HasData(
                new Jewellery
                {
                    Id = 1,
                    Name = "Gold Ring",
                    Price = 250.00,
                    Image = "https://www.tanishq.co.in/on/demandware.static/-/Sites-Tanishq-product-catalog/default/dw908fe0fa/images/hi-res/511920FCMAA00.jpg"
                },
                new Jewellery
                {
                    Id = 2,
                    Name = "Silver Necklace",
                    Price = 150.00,
                    Image = "https://www.kushals.com/cdn/shop/files/silver-necklace-ruby-oxidised-silver-92-5-silver-necklace-163060-36877758890140.jpg"
                },
                new Jewellery
                {
                    Id = 3,
                    Name = "Platinum Bracelet",
                    Price = 350.00,
                    Image = "https://www.jcsjewellers.com/cdn/shop/products/JCPTBB4003.jpg"
                },
                new Jewellery
                {
                    Id = 4,
                    Name = "Diamond Earrings",
                    Price = 500.00,
                    Image = "https://d25g9z9s77rn4i.cloudfront.net/uploads/product/1129/1661258687_692158ae086ac8038896.png"
                },
                new Jewellery
                {
                    Id = 5,
                    Name = "Pearl Pendant",
                    Price = 200.00,
                    Image = "https://m.media-amazon.com/images/I/71jONezhpTL._AC_UY1100_.jpg"
                }
            );

            modelBuilder.Entity<JewelleryOption>().HasData(
                new JewelleryOption
                {
                    JewelleryId = 1,
                    Metel = "Gold",
                    AddOns = "Diamond"
                },
                new JewelleryOption
                {
                    JewelleryId = 2,
                    Metel = "Silver",
                    AddOns = "Emerald"
                },
                new JewelleryOption
                {
                    JewelleryId = 3,
                    Metel = "Platinum",
                    AddOns = "Sapphire"
                },
                new JewelleryOption
                {
                    JewelleryId = 4,
                    Metel = "Gold",
                    AddOns = "Ruby"
                },
                new JewelleryOption
                {
                    JewelleryId = 5,
                    Metel = "Silver",
                    AddOns = "Topaz"
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "John Doe",
                    CustomerEmail = "john.doe@example.com",
                    CustomerAddress = "123 Main St",
                    TotalPrice = 500.00,
                    OrderAt = DateTime.Now
                }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = 1,
                    OrderId = "1",
                    JewelleryId = 1,
                    Name = "Gold Ring",
                    Price = 250.00,
                    Quantity = 1,
                    Metel = "Gold",
                    AddOns = "Diamond",
                    TotalPrice = 250.00
                },
                new OrderItem
                {
                    Id = 2,
                    OrderId = "1",
                    JewelleryId = 2,
                    Name = "Silver Necklace",
                    Price = 150.00,
                    Quantity = 2,
                    Metel = "Silver",
                    AddOns = "Emerald",
                    TotalPrice = 300.00
                }
            );
        }
    }
}
