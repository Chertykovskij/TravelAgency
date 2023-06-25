using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TravelAgency.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase
    {
        private readonly TravelAgencyContext _context;

        /// <summary>
        /// Инициализация контекста БД для работы с данными
        /// </summary>
        public EntityBaseRepository(TravelAgencyContext context) { _context = context; }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Set<T>().FindAsync(id); // находим объект по идентификатору
            if (item != null)
            {
                _context.Set<T>().Remove(item); // удаляем объект из контекста
                await _context.SaveChangesAsync(); // сохраняем изменения в базе данных
            }
                //var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                //if (entity != null) 
                //{ 
                //    EntityEntry entityEntry = _context.Entry<T>(entity);
                //    entityEntry.State = EntityState.Deleted;
                //    await _context.SaveChangesAsync();
                //}            
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task UpdateAsync(T entity)
        {
            if (entity != null)
            {
                EntityEntry entityEntry = _context.Entry<T>(entity);
                entityEntry.State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
