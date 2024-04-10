namespace ThAmCo.Catering.Data;

public class DataContext : DbContext
{
    public DbSet<FoodItem> FoodItems { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuFoodItem> MenuFoodItems { get; set; }
    public DbSet<FoodBooking> FoodBookings { get; set; }
    private string DbPath { get; } = string.Empty;

    public DataContext()
    {
        var folder = Environment.SpecialFolder.MyDocuments;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "ThAmCo.Catering.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={DbPath}");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // composite primary key for MenuFoodItem
        modelBuilder.Entity<MenuFoodItem>()
            .HasKey(mfi => new { mfi.MenuId, mfi.FoodItemId });

        modelBuilder.Entity<MenuFoodItem>()
            .HasOne(m => m.Menu)
            .WithMany(mfi => mfi.MenuFoodItems)
            .HasForeignKey(mfi => mfi.MenuId);

        modelBuilder.Entity<MenuFoodItem>()
            .HasOne(fi => fi.FoodItem)
            .WithMany(m => m.MenuFoodItems)
            .HasForeignKey(u => u.FoodItemId);


        modelBuilder.Entity<FoodItem>()
            .HasMany(f => f.MenuFoodItems)
            .WithOne(mf => mf.FoodItem)
            .HasForeignKey(mf => mf.FoodItemId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Menu>()
            .HasMany(f => f.MenuFoodItems)
            .WithOne(mf => mf.Menu)
            .HasForeignKey(mf => mf.MenuId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed some data 


        var vegetarianFoodItems = new List<FoodItem>
        {
            new() { FoodItemId = 1, Name = "Salad", Description = "Fresh vegetable salad with dressing", UnitPrice = 9.99f },
            new() { FoodItemId = 2, Name = "Pasta", Description = "Pasta with tomato sauce and assorted vegetables", UnitPrice = 12.99f },
            new() { FoodItemId = 3, Name = "Vegetable Skewers", Description = "Assorted vegetables grilled to perfection", UnitPrice = 11.99f },
            new() { FoodItemId = 4, Name = "Vegetarian Pizza", Description = "Pizza with a variety of vegetarian toppings", UnitPrice = 14.99f },
            new() { FoodItemId = 5, Name = "Spinach and Mushroom Quiche", Description = "Quiche filled with spinach, mushrooms, and cheese", UnitPrice = 13.99f },
            new() { FoodItemId = 6, Name = "Eggplant Parmesan", Description = "Baked eggplant with marinara sauce and cheese", UnitPrice = 10.99f },
            new() { FoodItemId = 7, Name = "Vegetarian Sushi Roll", Description = "Sushi roll with avocado, cucumber, and other veggies", UnitPrice = 16.99f },
            new() { FoodItemId = 8, Name = "Vegetable Stir Fry", Description = "Assorted vegetables stir-fried in a savory sauce", UnitPrice = 9.99f },
            new() { FoodItemId = 9, Name = "Caprese Salad", Description = "Tomatoes, mozzarella, and basil drizzled with balsamic glaze", UnitPrice = 8.99f },
            new() { FoodItemId = 10, Name = "Vegetarian Burger", Description = "Plant-based burger with all the fixings", UnitPrice = 12.99f }
        };

        var seafoodFoodItems = new List<FoodItem>
        {
            new() { FoodItemId = 11, Name = "Grilled Salmon", Description = "Fresh salmon fillet grilled to perfection", UnitPrice = 18.99f },
            new() { FoodItemId = 12, Name = "Shrimp Scampi", Description = "Shrimp sautéed in garlic, butter, and white wine sauce", UnitPrice = 16.99f },
            new() { FoodItemId = 13, Name = "Lobster Tail", Description = "Butter-poached lobster tail served with drawn butter", UnitPrice = 29.99f },
            new() { FoodItemId = 14, Name = "Seafood Paella", Description = "Spanish rice dish with a mix of seafood, saffron, and vegetables", UnitPrice = 24.99f },
            new() { FoodItemId = 15, Name = "Crab Cakes", Description = "Delicious crab cakes made with lump crab meat and spices", UnitPrice = 21.99f },
            new() { FoodItemId = 16, Name = "Clam Chowder", Description = "Creamy soup with tender clams, potatoes, and vegetables", UnitPrice = 14.99f },
            new() { FoodItemId = 17, Name = "Fish Tacos", Description = "Soft tacos filled with grilled fish, coleslaw, and salsa", UnitPrice = 12.99f },
            new() { FoodItemId = 18, Name = "Mussels Marinara", Description = "Mussels cooked in a flavorful marinara sauce", UnitPrice = 17.99f },
            new() { FoodItemId = 19, Name = "Sushi Assortment", Description = "Assorted sushi rolls with fresh fish and rice", UnitPrice = 23.99f },
            new() { FoodItemId = 20, Name = "Oysters Rockefeller", Description = "Oysters topped with a rich mixture of herbs, spinach, and breadcrumbs", UnitPrice = 19.99f }
        };
        var nonVegetarianFoodItems = new List<FoodItem>
        {
            new() { FoodItemId = 21, Name = "Beef Steak", Description = "Juicy beef steak cooked to your liking", UnitPrice = 22.99f },
            new() { FoodItemId = 22, Name = "Chicken Alfredo Pasta", Description = "Creamy Alfredo sauce with grilled chicken and pasta", UnitPrice = 17.99f },
            new() { FoodItemId = 23, Name = "Pork Ribs", Description = "Tender pork ribs slow-cooked and glazed with barbecue sauce", UnitPrice = 19.99f },
            new() { FoodItemId = 24, Name = "Lamb Curry", Description = "Spicy lamb curry with aromatic herbs and spices", UnitPrice = 20.99f },
            new() { FoodItemId = 25, Name = "Bacon Wrapped Shrimp", Description = "Shrimp wrapped in crispy bacon and grilled to perfection", UnitPrice = 16.99f },
            new() { FoodItemId = 26, Name = "Sausage Pizza", Description = "Pizza topped with a variety of sausages and cheese", UnitPrice = 14.99f },
            new() { FoodItemId = 27, Name = "Beef Burrito", Description = "Burrito filled with seasoned beef, beans, and rice", UnitPrice = 12.99f },
            new() { FoodItemId = 28, Name = "Chicken Wings", Description = "Spicy or BBQ chicken wings served with dipping sauce", UnitPrice = 11.99f },
            new() { FoodItemId = 29, Name = "Steak Tacos", Description = "Soft tacos filled with grilled steak, onions, and cilantro", UnitPrice = 18.99f },
            new() { FoodItemId = 30, Name = "Ham and Cheese Sandwich", Description = "Classic sandwich with ham, cheese, and fresh vegetables", UnitPrice = 9.99f }
        };
        modelBuilder.Entity<FoodItem>().HasData(
                    vegetarianFoodItems.Concat(seafoodFoodItems).Concat(nonVegetarianFoodItems)
            );


        modelBuilder.Entity<Menu>().HasData(
            new Menu { MenuId = 1, MenuName = "Vegetarian Menu" },
            new Menu { MenuId = 3, MenuName = "Seafood Menu" },
            new Menu { MenuId = 2, MenuName = "Non-Vegetarian Menu" }

        );

        modelBuilder.Entity<MenuFoodItem>().HasData(
            new MenuFoodItem { MenuId = 1, FoodItemId = 1 },
            new MenuFoodItem { MenuId = 1, FoodItemId = 2 },
            new MenuFoodItem { MenuId = 1, FoodItemId = 3 },
            new MenuFoodItem { MenuId = 1, FoodItemId = 4 },
            new MenuFoodItem { MenuId = 1, FoodItemId = 5 },
            new MenuFoodItem { MenuId = 1, FoodItemId = 6 },
            new MenuFoodItem { MenuId = 1, FoodItemId = 7 },
            new MenuFoodItem { MenuId = 1, FoodItemId = 8 },
            new MenuFoodItem { MenuId = 1, FoodItemId = 9 },
            new MenuFoodItem { MenuId = 1, FoodItemId = 10 },

            new MenuFoodItem { MenuId = 2, FoodItemId = 11 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 12 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 13 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 14 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 15 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 16 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 17 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 18 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 19 },
            new MenuFoodItem { MenuId = 2, FoodItemId = 20 },
                       
            new MenuFoodItem { MenuId = 3, FoodItemId = 21 },
            new MenuFoodItem { MenuId = 3, FoodItemId = 22 },
            new MenuFoodItem { MenuId = 3, FoodItemId = 23 },
            new MenuFoodItem { MenuId = 3, FoodItemId = 24 },
            new MenuFoodItem { MenuId = 3, FoodItemId = 25 },
            new MenuFoodItem { MenuId = 3, FoodItemId = 26 },
            new MenuFoodItem { MenuId = 3, FoodItemId = 27 },
            new MenuFoodItem { MenuId = 3, FoodItemId = 28 },
            new MenuFoodItem { MenuId = 3, FoodItemId = 29 },
            new MenuFoodItem { MenuId = 3, FoodItemId = 30 }
        );

        modelBuilder.Entity<FoodBooking>().HasData(
            new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 1, MenuId = 1 , FoodBookingDate = DateTime.Now.AddDays(1) },
            new FoodBooking { FoodBookingId = 2, ClientReferenceId = 2, NumberOfGuests = 2, MenuId = 2 ,FoodBookingDate = DateTime.Now.AddDays(2) },
            new FoodBooking { FoodBookingId = 3, ClientReferenceId = null, NumberOfGuests = 51, MenuId = 1 }

        );
    }
}
