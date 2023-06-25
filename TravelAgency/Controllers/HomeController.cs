using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelAgency.Data.Repository.InterfacesRepo;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHomeRepository _repository;

        public HomeController(IHomeRepository rep, ILogger<HomeController> logger)
        {
            _repository = rep;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _repository.GetAllAsync();
            return View(items);
        }



        #region Details

        public async Task<IActionResult> Details(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return View(item);
        }

        #endregion


        #region AddRequest

        public IActionResult AddRequest(int id)
        {
            var request = new CustomerRequest();
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest(CustomerRequest request, int id)
        {
            await _repository.AddRequestAsync(request, id);
            return View("RequestNoted");
        }

        #endregion


        public IActionResult AboutUs()
        {
            return View("AboutUs");
        }

        public IActionResult Contacts()
        {
            return View("Contacts");
        }
        public IActionResult ListServices()
        {
            return View("ListServices");
        }
    }
}
