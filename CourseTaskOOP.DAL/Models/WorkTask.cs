namespace CourseTaskOOP.DAL.Models;

public class WorkTask : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int HoursToComplete { get; set; }
}