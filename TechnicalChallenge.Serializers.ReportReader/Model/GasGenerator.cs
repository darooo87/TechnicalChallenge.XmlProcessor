using TechnicalChallenge.Serializers.GenerationReport.Interfaces;

namespace TechnicalChallenge.Serializers.GenerationReport.Model;

public class GasGenerator : IGasGenerator
{
    public string Location { get; set; }

    public string Name { get; set; }

    public IDailyGeneratorSummary[] Generation { get; set; }

    public ValueFactor Factor { get; set; }

    public EmissionFactor EmissionFactor { get; set; }

    public decimal EmmisionRating { get; set; }
}