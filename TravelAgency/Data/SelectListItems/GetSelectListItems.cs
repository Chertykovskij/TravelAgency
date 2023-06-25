using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Data.SelectListItems
{
    public static class GetSelectListItems
    {
        /// <summary>
        /// Получение SelectListItem списка варианотов количества звезд отеля
        /// </summary>
        /// <param name="_context">Контекст БД</param>
        /// <returns>SelectListItem</returns>
        public static async Task<List<SelectListItem>> GetHotelStarsRating(TravelAgencyContext _context)
        {
            var items = await _context.HotelStarRating.ToListAsync();


            var listItems = items.Select(item => new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = item.Stars.ToString()
            }).ToList();


            return listItems;
        }

        /// <summary>
        /// Получение SelectListItem списка варианотов типов питания в отеле
        /// </summary>
        /// <param name="_context">Контекст БД</param>
        /// <returns>SelectListItem</returns>
        public static async Task<List<SelectListItem>> GetMealType(TravelAgencyContext _context)
        {
            var listItems = new List<SelectListItem>();

            var items = await _context.MealTypes.ToListAsync();


            listItems = items.Select(item => new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = item.Type.ToString()
            }).ToList();

            return listItems;
        }

        /// <summary>
        /// Получение SelectListItem списка варианотов услуг отеля
        /// </summary>
        /// <param name="_context">Контекст БД</param>
        /// <returns>SelectListItem</returns>
        public static async Task<List<SelectListItem>> GetHotelFacility(TravelAgencyContext _context)
        {
            var listItems = new List<SelectListItem>();

            var items = await _context.HotelFacility.ToListAsync();


            listItems = items.Select(item => new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = item.Name.ToString()
            }).ToList();


            return listItems;
        }

        /// <summary>
        /// Получение SelectListItem списка варианотов оснащения номеров отеля
        /// </summary>
        /// <param name="_context">Контекст БД</param>
        /// <returns>SelectListItem</returns>
        public static async Task<List<SelectListItem>> GetRoomAmenity(TravelAgencyContext _context)
        {
            var listItems = new List<SelectListItem>();

            var items = await _context.RoomAmenity.ToListAsync();


            listItems = items.Select(item => new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = item.Name.ToString()
            }).ToList();


            return listItems;
        }

        /// <summary>
        /// Получение SelectListItem списка городов
        /// </summary>
        /// <param name="_context">Контекст БД</param>
        /// <returns>SelectListItem</returns>
        public static async Task<List<SelectListItem>> GetCities(TravelAgencyContext _context)
        {
            var items = await _context.Cities.ToListAsync();


            var listItems = items.Select(item => new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = item.Name.ToString()
            }).ToList();

            //var defItem = new SelectListItem()
            //{
            //    Value = "",
            //    Text = "Города"
            //};

            //listItems.Insert(0, defItem);

            return listItems;
        }

        /// <summary>
        /// Получение SelectListItem списка отелей
        /// </summary>
        /// <param name="_context">Контекст БД</param>
        /// <returns>SelectListItem</returns>
        public static async Task<List<SelectListItem>> GetHotelsAsync(TravelAgencyContext _context)
        {
            var items = await _context.Hotels.ToListAsync()!;


            var listItems = items.Select(item => new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = item.Name.ToString()
            }).ToList();

            return listItems;
        }
    }
}
