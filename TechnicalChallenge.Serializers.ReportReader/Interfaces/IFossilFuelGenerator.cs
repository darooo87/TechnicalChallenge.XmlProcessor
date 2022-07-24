using TechnicalChallenge.Serializers.GenerationReport.Model;

namespace TechnicalChallenge.Serializers.GenerationReport.Interfaces;

public interface IFossilFuelGenerator : IGenerator
{
    public decimal EmmisionRating { get; set; }

    public EmissionFactor EmissionFactor { get; set; }
}
