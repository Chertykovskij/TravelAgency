using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Data.Repository;
using TravelAgency.Data.Repository.InterfacesRepo;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    [Authorize]
    public class TourController : Controller
    {
        private readonly IWebHostEnvironment _webHost;

        private readonly ITourRepository _repository;

        public TourController(ITourRepository repository, 
                                IWebHostEnvironment webHost)
        {
            _repository = repository;
            _webHost = webHost;

        }
        
        public async Task<IActionResult> Index()
        {
            var items = await _repository.GetAllAsync();
            return View(items);
        }

        #region Добавление

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var tour = await _repository.GetByTourViewModelAsync();

            ViewBag.Hotel = tour.ListHotel;
            ViewBag.IncludedServices = tour.IncludedServices;
            ViewBag.NotIncludedServices = tour.NotIncludedServices;


            return View(tour.Tour);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tour tour, int[] includedServices, int[] notIncludedServices)
        {
            if (tour == null)
            {
                return View(tour);
            }
            else
            {
                string uniqueFileName = GetUploadedFileName(tour);
                if(uniqueFileName != null) { tour.PhotoUrl = uniqueFileName; }
                
                await _repository.AddAsync(tour, includedServices, notIncludedServices);
                return RedirectToAction(nameof(Index));
            }
        }

        #endregion


        #region Просмотр

        public async Task<IActionResult> Details(int id)
        {
            var item = await _repository.GetByIdAsync(id);

            if (item.Tour == null) return View("Empty");

            return View(item.Tour);
        }

        #endregion


        #region Удаление

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _repository.GetByIdAsync(id);

            if (item.Tour == null) return View("Empty");

            return View(item.Tour);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return View("Empty");

            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion


        #region Редактирование  

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var tour = await _repository.GetByIdAsync(id);

            if (tour.Tour == null) return View("Empty");

            ViewBag.Hotel = tour.ListHotel;
            ViewBag.IncludedServices = tour.IncludedServices;
            ViewBag.NotIncludedServices = tour.NotIncludedServices;
            
            return View(tour.Tour);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tour tour, int[] includedServices, int[] notIncludedServices)
        {
            string uniqueFileName = GetUploadedFileName(tour);
            if (uniqueFileName != null) { tour.PhotoUrl = uniqueFileName; }

            await _repository.UpdateAsync(tour, includedServices, notIncludedServices);
            return RedirectToAction(nameof(Index));
        }

        #endregion


        #region Добавление файла изображения

        private string GetUploadedFileName(Tour tour)
        {
            string? uniqueFileName = null;

            if(tour.TourPhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "images");
                uniqueFileName = string.Concat(Guid.NewGuid().ToString(),"_",tour.TourPhoto.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    tour.TourPhoto.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        #endregion

    }
}
