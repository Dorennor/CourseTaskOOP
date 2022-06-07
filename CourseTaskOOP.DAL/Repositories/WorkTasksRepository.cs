using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class WorkTasksRepository : IRepository<WorkTask>
{
    private readonly TaskDbContext _dbContext;

    public WorkTasksRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<WorkTask>?> GetAllAsync()
    {
        try
        {
            var obj = await _dbContext.WorkTasks.ToListAsync();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<WorkTask?> GetByIdAsync(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = await _dbContext.WorkTasks.FirstOrDefaultAsync(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<List<WorkTask>> FindAsync(Func<WorkTask, bool> predicate)
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

    public async Task<WorkTask> CreateAsync(WorkTask item)
    {
        try
        {
            if (item == null) return null;
            var obj = await _dbContext.WorkTasks.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task UpdateAsync(WorkTask item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.WorkTasks.Update(item);
            if (obj != null) await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteAsync(WorkTask item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.WorkTasks.Remove(item);
            if (obj == null) return;
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}