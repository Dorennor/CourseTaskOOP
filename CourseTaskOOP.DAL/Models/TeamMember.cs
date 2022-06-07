namespace CourseTaskOOP.DAL.Models;

public class TeamMember : Entity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int TeamId { get; set; }
    public string Position { get; set; }
}