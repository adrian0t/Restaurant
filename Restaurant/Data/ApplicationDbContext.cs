using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using Microsoft.AspNetCore.Identity;

namespace Restaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            
            modelBuilder.Entity<Category>().HasData(
               new Category { CategoryId = 1, Name = "Przystawka" },
               new Category { CategoryId = 2, Name = "Danie Główne" },
               new Category { CategoryId = 3, Name = "Napój" },
               new Category { CategoryId = 4, Name = "Deser" }
           );

            modelBuilder.Entity<Ingredient>().HasData(
              new Ingredient { IngredientId = 1, Name = "Wołowina" },
              new Ingredient { IngredientId = 2, Name = "Cheddar" },
              new Ingredient { IngredientId = 3, Name = "Sałata" },
              new Ingredient { IngredientId = 4, Name = "Tortilla" },
              new Ingredient { IngredientId = 5, Name = "Pomidor" },
              new Ingredient { IngredientId = 6, Name = "Ketchup" },
              new Ingredient { IngredientId = 7, Name = "Filet z kurczaka" }
          );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Cheeseburger",
                    Description = "Topiony ser cheddar, świeża sałata, plasterki ogórka i pomidor, a to wszystko w chrupiącej bułce z sezamem.",
                    Price = 7.50m,
                    Stock = 15,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Big King",
                    Description = "Dwa kotlety wołowe, dwa plastry sera cheddar, cebula, sałata i specjalny sos Big King, podane w puszystej bułce.",
                    Price = 11.99m,
                    Stock = 21,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Chicken Burger",
                    Description = "Delikatna pierś z kurczaka, chrupiąca sałata, soczysty pomidor i kremowy majonez w świeżo wypieczonej bułce.",
                    Price = 11.99m,
                    Stock = 21,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Chicken Taco",
                    Description = "Aromatyczne kawałki kurczaka w pikantnych przyprawach, podane w miękkiej tortilli z dodatkiem sałaty, pomidorów i śmietany.",
                    Price = 13.99m,
                    Stock = 5,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Beef Taco",
                    Description = "Soczysta mielona wołowina w przyprawach meksykańskich, w miękkiej tortilli, z chrupiącą sałatą, pomidorami i startym serem cheddar.",
                    Price = 13.99m,
                    Stock = 5,
                    CategoryId = 2
                }
            );

            modelBuilder.Entity<ProductIngredient>().HasData(
                new ProductIngredient { ProductId = 1, IngredientId = 1 },
                new ProductIngredient { ProductId = 1, IngredientId = 4 },
                new ProductIngredient { ProductId = 1, IngredientId = 5 },
                new ProductIngredient { ProductId = 1, IngredientId = 6 },
                new ProductIngredient { ProductId = 2, IngredientId = 2 },
                new ProductIngredient { ProductId = 2, IngredientId = 4 },
                new ProductIngredient { ProductId = 2, IngredientId = 5 },
                new ProductIngredient { ProductId = 2, IngredientId = 6 },
                new ProductIngredient { ProductId = 3, IngredientId = 3 },
                new ProductIngredient { ProductId = 3, IngredientId = 4 },
                new ProductIngredient { ProductId = 3, IngredientId = 5 },
                new ProductIngredient { ProductId = 3, IngredientId = 6 }
            );

            
            var adminUser = new ApplicationUser
            {
                Id = "292be1fc-2d82-4131-b88f-cd5c66e4db23",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAIAAYagAAAAEGkPzNNNl+LqrLtuKKGrnzGoTti/23/cpSU18hPvMP7bRPmpHN0ObNGmGhqxt+OeDg==",
                SecurityStamp = "E7A35PNHJXJ2XKLMAIBUBC6VAK5G25BW",
                ConcurrencyStamp = "13036560-f121-446c-8d24-347cc7809a9e",
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUser.Id,
                RoleId = "1"
            });
        }
    }
}
