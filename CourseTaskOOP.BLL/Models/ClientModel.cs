namespace CourseTaskOOP.BLL.Models;

public class ClientModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string PasswordHash { get; set; }
    public bool IsLogged { get; set; }
    public string Email { get; set; }
}