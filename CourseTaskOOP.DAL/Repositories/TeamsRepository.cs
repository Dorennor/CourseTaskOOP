using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class TeamsRepository : IRepository<Team>
{
    private readonly TaskDbContext _dbContext;

    public TeamsRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Team>?> GetAllAsync()
    {
        try
        {
            var obj = await _dbContext.Teams.ToListAsync();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<Team?> GetByIdAsync(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = await _dbContext.Teams.FirstOrDefaultAsync(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<List<Team>> FindAsync(Func<Team, bool> predicate)
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

    public async Task<Team> CreateAsync(Team item)
    {
        try
        {
            if (item == null) return null;
            var obj = await _dbContext.Teams.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task UpdateAsync(Team item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Teams.Update(item);
            if (obj != null) await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteAsync(Team item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Teams.Remove(item);
            if (obj == null) return;
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}