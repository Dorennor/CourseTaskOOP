using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class DevelopersRepository : IRepository<Developer>
{
    private readonly TaskDbContext _dbContext;

    public DevelopersRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Developer> GetAll()
    {
        try
        {
            var obj = _dbContext.Developers.ToList();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Developer GetById(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = _dbContext.Developers.FirstOrDefault(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public List<Developer> Find(Func<Developer, bool> predicate)
    {
        try
        {
            if (predicate == null) return null;
            return _dbContext.Developers.Where(predicate).ToList();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Developer Create(Developer item)
    {
        try
        {
            if (item == null) return null;
            var obj = _dbContext.Developers.Add(item);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public void Update(Developer item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Developers.Update(item);
            if (obj != null) _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public void Delete(Developer item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Developers.Remove(item);
            if (obj == null) return;
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}