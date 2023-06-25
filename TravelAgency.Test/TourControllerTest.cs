using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Controllers;
using TravelAgency.Data.Repository.InterfacesRepo;
using TravelAgency.Data.ViewModels;
using TravelAgency.Models;

namespace TravelAgency.Test
{
    public class TourControllerTest
    {
        // Тест должен быть асинхронным так как методы отробатывают асинхронно
        [Fact]
        public async Task Index_Returns_A_View_Result_With_A_List_Of_Tours()
        {
            // Arrange



            // Типизирует Mock тем что будем передовать в контроллер
            var mock = new Mock<ITourRepository>();
            var mockWebHost = new Mock<IWebHostEnvironment>();

            // Имитируется функциональность репозитория
            // Метод GetAllAsync() из репозитория вызывается в методе Setup
            // С помощью метода Returns определяем набор объектов возвращаемы методом GetAllAsync
            mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(GetTestTours());

            // Экземпляп TourController, передаём объекты Mock имитирующие принимаемые параметры
            var controller = new TourController(mock.Object, mockWebHost.Object);



            // Act


            // Получаем результат метода Index из контроллера
            var result = await controller.Index();



            // Assert


            // Тип возвращаемого значения метода Index в контроллере
            var viewResult = Assert.IsType<ViewResult>(result);
            // Тип модели передоваемого в представление из метода Index
            var model = Assert.IsType<List<Tour>>(viewResult.ViewData.Model);
            
        }


        //[Fact]
        //public async Task Add_User_Returns_View_Result_With_Tour_Model()
        //{
        //    // Arrange
        //    var mock = new Mock<ITourRepository>();
        //    var mockWebHost = new Mock<IWebHostEnvironment>();

        //    mock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
        //    .ReturnsAsync(new TourViewModel()
        //    {
        //        Tour = new Tour(),
        //        ListHotel = new object[] {},
        //        ListCities = new object[] { },
        //        IncludedServices = new List<TravelService>(),
        //        NotIncludedServices = new List<TravelService>()
        //    });

        //    var controller = new TourController(mock.Object, mockWebHost.Object);

        //    //controller.ModelState.AddModelError("Name", "Required");
        //    //Tour tour = new Tour()
        //    //{
        //    //    Title = "Test"
        //    //};

        //    // Act
        //    var result = await controller.Create();

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    //var model = Assert.IsType<Tour>(viewResult.ViewData.Model);
        //    //Assert.Equal(tour.Title, model.Title);
        //    //Assert.Equal(tour, viewResult?.Model);
        //}



        [Fact]
        public async Task Add_Tour_Returns_A_Redirect_And_Adds_Tour()
        {
            // Arrange
            var mock = new Mock<ITourRepository>();
            var mockWebHost = new Mock<IWebHostEnvironment>();
            var controller = new TourController(mock.Object, mockWebHost.Object);

            var tour = new Tour
            {
                Id = 1,
                Duration = 5,
                Title = "Tour 1",
                Hotel = new Hotel(),
                HotelId = 1,
                PhotoUrl = "imagws",
                Price = 10000,
                CustomerRequests = new List<CustomerRequest>(),
                IncludedServices = new List<TravelService>(),
                NotIncludedServices = new List<TravelService>()
            };

            int[] services = new int[3];

            // Act
            var result = await controller.Create(tour, services, services);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.AddAsync(tour, services, services));
        }


        /// <summary>
        /// Метод получения коллекции туров
        /// </summary>
        private List<Tour> GetTestTours()
        {
            var items = new List<Tour>
            {
                new Tour { Id = 1, 
                Duration = 5,
                Title = "Tour 1",
                Hotel = new Hotel(),
                HotelId = 1,
                PhotoUrl = "imagws",
                Price = 10000,
                CustomerRequests = new List<CustomerRequest>(),
                IncludedServices = new List<TravelService>(),
                NotIncludedServices = new List<TravelService>()},
                new Tour { Id = 2,
                Duration = 5,
                Title = "Tour 2",
                Hotel = new Hotel(),
                HotelId = 1,
                PhotoUrl = "imagws",
                Price = 20000,
                CustomerRequests = new List<CustomerRequest>(),
                IncludedServices = new List<TravelService>(),
                NotIncludedServices = new List<TravelService>()}
            };
            return items;
        }
    }
}
