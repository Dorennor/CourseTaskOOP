namespace CourseTaskOOP.DAL.Models;

public class Person : Entity
{
    public string FullName { get; set; }
    public string PasswordHash { get; set; }
    public bool IsLogged { get; set; }
}