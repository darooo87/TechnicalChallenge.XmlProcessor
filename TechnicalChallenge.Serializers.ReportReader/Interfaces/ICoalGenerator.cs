namespace TechnicalChallenge.Serializers.GenerationReport.Interfaces;

public interface ICoalGenerator : IGenerator, IFossilFuelGenerator
{
    public string Location { get; set; }

    public decimal TotalHeatInput { get; set; }

    public decimal ActualNetGeneration { get; set; }
}
