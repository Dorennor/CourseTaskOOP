using System.ComponentModel.DataAnnotations;

namespace CourseTaskOOP.DAL.Models;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }
}