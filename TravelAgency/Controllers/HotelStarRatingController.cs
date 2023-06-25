using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Data.Base;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    [Authorize]
    public class HotelStarRatingController : Controller
    {
        private readonly IEntityBaseRepository<HotelStarRating> _rep;

        public HotelStarRatingController(IEntityBaseRepository<HotelStarRating> rep)
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
            return View(new HotelStarRating());
        }

        [HttpPost]
        public async Task<IActionResult> Create(HotelStarRating hotelStarRating)
        {
            if (hotelStarRating == null)
            {
                return View(hotelStarRating);
            }
            else
            {
                await _rep.AddAsync(hotelStarRating);
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
        public async Task<IActionResult> Edit(HotelStarRating hotelStarRating)
        {
            if (!ModelState.IsValid)
            {
                return View(hotelStarRating);
            }
            else
            {
                await _rep.UpdateAsync(hotelStarRating);
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
