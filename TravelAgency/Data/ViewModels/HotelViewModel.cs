using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TravelAgency.Data.SelectListItems;
using TravelAgency.Models;

namespace TravelAgency.Data.ViewModels
{
    public class HotelViewModel
    {
        public Hotel Hotel { get; set; } = null!;

        //public List<City> Cities { get; set; }// = new List<City>();        
        //public List<HotelStarRating> HotelStarRating { get; set; } // = new List<HotelStarRating>();
        //public List<MealType> MealTypes { get; set; } //= new List<MealType>();
        public List<HotelFacility> HotelFacility { get; set; } = new List<HotelFacility>();
        public List<RoomAmenity> RoomAmenity { get; set; } = new List<RoomAmenity>();

        public object ListCities { get; set; } = new List<City>();
        public object ListHotelStarRating { get; set; } = new List<HotelStarRating>();
        public object ListMealTypes { get; set; } = new List<MealType>();
        //public object ListHotelFacility { get; set; } = new List<HotelFacility>();
        //public object ListRoomAmenity { get; set; } = new List<RoomAmenity>();
    }
}
