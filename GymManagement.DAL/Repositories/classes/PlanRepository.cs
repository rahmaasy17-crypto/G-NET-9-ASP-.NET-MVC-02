using GymManagement.DAL.Repositories.interfaces;
using GymManagement.DBContexts;
using GymManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Repositories.classes
{
    //LINQ queries > no Code Duplication
    //Repository Pattern
    public class PlanRepository : IPlanRepository
    {
        private readonly GymDbContext dbContext;
        public PlanRepository(GymDbContext gymDbContext)
        {
            dbContext = gymDbContext;
        }
        public async Task<int> AddAsync(Plan plan, CancellationToken c = default)
        {
            dbContext.plans.Add(plan);
            return await dbContext.SaveChangesAsync(c);    
        }

        public async Task<int> DeleteAsync(Plan plan, CancellationToken c = default)
        {
            dbContext.plans.Remove(plan);
            return await dbContext.SaveChangesAsync(c);

        }

        public async Task<IEnumerable<Plan>> GetAllPlansAsync(bool tracking = false, CancellationToken c = default)
        {
            if (tracking)
            {
                return await dbContext.plans.ToListAsync();
            }
            else return await dbContext.plans.AsNoTracking().ToListAsync();
            //IQueryable<Plan> query =tracking? dbContext.plans: dbContext.plans.AsNoTracking();
            //return await query.ToListAsync();
        }

        public async Task<Plan?> GetPlanByIDAsync(int id, CancellationToken c = default)
        {
            return await dbContext.plans.FindAsync(id, c);
        }

        public async Task<int> UpdateAsync(Plan plan, CancellationToken c = default)
        {
            dbContext.plans.Update(plan);
            return await dbContext.SaveChangesAsync(c); 
        }
    }
}
