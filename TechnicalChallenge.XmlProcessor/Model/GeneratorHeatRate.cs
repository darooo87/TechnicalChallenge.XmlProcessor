using TechnicalChallenge.Serializers.GenerationOutput.Interfaces;

namespace TechnicalChallenge.Serializers.GenerationOutput.Model;

public class GeneratorHeatRate : IGeneratorHeatRate
{
    public string Name { get; set; }

    public decimal HeatRate { get; set; }
}
