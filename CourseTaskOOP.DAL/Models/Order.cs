namespace CourseTaskOOP.DAL.Models;

public class Order : Entity
{
    public string Name { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime Deadline { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
}