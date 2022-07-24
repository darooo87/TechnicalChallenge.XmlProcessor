using TechnicalChallenge.Serializers.GenerationReport.Interfaces;

namespace TechnicalChallenge.Serializers.GenerationReport.Model;

public class WindGenerator : IWindGenerator
{
    public string Location { get; set; }

    public string Name { get; set; }

    public IDailyGeneratorSummary[] Generation { get; set; }

    public ValueFactor Factor { get; set; }
}
