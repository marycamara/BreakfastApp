using Microsoft.EntityFrameworkCore;
using BreakfastApp.Models;


namespace BreakfastApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ShoppingItem> ShoppingItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=app.db");
    }
}
