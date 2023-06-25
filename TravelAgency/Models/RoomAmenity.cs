using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TravelAgency.Data.Base;

namespace TravelAgency.Models
{
    /// <summary>
    /// Оснащение номера отеля
    /// </summary>
    public class RoomAmenity : IEntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Оснащение номера")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public List<Hotel> Hotels { get; set; } = new();
    }
}
