using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class UsersRepository : IRepository<User>
{
    private readonly TaskDbContext _dbContext;

    public UsersRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>?> GetAllAsync()
    {
        try
        {
            var obj = await _dbContext.Users.ToListAsync();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<List<User>> FindAsync(Func<User, bool> predicate)
    {
        try
        {
            if (predicate == null) return null;
            return _dbContext.Users.Where(predicate).ToList();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<User> CreateAsync(User item)
    {
        try
        {
            if (item == null) return null;
            var obj = await _dbContext.Users.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task UpdateAsync(User item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Users.Update(item);
            if (obj != null) await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteAsync(User item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Users.Remove(item);
            if (obj == null) return;
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}