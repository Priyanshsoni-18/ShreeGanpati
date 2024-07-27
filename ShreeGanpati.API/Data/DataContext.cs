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
            AddSeedData(modelBuilder);
        }

        public static void AddSeedData(ModelBuilder modelBuilder)
        {
            Jewellery[] jewelleries = [


                new Jewellery
                {
                    Id = 1,
                    Name = "Green Diamond Pendant",
                    Price = 45000.00,
                    Image = "https://raw.githubusercontent.com/Priyanshsoni-18/Project_Images/main/green_diamond_pendant.png"
                },
                new Jewellery
                {
                    Id = 2,
                    Name = "Gold Diamond and Ruby Ring",
                    Price = 85000.00,
                    Image = "https://raw.githubusercontent.com/Priyanshsoni-18/Project_Images/main/ruby_ring.png"
                },
                new Jewellery
                {
                    Id = 3,
                    Name = "Diamond Earring",
                    Price = 25000.00,
                    Image = "https://raw.githubusercontent.com/Priyanshsoni-18/Project_Images/main/diamond_earring.png"
                },
                new Jewellery
                {
                    Id = 4,
                    Name = "Silver Diamond Ring",
                    Price = 8000.00,
                    Image = "https://raw.githubusercontent.com/Priyanshsoni-18/Project_Images/main/diamond_ring.png"
                },
                new Jewellery
                {
                    Id = 5,
                    Name = "Gold Diamond Ring",
                    Price = 60000.00,
                    Image = "https://raw.githubusercontent.com/Priyanshsoni-18/Project_Images/main/gold_ring.png"
                }

            ];
            JewelleryOption[] jewelleriesoptions = [
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
            ];

            modelBuilder.Entity<Jewellery>().HasData(jewelleries);
            modelBuilder.Entity<JewelleryOption>().HasData(jewelleriesoptions);
        }
    }
}
