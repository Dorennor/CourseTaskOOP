using CourseTaskOOP.DAL.Models;
using Faker;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CourseTaskOOP.DAL.Data;

public class SeedData
{
    public static void SeedDevelopers(ModelBuilder modelBuilder)
    {
        List<Developer> developers = new List<Developer>();
        string[] positions = new[] { "Backend developer", "Frontend developer", "Tester", "DevOPS", "Architect" };
        Random random = new Random();

        for (int i = 0; i < 30; i++)
        {
            developers.Add(new Developer
            {
                Id = i + 1,
                FullName = Faker.Name.FullName(NameFormats.Standard),
                UserName = Faker.Internet.UserName(),
                Position = positions[random.Next(0, positions.Length - 1)],
                PasswordHash = GeneratePasswordHash($"developer{i + 1}"),
                IsLogged = false
            });
        }

        modelBuilder.Entity<Developer>().HasData(developers);
    }

    public static void SeedClients(ModelBuilder modelBuilder)
    {
        List<Client> clients = new List<Client>();

        for (int i = 0; i < 30; i++)
        {
            clients.Add(new Client
            {
                Id = i + 1,
                Email = Faker.Internet.Email(),
                FullName = Faker.Name.FullName(),
                IsLogged = false,
                PasswordHash = GeneratePasswordHash($"client{i + 1}")
            });
        }

        modelBuilder.Entity<Client>().HasData(clients);
    }

    public static void SeedAdministrators(ModelBuilder modelBuilder)
    {
        List<Administrator> administrators = new List<Administrator>();
        administrators.Add(new Administrator
        {
            Id = 1,
            FullName = "Administrator",
            IsLogged = false,
            Position = "Administrator",
            UserName = "Administrator",
            PasswordHash = GeneratePasswordHash("administrator")
        });
        administrators.Add(new Administrator
        {
            Id = 2,
            FullName = "Admin",
            IsLogged = false,
            Position = "Admin",
            UserName = "Admin",
            PasswordHash = GeneratePasswordHash("admin")
        });

        modelBuilder.Entity<Administrator>().HasData(administrators);
    }

    public static void SeedManager(ModelBuilder modelBuilder)
    {
        List<Manager> managers = new List<Manager>();
        managers.Add(new Manager()
        {
            Id = 1,
            FullName = "Manager1",
            IsLogged = false,
            PasswordHash = GeneratePasswordHash("manager1"),
            Position = "Manager",
            UserName = "Manager1"
        });
        managers.Add(new Manager
        {
            Id = 2,
            FullName = "Manager2",
            IsLogged = false,
            PasswordHash = GeneratePasswordHash("manager2"),
            Position = "Manager",
            UserName = "Manager2"
        });

        modelBuilder.Entity<Manager>().HasData(managers);
    }

    public static string GeneratePasswordHash(string password)
    {
        using (var sha512 = SHA512.Create())
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashCode = sha512.ComputeHash(bytes);
            return BitConverter.ToString(hashCode);
        }
    }
}