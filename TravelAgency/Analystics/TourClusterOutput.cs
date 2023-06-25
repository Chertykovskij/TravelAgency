using Microsoft.ML.Data;
using Microsoft.ML;

namespace TravelAgency.Analystics
{
    public class TourClusterOutput
    {
        [ColumnName("PredictedLabel")] 
        public uint ClusterId { get; set; }
    }
}
