using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;

namespace CourseTaskOOP.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed = false;
    private readonly TaskDbContext _dbContext;
    private IRepository<User> _clients;
    private IRepository<WorkTask> _workTasks;
    private IRepository<Team> _teams;
    private IRepository<Project> _projects;
    private IRepository<Order> _orders;
    private IRepository<TeamMember> _teamMembers;

    public UnitOfWork()
    {
        _dbContext = new TaskDbContext();
    }

    public IRepository<User> Users
    {
        get => _clients ??= new UsersRepository(_dbContext);
        set => _clients = value;
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

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
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