using TravelAgency.Data.ViewModels;
using TravelAgency.Models;

namespace TravelAgency.Data.Repository.InterfacesRepo
{
    public interface ITourRepository
    {
        /// <summary>
        /// Получение списка элементов
        /// </summary>
        Task<List<Tour>> GetAllAsync();

        /// <summary>
        /// Получение элемента по идентификатору
        /// </summary>
        Task<TourViewModel> GetByIdAsync(int id);

        /// <summary>
        /// Добавление элемента
        /// </summary>
        Task AddAsync(Tour tour, int[] includedServices, int[] notIncludedServices);

        /// <summary>
        /// Изменение данных элемента
        /// </summary>
        Task UpdateAsync(Tour tour, int[] includedServices, int[] notIncludedServices);

        /// <summary>
        /// Удаление элемента
        /// </summary>
        Task DeleteAsync(int id);

        /// <summary>
        /// Получение представления тура для добавления
        /// </summary>
        Task<TourViewModel> GetByTourViewModelAsync();
    }
}
