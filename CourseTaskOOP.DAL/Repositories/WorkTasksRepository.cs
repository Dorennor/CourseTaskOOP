using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class WorkTasksRepository : IRepository<WorkTask>
{
    private readonly TaskDbContext _dbContext;

    public WorkTasksRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<WorkTask> GetAll()
    {
        try
        {
            var obj = _dbContext.WorkTasks.ToList();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public WorkTask GetById(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = _dbContext.WorkTasks.FirstOrDefault(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public List<WorkTask> Find(Func<WorkTask, bool> predicate)
    {
        try
        {
            if (predicate == null) return null;
            return _dbContext.WorkTasks.Where(predicate).ToList();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public WorkTask Create(WorkTask item)
    {
        try
        {
            if (item == null) return null;
            var obj = _dbContext.WorkTasks.Add(item);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public void Update(WorkTask item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.WorkTasks.Update(item);
            if (obj != null) _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public void Delete(WorkTask item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.WorkTasks.Remove(item);
            if (obj == null) return;
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}