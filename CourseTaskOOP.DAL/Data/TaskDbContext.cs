using CourseTaskOOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace CourseTaskOOP.DAL.Data;

public class TaskDbContext : DbContext
{
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Developer> Developers { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<WorkTask> WorkTasks { get; set; }
    public DbSet<TeamLeader> TeamLeaders { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();
            var connectionString = config.GetConnectionString("SQLiteConnection");

            optionsBuilder.UseSqlite(connectionString);
        }

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .WriteTo.Debug()
            .WriteTo.File(AppContext.BaseDirectory + $"/logs/{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}_log.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedData.SeedDevelopers(modelBuilder);
        SeedData.SeedAdministrators(modelBuilder);
        SeedData.SeedClients(modelBuilder);
        SeedData.SeedManager(modelBuilder);
    }

    public TaskDbContext()
    {
        Database.Migrate();
    }

    public TaskDbContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
}