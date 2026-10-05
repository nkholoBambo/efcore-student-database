using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-GT5UN44\\SQLEXPRESS;Database=LosmanPractice;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}