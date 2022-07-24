using TechnicalChallenge.Serializers.GenerationOutput.Interfaces;

namespace TechnicalChallenge.Serializers.GenerationOutput.Model;

public class GeneratorMaxDayEmission : IGeneratorMaxDayEmission
{
    public string Name { get; set; }

    public DateTime Date { get; set; }

    public decimal Emission { get; set; }
}
