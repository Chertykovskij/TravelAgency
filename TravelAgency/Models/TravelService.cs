using System.ComponentModel.DataAnnotations;
using TravelAgency.Data.Base;

namespace TravelAgency.Models
{
    /// <summary>
    /// Услуги оказываемы туристической фирмой
    /// </summary>
    public class TravelService : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование услуги
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Услуга")]
        [StringLength(150, ErrorMessage = "Максимальное количество символов - 150")]
        public string Name { get; set; } = string.Empty;

        public virtual List<Tour> IncludedTours { get; set; } = new();
        public virtual List<Tour> NotIcludedTours { get; set; } = new();
    }
}
