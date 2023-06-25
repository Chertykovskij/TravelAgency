namespace TravelAgency.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase
    {
        /// <summary>
        /// Получение списка элементов
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Получение элемента по идентификатору
        /// </summary>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Добавление элемента
        /// </summary>
        Task AddAsync(T entity);

        /// <summary>
        /// Изменение данных элемента
        /// </summary>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Удаление элемента
        /// </summary>
        Task DeleteAsync(int id);
    }
}
