using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Data.Base;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    [Authorize]
    public class CityController : Controller
    {
        private readonly IEntityBaseRepository<City> _rep;

        public CityController(IEntityBaseRepository<City> rep)
        {
            _rep = rep;
        }

        public async Task<IActionResult> Index()
        {
            var allCities = await _rep.GetAllAsync();
            return View(allCities);
        }

        #region Добавление

        public IActionResult Create() 
        { 
            return View(new City());
        }

        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            if (city == null)
            {
                return View(city);
            }
            else
            {
                await _rep.AddAsync(city);
                return RedirectToAction(nameof(Index));
            }
        }

        #endregion

        #region Просмотр элемента

        public async Task<IActionResult> Details(int id)
        {
            var item = await _rep.GetByIdAsync(id);

            if(item == null) return View("Empty");

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
        public async Task<IActionResult> Edit(City city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }
            else
            {
                await _rep.UpdateAsync(city);
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
