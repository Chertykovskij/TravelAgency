using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Data.Base;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    [Authorize]
    public class TravelServiceController : Controller
    {
        private readonly IEntityBaseRepository<TravelService> _rep;

        public TravelServiceController(IEntityBaseRepository<TravelService> rep)
        {
            _rep = rep;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _rep.GetAllAsync();
            return View(items);
        }

        #region Добавление

        public IActionResult Create()
        {
            return View(new TravelService());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TravelService item)
        {
            if (item == null)
            {
                return View(item);
            }
            else
            {
                await _rep.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }
        }

        #endregion

        #region Просмотр элемента

        public async Task<IActionResult> Details(int id)
        {
            var item = await _rep.GetByIdAsync(id);

            if (item == null) return View("Empty");

            return View(item);
        }

        #endregion

        #region Редактирование  

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _rep.GetByIdAsync(id);

            if (item == null) return View("Empty");

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TravelService item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }
            else
            {
                await _rep.UpdateAsync(item);
            return RedirectToAction(nameof(Index));
            }
        }

        #endregion

        #region Удаление

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _rep.GetByIdAsync(id);

            if (item == null) return View("Empty");

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _rep.GetByIdAsync(id);
            if (item == null) return View("Empty");

            await _rep.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
