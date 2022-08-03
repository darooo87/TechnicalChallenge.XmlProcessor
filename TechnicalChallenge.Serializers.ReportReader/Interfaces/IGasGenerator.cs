namespace TechnicalChallenge.Serializers.GenerationReport.Interfaces;

public interface IGasGenerator : IFossilFuelGenerator
{
    public string Location { get; set; }
}
