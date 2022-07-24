namespace TechnicalChallenge.Serializers.GenerationReport.Interfaces;

public interface IGasGenerator : IGenerator, IFossilFuelGenerator
{
    public string Location { get; set; }
}
