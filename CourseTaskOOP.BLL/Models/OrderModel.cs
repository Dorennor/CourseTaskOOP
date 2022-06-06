namespace CourseTaskOOP.BLL.Models;

public class OrderModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime Deadline { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int ProjectId { get; set; }
}