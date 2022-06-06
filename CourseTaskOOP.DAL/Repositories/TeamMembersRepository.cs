using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Serilog;

namespace CourseTaskOOP.DAL.Repositories
{
    public class TeamMembersRepository : IRepository<TeamMember>
    {
        private readonly TaskDbContext _dbContext;

        public TeamMembersRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TeamMember> GetAll()
        {
            try
            {
                var obj = _dbContext.TeamMembers.ToList();
                return obj ?? null;
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
                return null;
            }
        }

        public TeamMember GetById(int id)
        {
            try
            {
                if (id == null) return null;

                var obj = _dbContext.TeamMembers.FirstOrDefault(u => u.Id == id);
                return obj ?? null;
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
                return null;
            }
        }

        public List<TeamMember> Find(Func<TeamMember, bool> predicate)
        {
            try
            {
                if (predicate == null) return null;
                return _dbContext.TeamMembers.Where(predicate).ToList();
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
                return null;
            }
        }

        public TeamMember Create(TeamMember item)
        {
            try
            {
                if (item == null) return null;
                var obj = _dbContext.TeamMembers.Add(item);
                _dbContext.SaveChanges();
                return obj.Entity;
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
                return null;
            }
        }

        public void Update(TeamMember item)
        {
            try
            {
                if (item == null) return;
                var obj = _dbContext.TeamMembers.Update(item);
                if (obj != null) _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
            }
        }

        public void Delete(TeamMember item)
        {
            try
            {
                if (item == null) return;
                var obj = _dbContext.TeamMembers.Remove(item);
                if (obj == null) return;
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
            }
        }
    }
}