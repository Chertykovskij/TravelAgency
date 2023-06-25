using Microsoft.EntityFrameworkCore;
using TravelAgency.Data.Repository.InterfacesRepo;
using TravelAgency.Data.SelectListItems;
using TravelAgency.Data.ViewModels;
using TravelAgency.Models;

namespace TravelAgency.Data.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly TravelAgencyContext _context;

        /// <summary>
        /// Инициализация контекста БД для работы с данными
        /// </summary>
        public HotelRepository(TravelAgencyContext context) { _context = context; }


        #region Добавление 

        public async Task AddAsync(Hotel entity, int[] hotelFacility, int[] roomAmenity)
        {
            // Создаем новый экземпляр Отель, добавляем в него
            // свойства по ID свойств из полученного экземпляра
            Hotel newHotel = new Hotel();
            newHotel.Name = entity.Name;
            newHotel.City = _context.Cities.FirstOrDefault(c => c.Id == entity.CityId)!;
            newHotel.HotelStarRating = _context.HotelStarRating
                                        .FirstOrDefault(c => c.Id == entity.HotelStarRatingId)!;
            newHotel.MealType = _context.MealTypes
                                        .FirstOrDefault(c => c.Id == entity.MealTypeId)!;

            // Добавляем в создаваемый экземпляр из полученных массивов услуги и оснащение номера
            if (hotelFacility != null)
            {
                //получаем выбранные услуги отеля
                foreach (var c in _context.HotelFacility.Where(co => hotelFacility.Contains(co.Id)))
                {
                    newHotel.HotelFacility.Add(c);
                }
            }

            if (roomAmenity != null)
            {
                //получаем оснащение номера
                foreach (var c in _context.RoomAmenity.Where(co => roomAmenity.Contains(co.Id)))
                {
                    newHotel.RoomAmenity.Add(c);
                }
            }

            await _context.Hotels.AddAsync(newHotel);
            await _context.SaveChangesAsync();
        }

        #endregion


        #region Удаление
        public async Task DeleteAsync(int id)
        {
            var item = await _context.Hotels.FirstOrDefaultAsync(co => co.Id == id);

            if (item != null)
            {
                _context.Hotels.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        #endregion


        #region Получение списка

        public async Task<List<Hotel>> GetAllAsync()
        {
            return await _context.Hotels.Include(c => c.City)
                .Include(s => s.HotelStarRating)
                .Include(m => m.MealType)
                .ToListAsync();
        }

        #endregion


        #region Получение элемента

        public async Task<HotelViewModel> GetByIdAsync(int? id)
        {
            if (id == null) 
            {
                var hotel = new HotelViewModel
                {
                    HotelFacility = await _context.HotelFacility.ToListAsync(),
                    RoomAmenity = await _context.RoomAmenity.ToListAsync(),
                    ListCities = await GetSelectListItems.GetCities(_context),
                    ListHotelStarRating = await GetSelectListItems.GetHotelStarsRating(_context),
                    ListMealTypes = await GetSelectListItems.GetMealType(_context),
                    Hotel = new Hotel()
                };

                return hotel;
            }
            else
            {
                var item = await _context.Hotels.Include(f => f.HotelFacility)
                    .Include(f => f.RoomAmenity)
                    .FirstOrDefaultAsync(h => h.Id == id);      

                if (item == null)
                {
                    var hotelNull = new HotelViewModel();

                    return hotelNull;
                }
                else
                {
                    var hotel = new HotelViewModel
                    {
                        //Cities = await _context.Cities.ToListAsync(),
                        //HotelStarRating = await _context.HotelStarRating.ToListAsync(),
                        //MealTypes = await _context.MealTypes.ToListAsync(),
                        HotelFacility = await _context.HotelFacility.ToListAsync(),
                        RoomAmenity = await _context.RoomAmenity.ToListAsync(),
                        ListCities = await GetSelectListItems.GetCities(_context),
                        ListHotelStarRating = await GetSelectListItems.GetHotelStarsRating(_context),
                        ListMealTypes = await GetSelectListItems.GetMealType(_context),
                        Hotel = item
                    };

                    return hotel;
                }                
            }            
        }

        #endregion


        #region Редактирование

        public async Task UpdateAsync(Hotel entity, int[] hotelFacility, int[] roomAmenity)
        {
            var newHotel = await _context.Hotels
                                .Include(hF => hF.HotelFacility)
                                .Include(rA => rA.RoomAmenity)
                                .FirstOrDefaultAsync(h => h.Id == entity.Id);
            newHotel!.Name = entity.Name;
            newHotel.CityId = entity.CityId;
            newHotel.HotelStarRatingId = entity.HotelStarRatingId;
            newHotel.MealTypeId = entity.MealTypeId;

            newHotel.HotelFacility.Clear();
            newHotel.RoomAmenity.Clear();

            if (hotelFacility != null)
            {
                // получаем выбранные услуги отеля
                foreach (var h in _context.HotelFacility.Where(fh => hotelFacility.Contains(fh.Id)))
                {
                    newHotel.HotelFacility.Add(h);
                }
            }
            if (roomAmenity != null)
            {
                // получаем оснащение номера
                foreach (var h in _context.RoomAmenity.Where(rA => roomAmenity.Contains(rA.Id)))
                {
                    newHotel.RoomAmenity.Add(h);
                }
            }

            _context.Entry(newHotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
