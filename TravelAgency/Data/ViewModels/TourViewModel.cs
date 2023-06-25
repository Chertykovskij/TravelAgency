using TravelAgency.Models;

namespace TravelAgency.Data.ViewModels
{
    public class TourViewModel
    {
        public Tour Tour { get; set; } = null!;

        /// <summary>
        /// Для вывода SelectListItem отели в представление
        /// </summary>
        public object ListHotel { get; set; } = new List<Hotel>();

        /// <summary>
        /// Для вывода SelectListItem города в представление
        /// </summary>
        public object ListCities { get; set; } = new List<City>();

        /// <summary>
        /// Услуги входящие в стоимость тура
        /// </summary>
        public List<TravelService> IncludedServices { get; set; } = new List<TravelService>();

        /// <summary>
        /// Услуги оплачевыемые отдельно
        /// </summary>
        public List<TravelService> NotIncludedServices { get; set; } = new List<TravelService>();
    }
}
