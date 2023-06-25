using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using X.PagedList;

namespace TravelAgency.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RequestsController : Controller
    {
        private readonly TravelAgencyContext _context;

        public RequestsController(TravelAgencyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? pageNumber, int pageSize = 25)
        {
            int countRequestsNoResponse = _context.CustomerRequests.Count(s => s.Status == 0);
            ViewBag.Count = countRequestsNoResponse;

            var items = await _context.CustomerRequests
                               .Include(t => t.Tour)
                               .ThenInclude(h => h.Hotel)
                               .OrderByDescending(t => t.ApplicationDate)
                               .ToPagedListAsync(pageNumber, pageSize);

            ViewBag.PageSize = pageSize;

            //var items = await _context.CustomerRequests
            //                            .Include(t => t.Tour)
            //                                .ThenInclude(h => h.Hotel)
            //                            .OrderByDescending(t => t.ApplicationDate)
            //                            .ToListAsync();

            //// создание объекта типа IPagedList для пейджинга
            //var pagedRequests = await items.ToPagedListAsync(pageNumber ?? 1, pageSize);

            //// передача объекта IPagedList в представление для отображения
            //return View(pagedRequests);

            return View(items);
        }


        public async Task<IActionResult> Details(int id)
        {
            var item = await _context.CustomerRequests
                                        .Include(t => t.Tour)
                                            .ThenInclude(h => h.Hotel)
                                                .ThenInclude(c => c.City)
                                        .Include(t => t.Tour)
                                            .ThenInclude(h => h.Hotel)
                                                .ThenInclude(c => c.HotelStarRating)
                                        .Include(t => t.Tour)
                                            .ThenInclude(h => h.Hotel)
                                                .ThenInclude(c => c.MealType)
                                        .Include(t => t.Tour)
                                            .ThenInclude(h => h.IncludedServices)
                                        .Include(t => t.Tour)
                                            .ThenInclude(h => h.NotIncludedServices)
                                        .FirstOrDefaultAsync(r => r.Id == id);

            return View(item);
        }

        //[HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.CustomerRequests.FirstOrDefaultAsync(r => r.Id == id);

            if (item == null)
                return View("Empty");
            else
            {
                item.Status = 1;
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }            
        }
    }
}
