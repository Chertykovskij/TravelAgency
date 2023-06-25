using Microsoft.EntityFrameworkCore;
using TravelAgency.Data.Repository.InterfacesRepo;
using TravelAgency.Data.SelectListItems;
using TravelAgency.Data.ViewModels;
using TravelAgency.Models;

namespace TravelAgency.Data.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly TravelAgencyContext _context;

        /// <summary>
        /// Инициализация контекста БД для работы с данными
        /// </summary>
        public TourRepository(TravelAgencyContext context) { _context = context; }




        #region Добавление

        public async Task AddAsync(Tour tour, int[] includedServices, int[] notIncludedServices)
        {
            // Создаем новый экземпляр Тур, добавляем в него
            // свойства по ID свойств из полученного экземпляра
            Tour newTour = new Tour();

            newTour.PhotoUrl = tour.PhotoUrl;

            newTour.Title = tour.Title;
            newTour.Price = tour.Price;
            newTour.Duration = tour.Duration;
            newTour.Hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == tour.HotelId)!;

            // Добавляем в создаваемый экземпляр из полученных массивов услуги турагениства
            if (includedServices != null)
            {
                foreach (var c in _context.TravelService.Where(co => includedServices.Contains(co.Id)))
                {
                    newTour.IncludedServices.Add(c);
                }
            }

            if (notIncludedServices != null)
            {
                foreach (var c in _context.TravelService.Where(co => notIncludedServices.Contains(co.Id)))
                {
                    newTour.NotIncludedServices.Add(c);
                }
            }

            await _context.Tours.AddAsync(newTour);
            await _context.SaveChangesAsync();
        }

        #endregion


        #region Удаление

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Tours.FirstOrDefaultAsync(co => co.Id == id);

            if (item != null)
            {
                _context.Tours.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        #endregion


        #region Получение списка элементов

        public async Task<List<Tour>> GetAllAsync()
        {
            return await _context.Tours.Include(h  => h.Hotel).ToListAsync();
        }

        #endregion


        #region Получение представление модели для добавления

        public async Task<TourViewModel> GetByTourViewModelAsync()
        {
            var tour = new TourViewModel
            {
                ListHotel = await GetSelectListItems.GetHotelsAsync(_context),
                IncludedServices = await _context.TravelService.ToListAsync(),
                NotIncludedServices = await _context.TravelService.ToListAsync(),
                Tour = new Tour()
            };

            return tour;
        }

        #endregion


        #region Получение элемента

        public async Task<TourViewModel> GetByIdAsync(int id)
        {            
            var item = await _context.Tours.Include(f => f.IncludedServices)
                .Include(f => f.NotIncludedServices)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (item == null)
            {
                var tourNull = new TourViewModel();

                return tourNull;
            }
            else
            {
                var tour = new TourViewModel
                {
                    ListHotel = await GetSelectListItems.GetHotelsAsync(_context),
                    IncludedServices = await _context.TravelService.ToListAsync(),
                    NotIncludedServices = await _context.TravelService.ToListAsync(),
                    Tour = item
                };

                return tour;
            }            
        }

        #endregion


        #region Редактирование

        public async Task UpdateAsync(Tour tour, int[] includedServices, int[] notIncludedServices)
        {
            var newTour = await _context.Tours
                                    .Include(i => i.IncludedServices)
                                    .Include(n => n.NotIncludedServices)
                                    .FirstOrDefaultAsync(t => t.Id == tour.Id);

            newTour.PhotoUrl = tour.PhotoUrl!;
            newTour.Title = tour.Title;
            newTour.Price = tour.Price;
            newTour.Duration = tour.Duration;
            newTour.HotelId = tour.HotelId;

            newTour.IncludedServices.Clear();
            newTour.NotIncludedServices.Clear();

            // Добавляем в создаваемый экземпляр из полученных массивов услуги турагениства
            if (includedServices != null)
            {
                foreach (var c in _context.TravelService.Where(co => includedServices.Contains(co.Id)))
                {
                    newTour.IncludedServices.Add(c);
                }
            }

            if (notIncludedServices != null)
            {
                foreach (var c in _context.TravelService.Where(co => notIncludedServices.Contains(co.Id)))
                {
                    newTour.NotIncludedServices.Add(c);
                }
            }

            _context.Entry(newTour).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
