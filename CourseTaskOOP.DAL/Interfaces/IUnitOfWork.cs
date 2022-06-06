using CourseTaskOOP.DAL.Models;

namespace CourseTaskOOP.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Administrator> Administrators { get; set; }
    IRepository<Client> Clients { get; set; }
    IRepository<Developer> Developers { get; set; }
    IRepository<Manager> Managers { get; set; }
    IRepository<Order> Orders { get; set; }
    IRepository<Project> Projects { get; set; }
    IRepository<Team> Teams { get; set; }
    IRepository<TeamLeader> TeamLeaders { get; set; }
    IRepository<TeamMember> TeamMembers { get; set; }
    IRepository<WorkTask> WorkTasks { get; set; }

    void Save();
}