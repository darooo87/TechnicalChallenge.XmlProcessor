using TechnicalChallenge.Serializers.GenerationReport.Model;

namespace TechnicalChallenge.Serializers.GenerationReport.Interfaces;

public interface IGenerator
{
    public string Name { get; set; }

    public IDailyGeneratorSummary[] Generation { get; set; }

    public ValueFactor Factor { get; set; }
}
