using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;

namespace CourseTaskOOP.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed = false;
    private readonly TaskDbContext _dbContext;
    private IRepository<Administrator> _administrators;
    private IRepository<Client> _clients;
    private IRepository<Developer> _developers;
    private IRepository<WorkTask> _workTasks;
    private IRepository<TeamLeader> _teamLeaders;
    private IRepository<Team> _teams;
    private IRepository<Project> _projects;
    private IRepository<Order> _orders;
    private IRepository<Manager> _managers;
    private IRepository<TeamMember> _teamMembers;

    public UnitOfWork()
    {
        _dbContext = new TaskDbContext();
    }

    public IRepository<Administrator> Administrators
    {
        get => _administrators ??= new AdministratorsRepository(_dbContext);
        set => _administrators = value;
    }

    public IRepository<Client> Clients
    {
        get => _clients ??= new ClientsRepository(_dbContext);
        set => _clients = value;
    }

    public IRepository<Developer> Developers
    {
        get => _developers ??= new DevelopersRepository(_dbContext);
        set => _developers = value;
    }

    public IRepository<Manager> Managers
    {
        get => _managers ??= new ManagersRepository(_dbContext);
        set => _managers = value;
    }

    public IRepository<Order> Orders
    {
        get => _orders ??= new OrdersRepository(_dbContext);
        set => _orders = value;
    }

    public IRepository<Project> Projects
    {
        get => _projects ??= new ProjectsRepository(_dbContext);
        set => _projects = value;
    }

    public IRepository<Team> Teams
    {
        get => _teams ??= new TeamsRepository(_dbContext);
        set => _teams = value;
    }

    public IRepository<TeamLeader> TeamLeaders
    {
        get => _teamLeaders ??= new TeamLeadersRepository(_dbContext);
        set => _teamLeaders = value;
    }

    public IRepository<TeamMember> TeamMembers
    {
        get => _teamMembers ??= new TeamMembersRepository(_dbContext);
        set => _teamMembers = value;
    }

    public IRepository<WorkTask> WorkTasks
    {
        get => _workTasks ??= new WorkTasksRepository(_dbContext);
        set => _workTasks = value;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _dbContext.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}