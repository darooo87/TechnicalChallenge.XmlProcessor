
namespace TechnicalChallenge.Serializers.GenerationReport.Interfaces;

public interface IGenerationReport
{
    public IWindGenerator[] OffshoreWind { get; set; }

    public IWindGenerator[] OnshoreWind { get; set; }

    public IGasGenerator[] Gas { get; set; }

    public ICoalGenerator[] Coal { get; set; }
}

