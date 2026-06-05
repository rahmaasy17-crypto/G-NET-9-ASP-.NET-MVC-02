using GymManagement.DBContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GymManagement.Controllers
{
    public class PlansController : Controller
    {
        private readonly GymDbContext dbContext;
        public PlansController() {
        dbContext = new GymDbContext();
        }
        // Index Action >> GET BaseUrL/Plans/Index ==Listing ALL Plans 
        //get all plans data and send it to view
        public async Task<IActionResult> Index()
        {
            var plans =await dbContext.plans.ToListAsync();
            return View(plans);
        }
        // Details action>> Get BaseUrL/PLans/Details/ id 
        public async Task<IActionResult> Details(int id)
        {
            var plan = await dbContext.plans.FindAsync(id);
            if (plan is null) return RedirectToAction(nameof(Index));
          else
            return View(plan);
        }
    }
}
