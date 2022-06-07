using CourseTaskOOP.DAL.Data;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<TeamMember>?> GetAllAsync()
        {
            try
            {
                var obj = await _dbContext.TeamMembers.ToListAsync();
                return obj ?? null;
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
                return null;
            }
        }

        public async Task<TeamMember?> GetByIdAsync(int id)
        {
            try
            {
                if (id == null) return null;

                var obj = await _dbContext.TeamMembers.FirstOrDefaultAsync(u => u.Id == id);
                return obj ?? null;
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
                return null;
            }
        }

        public async Task<List<TeamMember>> FindAsync(Func<TeamMember, bool> predicate)
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

        public async Task<TeamMember> CreateAsync(TeamMember item)
        {
            try
            {
                if (item == null) return null;
                var obj = await _dbContext.TeamMembers.AddAsync(item);
                await _dbContext.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
                return null;
            }
        }

        public async Task UpdateAsync(TeamMember item)
        {
            try
            {
                if (item == null) return;
                var obj = _dbContext.TeamMembers.Update(item);
                if (obj != null) await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
            }
        }

        public async Task DeleteAsync(TeamMember item)
        {
            try
            {
                if (item == null) return;
                var obj = _dbContext.TeamMembers.Remove(item);
                if (obj == null) return;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
            }
        }
    }
}