using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class TeamsRepository : IRepository<Team>
{
    private readonly TaskDbContext _dbContext;

    public TeamsRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Team> GetAll()
    {
        try
        {
            var obj = _dbContext.Teams.ToList();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Team GetById(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = _dbContext.Teams.FirstOrDefault(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public List<Team> Find(Func<Team, bool> predicate)
    {
        try
        {
            if (predicate == null) return null;
            return _dbContext.Teams.Where(predicate).ToList();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Team Create(Team item)
    {
        try
        {
            if (item == null) return null;
            var obj = _dbContext.Teams.Add(item);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public void Update(Team item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Teams.Update(item);
            if (obj != null) _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public void Delete(Team item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Teams.Remove(item);
            if (obj == null) return;
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}