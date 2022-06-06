using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CourseTaskOOP.DAL.Data;

public class TaskDbContextFactory : IDesignTimeDbContextFactory<TaskDbContext>
{
    public TaskDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TaskDbContext>();

        ConfigurationBuilder builder = new ConfigurationBuilder();

        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");

        var config = builder.Build();
        var connectionString = config.GetConnectionString("SQLiteConnection");

        optionsBuilder.UseSqlite(connectionString);
        return new TaskDbContext(optionsBuilder.Options);
    }
}