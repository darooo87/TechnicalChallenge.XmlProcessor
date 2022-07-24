using TechnicalChallenge.Serializers.GenerationOutput.Interfaces;
using TechnicalChallenge.Serializers.GenerationReport.Interfaces;
using TechnicalChallenge.Serializers.ReferenceData.Interfaces;

namespace TechnicalChallenge.XmlProcessor.Interfaces;

public interface IDataProcessor
{
    public IGeneratorTotal[] GetReportTotals(IGenerationReport generationReport, IReferenceData referenceData);

    public IGeneratorMaxDayEmission[] GetMaxDayEmissions(IGenerationReport generationReport, IReferenceData referenceData);

    public IGeneratorHeatRate[] GetGeneratorHeatRates(IGenerationReport generationReport);

}
