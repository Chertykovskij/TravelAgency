using System.ComponentModel.DataAnnotations;
using TravelAgency.Data.Base;

namespace TravelAgency.Models
{
    /// <summary>
    /// Тип питания
    /// </summary>
    public class MealType : IEntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Тип питания")]
        public string Type { get; set; } = string.Empty;

        public List<Hotel> Hotels { get; set; } = new();
    }
}
