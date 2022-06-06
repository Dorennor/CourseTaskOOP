using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class ProjectsRepository : IRepository<Project>
{
    private readonly TaskDbContext _dbContext;

    public ProjectsRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Project> GetAll()
    {
        try
        {
            var obj = _dbContext.Projects.ToList();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Project GetById(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = _dbContext.Projects.FirstOrDefault(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public List<Project> Find(Func<Project, bool> predicate)
    {
        try
        {
            if (predicate == null) return null;
            return _dbContext.Projects.Where(predicate).ToList();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Project Create(Project item)
    {
        try
        {
            if (item == null) return null;
            var obj = _dbContext.Projects.Add(item);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public void Update(Project item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Projects.Update(item);
            if (obj != null) _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public void Delete(Project item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Projects.Remove(item);
            if (obj == null) return;
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}