using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Data.Base;

namespace TravelAgency.Models
{
    /// <summary>
    /// Отель
    /// </summary>
    public class Hotel : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование отеля
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(50)]
        [Display(Name = "Название отеля")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Город")]
        [ForeignKey("Cities")]
        public int CityId { get; set; }
        [Display(Name = "Город")]
        public virtual City City { get; set; } = new City();

        /// <summary>
        /// Количество звезд
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Количество звёзд")]
        public int HotelStarRatingId { get; set; }

        [Display(Name = "Звёзд")]
        public virtual HotelStarRating HotelStarRating { get; set; } = new HotelStarRating();

        /// <summary>
        /// Тип питания
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Питание")]
        public int MealTypeId { get; set; }

        [Display(Name = "Тип питания")]
        public virtual MealType MealType { get; set; } = new MealType();

        /// <summary>
        /// Услуги и удобства в отеле
        /// </summary>
        //[Required(ErrorMessage = "Поле должно быть заполнено")]
        //public int HotelFacilityId { get; set; }

        [Display(Name = "Услуги и удобства в отеле")]
        public List<HotelFacility> HotelFacility { get; set; } = new();

        /// <summary>
        /// Оснащение номера в отеле
        /// </summary>
        //[Required(ErrorMessage = "Поле должно быть заполнено")]
        //public int RoomAmenityId { get; set; }

        [Display(Name = "Оснащение номера в отеле")]
        public List<RoomAmenity> RoomAmenity { get; set; } = new();

        public List<Tour> Tour { get; set; } = new();
    }
}
