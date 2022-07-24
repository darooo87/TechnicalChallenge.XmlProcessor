using System.Xml.Serialization;
using TechnicalChallenge.Serializers.GenerationReport.Interfaces;

namespace TechnicalChallenge.Serializers.GenerationReport
{
    public class GenerationReportSerializer : IGenerationReportSerializer
    {
        public IGenerationReport Deserialize(string path)
        {
            var serializer = new XmlSerializer(typeof(Model.Xml.GenerationReport));

            using var fileStream = new FileStream(path, FileMode.Open);

            var xmlReport = (Model.Xml.GenerationReport)serializer.Deserialize(fileStream);

            var outputReport = new Model.GenerationReport();

            outputReport.Coal = xmlReport.Coal
                .Select(s => new Model.CoalGenerator
                {
                    Name = s.Name,
                    Generation = s.Generation.Select(s => new Model.DailyGeneratorSummary
                    {
                        Date = s.Date,
                        Energy = s.Energy,
                        Price = s.Price,
                    }).ToArray(),
                    Factor = Model.ValueFactor.Medium,
                    EmissionFactor = Model.EmissionFactor.High,
                    EmmisionRating = s.EmissionsRating,
                    TotalHeatInput = s.TotalHeatInput,
                    ActualNetGeneration = s.ActualNetGeneration,
                }).ToArray();

            outputReport.Gas = xmlReport.Gas.Select(s => new Model.GasGenerator
            {
                Name = s.Name,
                Generation = s.Generation.Select(s => new Model.DailyGeneratorSummary
                {
                    Date = s.Date,
                    Energy = s.Energy,
                    Price = s.Price,
                }).ToArray(),
                Factor = Model.ValueFactor.Medium,
                EmissionFactor= Model.EmissionFactor.Medium,
                EmmisionRating = s.EmissionsRating
            }).ToArray();

            outputReport.OffshoreWind = xmlReport.Wind
                .Where(w => w.Location == "Offshore")
                .Select(s => new Model.WindGenerator
                {
                    Name = s.Name,
                    Location = s.Location,
                    Generation = s.Generation.Select(s => new Model.DailyGeneratorSummary
                    {
                        Date = s.Date,
                        Energy = s.Energy,
                        Price = s.Price,
                    }).ToArray(),
                    Factor = Model.ValueFactor.Low
                }).ToArray();

            outputReport.OnshoreWind = xmlReport.Wind
                .Where(w => w.Location == "Onshore")
                .Select(s => new Model.WindGenerator
                {
                    Name = s.Name,
                    Location = s.Location,
                    Generation = s.Generation.Select(s => new Model.DailyGeneratorSummary
                    {
                        Date = s.Date,
                        Energy = s.Energy,
                        Price = s.Price,
                    }).ToArray(),
                    Factor = Model.ValueFactor.High
                }).ToArray();

            return outputReport;
        }
    }
}
