namespace CourseTaskOOP.DAL.Models;

public class Team : Entity
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int ProjectId { get; set; }
}