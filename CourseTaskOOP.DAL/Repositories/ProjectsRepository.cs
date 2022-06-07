using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class ProjectsRepository : IRepository<Project>
{
    private readonly TaskDbContext _dbContext;

    public ProjectsRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Project>> GetAllAsync()
    {
        try
        {
            var obj = await _dbContext.Projects.ToListAsync();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = await _dbContext.Projects.FirstOrDefaultAsync(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<List<Project>> FindAsync(Func<Project, bool> predicate)
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

    public async Task<Project> CreateAsync(Project item)
    {
        try
        {
            if (item == null) return null;
            var obj = await _dbContext.Projects.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task UpdateAsync(Project item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Projects.Update(item);
            if (obj != null) await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteAsync(Project item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Projects.Remove(item);
            if (obj == null) return;
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}