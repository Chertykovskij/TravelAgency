using Microsoft.ML.Data;
using Microsoft.ML;

namespace TravelAgency.Analystics
{
    public class TourInput
    {
        [LoadColumn(0)]
        [ColumnName("Price")]
        public float Price { get; set; }

        [LoadColumn(1)]
        [ColumnName("Duration")]
        public float Duration { get; set; }

        [LoadColumn(2)]
        [ColumnName("Stars")]
        public float Stars { get; set; }

        [LoadColumn(3)]
        [ColumnName("MealType")]
        public float MealType { get; set; }
    }
}
