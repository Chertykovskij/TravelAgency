using TravelAgency.Data.ViewModels;
using TravelAgency.Models;

namespace TravelAgency.Data.Repository.InterfacesRepo
{
    public interface IHomeRepository
    {
        /// <summary>
        /// Получение списка элементов
        /// </summary>
        Task<List<Tour>> GetAllAsync();

        /// <summary>
        /// Получение элемента по идентификатору
        /// </summary>
        Task<Tour> GetByIdAsync(int? id);

        /// <summary>
        /// Добавление заявки на обработку
        /// </summary>
        public Task AddRequestAsync(CustomerRequest request, int id);
    }
}
