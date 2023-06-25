using System.ComponentModel.DataAnnotations;
using TravelAgency.Data.Base;

namespace TravelAgency.Models
{
    /// <summary>
    /// Количество звезд отеля
    /// </summary>
    public class HotelStarRating : IEntityBase
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Звёзд")]
        [Range(0, 5, ErrorMessage = "Недопустимое значение (0-5*)")]
        public int Stars { get; set; } = 0;

        public List<Hotel> Hotels { get; set; } = new();
    }
}
