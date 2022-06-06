namespace CourseTaskOOP.DAL.Models;

public class Project : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int TeamId { get; set; }
    public Team Team { get; set; }
}