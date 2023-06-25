using System.ComponentModel.DataAnnotations;
using TravelAgency.Data.Base;

namespace TravelAgency.Models
{
    /// <summary>
    /// Населенный пункт
    /// </summary>
    public class City : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// Населенный пункт
        /// </summary>
        [Required(ErrorMessage = "Не указано наименование")]
        [StringLength(50, ErrorMessage = "Недопустимая длина имени")]
        [Display(Name = "Наименование")]
        public string Name { get; set; } = string.Empty;


        public List<Hotel> Hotels { get; set; } = new();
    }
}
