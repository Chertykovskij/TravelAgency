using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TravelAgency.Data.Base;

namespace TravelAgency.Models
{
    public class CustomerRequest : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя клиента
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Ваше имя")]
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Телефон клиента
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Номер телефона для связи")]
        [RegularExpression(@"^89\d{9}$", ErrorMessage = "Не коррктный ввод номера телефона")]
        public string PhoneName { get; set; } = string.Empty;

        /// <summary>
        /// Дата и время обращения клиента
        /// </summary>
        [Display(Name = "Время обращения")]
        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Статус заявки (обработана/необработана)
        /// </summary>
        [Range(0, 1)]
        public int Status { get; set; } = 0;

        /// <summary>
        /// Тур выбранный клиентом
        /// </summary>
        [Display(Name = "Тур")]
        public int TourlId { get; set; }
        [Display(Name = "Тур")]
        public Tour Tour { get; set; } = new();
    }
}
