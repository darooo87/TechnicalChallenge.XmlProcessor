using System.Xml.Serialization;
using TechnicalChallenge.Serializers.GenerationOutput.Interfaces;

namespace TechnicalChallenge.Serializers.GenerationOutput
{
    public class GenerationOutputSerializer : IGenerationOutputSerializer
    {
        public void Serialize(string path,
            IGeneratorTotal[] generatorTotals,
            IGeneratorMaxDayEmission[] generatorMaxDayEmissions,
            IGeneratorHeatRate[] generatorHeatRates)
        {
            var serializer = new XmlSerializer(typeof(Model.Xml.GenerationOutput));

            var writer = new StreamWriter(path);

            var outputReport = new Model.Xml.GenerationOutput();

            outputReport.Totals = generatorTotals.Select(s => new Model.Xml.GenerationOutputGenerator
            {
                Name = s.Name,
                Total = s.Total,
            }).ToArray();

            outputReport.MaxEmissionGenerators = generatorMaxDayEmissions.Select(s => new Model.Xml.GenerationOutputDay
            {
                Name = s.Name,
                Date = s.Date,
                Emission = s.Emission,
            }).ToArray();

            outputReport.ActualHeatRates = generatorHeatRates.Select(s => new Model.Xml.ActualHeatRate
            {
                Name = s.Name,
                HeatRate = s.HeatRate
            }).ToArray();

            serializer.Serialize(writer, outputReport);

            writer.Close();
        }
    }
}