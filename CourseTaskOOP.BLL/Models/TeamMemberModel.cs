namespace CourseTaskOOP.BLL.Models;

public class TeamMemberModel
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public int TeamId { get; set; }
    public string Position { get; set; }
}