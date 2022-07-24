using TechnicalChallenge.Serializers.GenerationReport.Interfaces;

namespace TechnicalChallenge.Serializers.GenerationReport.Model;

public class GenerationReport : IGenerationReport
{
    public IWindGenerator[] OffshoreWind { get; set; }

    public IWindGenerator[] OnshoreWind { get; set; }

    public IGasGenerator[] Gas { get; set; }

    public ICoalGenerator[] Coal { get; set; }
}
