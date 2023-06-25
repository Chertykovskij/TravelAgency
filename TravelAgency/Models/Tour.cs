using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Data.Base;

namespace TravelAgency.Models
{
    /// <summary>
    /// Тур
    /// </summary>
    public class Tour : IEntityBase
    {
        public int Id { get; set; }

        #region Изображение

        public string PhotoUrl { get; set; } = "noimages.jpg";

        [NotMapped]
        [Display(Name = "Изображение")]
        public IFormFile? TourPhoto { get;set; }

        #endregion

        /// <summary>
        /// Заголовок(наименование)
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Название")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Стоимость тура
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Стоимость")]
        [Range(1000, 1000000, ErrorMessage = "Слишком маленькое значение")]
        public int Price { get; set; }

        /// <summary>
        /// Продолжительность тура
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Продолжительность")]
        [Range(2, 30, ErrorMessage = "Не корректное значение")]
        public int Duration { get; set; }


        /// <summary>
        /// Услуги входящие в стоимость тура
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public virtual List<TravelService> IncludedServices { get; set; } = new();

        /// <summary>
        /// Услуги оплачиваемые дополнительно
        /// </summary>
        public virtual List<TravelService> NotIncludedServices { get; set; } = new();

        /// <summary>
        /// Отель
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Отель")]
        public int HotelId { get;set; }
        [Display(Name = "Отель")]
        public Hotel Hotel { get;set; } = new();

        /// <summary>
        /// Количество заявок на тур
        /// </summary>
        public virtual List<CustomerRequest> CustomerRequests { get; set; } = new();
    }
}
