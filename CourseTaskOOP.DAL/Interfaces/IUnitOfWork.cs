using CourseTaskOOP.DAL.Models;

namespace CourseTaskOOP.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; set; }

    IRepository<Order> Orders { get; set; }
    IRepository<Project> Projects { get; set; }
    IRepository<Team> Teams { get; set; }
    IRepository<TeamMember> TeamMembers { get; set; }
    IRepository<WorkTask> WorkTasks { get; set; }

    Task SaveAsync();
}