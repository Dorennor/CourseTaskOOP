using Microsoft.EntityFrameworkCore;

namespace CourseTaskOOP.DAL.Models;

[Index(nameof(Email), IsUnique = true)]
public class Client : Person
{
    public string Email { get; set; }
}