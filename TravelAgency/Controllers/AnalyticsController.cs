using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using TravelAgency.Analystics;
using TravelAgency.Data;
using TravelAgency.Data.ViewModels;

namespace TravelAgency.Controllers
{
    [Authorize]
    public class AnalyticsController : Controller
    {
        private readonly TravelAgencyContext _context;

        public AnalyticsController(TravelAgencyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.Tours
                                        .Include(h => h.Hotel)
                                            .ThenInclude(s => s.HotelStarRating)
                                        .Include(h => h.Hotel)
                                            .ThenInclude(s => s.MealType)
                                        .Include(r => r.CustomerRequests)
                                        .OrderByDescending(t => t.CustomerRequests.Count)
                                        .ToListAsync();

            List<AnalyticsViewModel> results = new List<AnalyticsViewModel>();

            foreach (var item in items)
            {
                results.Add(new AnalyticsViewModel
                {
                    NameTour = item.Title,
                    PriceTour = item.Price,
                    DurationTour = item.Duration,
                    NameHotel = item.Hotel.Name,
                    StarRating = item.Hotel.HotelStarRating.Stars,
                    MealType = item.Hotel.MealType.Id,
                    MealTypeString = item.Hotel.MealType.Type,
                    Count = item.CustomerRequests.Count
                });
            }


            // Создаем контекст ML.NET
            var context = new MLContext();

            // Преобразуем данные о товарах во входные данные алгоритма кластеризации
            var data = context.Data.LoadFromEnumerable(results.Select(p => new TourInput() 
            { 
                Price = (float)p.PriceTour,
                Duration = (float)p.DurationTour,
                MealType = (float)p.MealType,
                Stars = (float)p.StarRating
            }));

            // Определяем параметры алгоритма кластеризации
            var options = new KMeansTrainer.Options() { NumberOfClusters = 3 };

            // Создаем модель на основе данных и параметров
            var pipeline = context.Transforms
                .Concatenate("Features", "Price", "Duration", "Stars", "MealType")
                .Append(context.Clustering.Trainers.KMeans(options));

            var model = pipeline.Fit(data);

            // Применяем модель к данным и получаем выходные данные
            var tourClusters = model.Transform(data).GetColumn<uint>("PredictedLabel");
            

            // Группируем результаты по кластерам
            var groupedResults = results.Select((t, i) => new { value = t, cluster = tourClusters.ElementAt(i) })
                                        .GroupBy(x => x.cluster)
                                        .Select(g => new ClusteredAnalyticsViewModel
                                        {
                                            Cluster = g.Key,
                                            Tours = g.Select(x => x.value).ToList()
                                        })
                                        .ToList();

            // Задаем цвета для кластеров
            var colors = new List<string> { "blue", "red", "green" };

            // Задаем цвет для каждого кластера
            for (int i = 0; i < groupedResults.Count; i++)
            {
                groupedResults[i].Color = colors[i];
            }

            return View(groupedResults);


        }
    }
}
