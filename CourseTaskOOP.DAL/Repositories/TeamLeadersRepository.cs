using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class TeamLeadersRepository : IRepository<TeamLeader>
{
    private readonly TaskDbContext _dbContext;

    public TeamLeadersRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<TeamLeader> GetAll()
    {
        try
        {
            var obj = _dbContext.TeamLeaders.ToList();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public TeamLeader GetById(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = _dbContext.TeamLeaders.FirstOrDefault(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public List<TeamLeader> Find(Func<TeamLeader, bool> predicate)
    {
        try
        {
            if (predicate == null) return null;
            return _dbContext.TeamLeaders.Where(predicate).ToList();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public TeamLeader Create(TeamLeader item)
    {
        try
        {
            if (item == null) return null;
            var obj = _dbContext.TeamLeaders.Add(item);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public void Update(TeamLeader item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.TeamLeaders.Update(item);
            if (obj != null) _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public void Delete(TeamLeader item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.TeamLeaders.Remove(item);
            if (obj == null) return;
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}