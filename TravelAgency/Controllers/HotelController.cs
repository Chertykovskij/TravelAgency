using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using TravelAgency.Data;
using TravelAgency.Data.Repository.InterfacesRepo;
using TravelAgency.Data.SelectListItems;
using TravelAgency.Data.ViewModels;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository rep)
        {
            _hotelRepository = rep;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _hotelRepository.GetAllAsync();
            return View(items);
        }

        #region Добавление

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var hotel = await _hotelRepository.GetByIdAsync(null);

            ViewBag.HotelStarRating = hotel.ListHotelStarRating;
            ViewBag.MealType = hotel.ListMealTypes;
            ViewBag.HotelFacility = hotel.HotelFacility;
            ViewBag.RoomAmenity = hotel.RoomAmenity;
            ViewBag.City = hotel.ListCities;
            return View(hotel.Hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hotel item, int[] hotelFacility, int[] roomAmenity)
        {   
            if (item == null)
            {
                return View(item);
            }
            else
            {
                await _hotelRepository.AddAsync(item, hotelFacility, roomAmenity);
                return RedirectToAction(nameof(Index));
            }
        }

        #endregion

        #region Просмотр элемента

        public async Task<IActionResult> Details(int id)
        {
            var item = await _hotelRepository.GetByIdAsync(id);

            if (item.Hotel == null) return View("Empty");

            return View(item.Hotel);
        }

        #endregion

        #region Редактирование  

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);
        
            if (hotel.Hotel == null) return View("Empty");

            ViewBag.HotelStarRating = hotel.ListHotelStarRating;
            ViewBag.MealType = hotel.ListMealTypes;
            ViewBag.HotelFacility = hotel.HotelFacility!;
            ViewBag.RoomAmenity = hotel.RoomAmenity!;
            ViewBag.City = hotel.ListCities;

            return View(hotel.Hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Hotel item, int[] hotelFacility, int[] roomAmenity)
        {
                await _hotelRepository.UpdateAsync(item, hotelFacility, roomAmenity);
                return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Удаление

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _hotelRepository.GetByIdAsync(id);

            if (item.Hotel == null) return View("Empty");

            return View(item.Hotel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _hotelRepository.GetByIdAsync(id);
            if (item == null) return View("Empty");

            await _hotelRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        
    }
}
