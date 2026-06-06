using GymManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Repositories.interfaces
{
    public interface IPlanRepository
    {
        // add what controller can do on plan dbset
        // do CRAD operations
        Task<IEnumerable<Plan>> GetAllPlansAsync(bool tracking=false ,CancellationToken c=default);
        Task<Plan?> GetPlanByIDAsync(int id, CancellationToken c = default);
        // return number of effected rows
        Task<int> AddAsync(Plan plan, CancellationToken c = default);
        Task<int>UpdateAsync(Plan plan, CancellationToken c = default);

        Task<int> DeleteAsync(Plan plan, CancellationToken c = default);


    }
}
