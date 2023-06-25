using TravelAgency.Data.ViewModels;

namespace TravelAgency.Analystics
{
    public class ClusteredAnalyticsViewModel
    {
        public uint Cluster { get; set; }
        public List<AnalyticsViewModel> Tours { get; set; }
        public string Color { get; set; }
    }
}
