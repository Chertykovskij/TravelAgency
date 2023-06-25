using System.ComponentModel.DataAnnotations;
using TravelAgency.Data.Base;

namespace TravelAgency.Models
{
    /// <summary>
    /// Услуги и удобства в отеле
    /// </summary>
    public class HotelFacility : IEntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(100)]
        [Display(Name = "Услуги и удобства в отеле")]
        public string Name { get; set; } = string.Empty;

        public List<Hotel> Hotels { get; set; } = new();
    }
}
