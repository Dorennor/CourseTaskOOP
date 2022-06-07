using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class OrdersRepository : IRepository<Order>
{
    private readonly TaskDbContext _dbContext;

    public OrdersRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        try
        {
            var obj = await _dbContext.Orders.ToListAsync();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = await _dbContext.Orders.FirstOrDefaultAsync(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<List<Order>> FindAsync(Func<Order, bool> predicate)
    {
        try
        {
            if (predicate == null) return null;
            return _dbContext.Orders.Where(predicate).ToList();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<Order> CreateAsync(Order item)
    {
        try
        {
            if (item == null) return null;
            var obj = await _dbContext.Orders.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task UpdateAsync(Order item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Orders.Update(item);
            if (obj != null) await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteAsync(Order item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Orders.Remove(item);
            if (obj == null) return;
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}