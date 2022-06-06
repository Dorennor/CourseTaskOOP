using Microsoft.EntityFrameworkCore;

namespace CourseTaskOOP.DAL.Models;

[Index(nameof(UserName), IsUnique = true)]
public class Worker : Person
{
    public string UserName { get; set; }
    public string Position { get; set; }
}