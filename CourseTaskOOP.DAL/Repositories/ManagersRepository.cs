using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class ManagersRepository : IRepository<Manager>
{
    private readonly TaskDbContext _dbContext;

    public ManagersRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Manager> GetAll()
    {
        try
        {
            var obj = _dbContext.Managers.ToList();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Manager GetById(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = _dbContext.Managers.FirstOrDefault(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public List<Manager> Find(Func<Manager, bool> predicate)
    {
        try
        {
            if (predicate == null) return null;
            return _dbContext.Managers.Where(predicate).ToList();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Manager Create(Manager item)
    {
        try
        {
            if (item == null) return null;
            var obj = _dbContext.Managers.Add(item);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public void Update(Manager item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Managers.Update(item);
            if (obj != null) _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public void Delete(Manager item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Managers.Remove(item);
            if (obj == null) return;
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}