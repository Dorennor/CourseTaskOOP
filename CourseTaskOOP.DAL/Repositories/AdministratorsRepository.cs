using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class AdministratorsRepository : IRepository<Administrator>
{
    private readonly TaskDbContext _dbContext;

    public AdministratorsRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Administrator> GetAll()
    {
        try
        {
            var obj = _dbContext.Administrators.ToList();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Administrator GetById(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = _dbContext.Administrators.FirstOrDefault(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public List<Administrator> Find(Func<Administrator, bool> predicate)
    {
        try
        {
            if (predicate == null) return null;
            return _dbContext.Administrators.Where(predicate).ToList();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Administrator Create(Administrator item)
    {
        try
        {
            if (item == null) return null;
            var obj = _dbContext.Administrators.Add(item);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public void Update(Administrator item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Administrators.Update(item);
            if (obj != null) _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public void Delete(Administrator item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Administrators.Remove(item);
            if (obj == null) return;
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}