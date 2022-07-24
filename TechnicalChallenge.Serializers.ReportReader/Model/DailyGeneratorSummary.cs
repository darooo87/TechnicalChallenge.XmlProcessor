using TechnicalChallenge.Serializers.GenerationReport.Interfaces;

namespace TechnicalChallenge.Serializers.GenerationReport.Model;

public class DailyGeneratorSummary : IDailyGeneratorSummary
{
    public DateTime Date { get; set; }

    public decimal Energy { get; set; }

    public decimal Price { get; set; }
}
