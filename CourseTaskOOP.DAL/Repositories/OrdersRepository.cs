using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class OrdersRepository : IRepository<Order>
{
    private readonly TaskDbContext _dbContext;

    public OrdersRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Order> GetAll()
    {
        try
        {
            var obj = _dbContext.Orders.ToList();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Order GetById(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = _dbContext.Orders.FirstOrDefault(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public List<Order> Find(Func<Order, bool> predicate)
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

    public Order Create(Order item)
    {
        try
        {
            if (item == null) return null;
            var obj = _dbContext.Orders.Add(item);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public void Update(Order item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Orders.Update(item);
            if (obj != null) _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public void Delete(Order item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Orders.Remove(item);
            if (obj == null) return;
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}