using Microsoft.EntityFrameworkCore;
using TravelAgency.Data.Repository.InterfacesRepo;
using TravelAgency.Data.SelectListItems;
using TravelAgency.Data.ViewModels;
using TravelAgency.Models;

namespace TravelAgency.Data.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly TravelAgencyContext _context;

        /// <summary>
        /// Инициализация контекста БД для работы с данными
        /// </summary>
        public HomeRepository(TravelAgencyContext context) { _context = context; }

        #region Получение списка

        public async Task<List<Tour>> GetAllAsync()
        {
            return await _context.Tours.Include(h => h.Hotel)
                                            .ThenInclude(s => s.HotelStarRating)
                                        .Include(h => h.Hotel)
                                            .ThenInclude(m => m.MealType)
                                        .ToListAsync();
        }

        #endregion


        #region Получение элемента

        public async Task<Tour> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                var tour = new Tour();

                return tour;
            }
            else
            {
                var tour = await _context.Tours.Include(f => f.IncludedServices)
                                                .Include(f => f.NotIncludedServices)
                                                .Include(h => h.Hotel)
                                                    .ThenInclude(s => s.HotelStarRating)
                                                .Include(h => h.Hotel)
                                                    .ThenInclude(m => m.MealType)
                                                    .Include(h => h.Hotel)
                                                    .ThenInclude(r => r.RoomAmenity)
                                                .Include(h => h.Hotel)
                                                    .ThenInclude(f => f.HotelFacility)
                                                .FirstOrDefaultAsync(h => h.Id == id);

                
                return tour!;
                
            }
        }

        #endregion


        #region Добавление заявки

        public async Task AddRequestAsync(CustomerRequest request, int id)
        {
            var req = new CustomerRequest()
            {
                CustomerName = request.CustomerName,
                PhoneName = request.PhoneName,
                TourlId = id,
                Tour = await _context.Tours.FirstOrDefaultAsync(f => f.Id == id)!
            };
            
            await _context.CustomerRequests.AddAsync(req);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
