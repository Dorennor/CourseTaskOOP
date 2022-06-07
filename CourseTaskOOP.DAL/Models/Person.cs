using Microsoft.EntityFrameworkCore;

namespace CourseTaskOOP.DAL.Models;

[Index(nameof(UserName), IsUnique = true)]
public class Person : Entity
{
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string PasswordHash { get; set; }
    public bool IsLogged { get; set; }
    public string Role { get; set; }
}