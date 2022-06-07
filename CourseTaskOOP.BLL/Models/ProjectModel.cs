namespace CourseTaskOOP.BLL.Models;

public class ProjectModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int OrderId { get; set; }
}