using TechnicalChallenge.Serializers.GenerationOutput.Interfaces;

namespace TechnicalChallenge.Serializers.GenerationOutput.Model;

public class GeneratorTotal : IGeneratorTotal
{
    public string Name { get; set; }

    public decimal Total { get; set; }
}
