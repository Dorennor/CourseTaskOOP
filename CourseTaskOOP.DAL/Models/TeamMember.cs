namespace CourseTaskOOP.DAL.Models;

public class TeamMember : Worker
{
    public int TeamId { get; set; }
    public Team Team { get; set; }
}