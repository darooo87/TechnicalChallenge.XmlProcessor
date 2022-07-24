namespace TechnicalChallenge.Serializers.GenerationReport.Interfaces;

public interface IGenerationReportSerializer
{
    public IGenerationReport Deserialize(string path);
}
