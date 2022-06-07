using CourseTaskOOP.DAL.Models;
using Faker;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CourseTaskOOP.DAL.Data;

public class SeedData
{
    public static void SeedUsers(ModelBuilder modelBuilder)
    {
        List<User> users = new List<User>();

        for (int i = 1; i <= 30; i++)
        {
            users.Add(new User
            {
                Id = i,
                UserName = Faker.Internet.UserName(),
                FullName = Faker.Name.FullName(),
                IsLogged = false,
                PasswordHash = GeneratePasswordHash($"client{i}"),
                Role = "Client"
            });
        }

        for (int i = 31; i <= 60; i++)
        {
            users.Add(new User
            {
                Id = i,
                FullName = Faker.Name.FullName(NameFormats.Standard),
                UserName = Faker.Internet.UserName(),
                Role = "Developer",
                PasswordHash = GeneratePasswordHash($"developer{i}"),
                IsLogged = false
            });
        }

        users.Add(new User
        {
            Id = 61,
            FullName = "Administrator",
            IsLogged = false,
            Role = "Administrator",
            UserName = "Administrator",
            PasswordHash = GeneratePasswordHash("administrator")
        });

        users.Add(new User
        {
            Id = 62,
            FullName = "Admin",
            IsLogged = false,
            Role = "Administrator",
            UserName = "Admin",
            PasswordHash = GeneratePasswordHash("admin")
        });

        users.Add(new User
        {
            Id = 63,
            FullName = "Manager1",
            IsLogged = false,
            PasswordHash = GeneratePasswordHash("manager1"),
            Role = "Manager",
            UserName = "Manager1"
        });

        users.Add(new User
        {
            Id = 64,
            FullName = "Manager2",
            IsLogged = false,
            PasswordHash = GeneratePasswordHash("manager2"),
            Role = "Manager",
            UserName = "Manager2"
        });

        modelBuilder.Entity<User>().HasData(users);
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