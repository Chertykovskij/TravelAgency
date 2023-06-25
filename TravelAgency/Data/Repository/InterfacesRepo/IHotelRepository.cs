using TravelAgency.Data.ViewModels;
using TravelAgency.Models;

namespace TravelAgency.Data.Repository.InterfacesRepo
{
    public interface IHotelRepository
    {
        /// <summary>
        /// Получение списка элементов
        /// </summary>
        Task<List<Hotel>> GetAllAsync();

        /// <summary>
        /// Получение элемента по идентификатору
        /// </summary>
        Task<HotelViewModel> GetByIdAsync(int? id);

        /// <summary>
        /// Добавление элемента
        /// </summary>
        Task AddAsync(Hotel entity, int[] HotelFacility, int[] roomAmenity);

        /// <summary>
        /// Изменение данных элемента
        /// </summary>
        Task UpdateAsync(Hotel entity, int[] hotelFacility, int[] roomAmenity);

        /// <summary>
        /// Удаление элемента
        /// </summary>
        Task DeleteAsync(int id);
    }
}
