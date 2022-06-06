using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories;

public class ClientsRepository : IRepository<Client>
{
    private readonly TaskDbContext _dbContext;

    public ClientsRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Client> GetAll()
    {
        try
        {
            var obj = _dbContext.Clients.ToList();
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Client GetById(int id)
    {
        try
        {
            if (id == null) return null;

            var obj = _dbContext.Clients.FirstOrDefault(u => u.Id == id);
            return obj ?? null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public List<Client> Find(Func<Client, bool> predicate)
    {
        try
        {
            if (predicate == null) return null;
            return _dbContext.Clients.Where(predicate).ToList();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public Client Create(Client item)
    {
        try
        {
            if (item == null) return null;
            var obj = _dbContext.Clients.Add(item);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public void Update(Client item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Clients.Update(item);
            if (obj != null) _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public void Delete(Client item)
    {
        try
        {
            if (item == null) return;
            var obj = _dbContext.Clients.Remove(item);
            if (obj == null) return;
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}