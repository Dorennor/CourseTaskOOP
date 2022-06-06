namespace CourseTaskOOP.BLL.Models;

public class ManagerModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string PasswordHash { get; set; }
    public bool IsLogged { get; set; }
    public string UserName { get; set; }
    public string Position { get; set; }
}