using TechnicalChallenge.Serializers.GenerationOutput.Interfaces;
using TechnicalChallenge.Serializers.GenerationOutput.Model;
using TechnicalChallenge.Serializers.GenerationReport.Interfaces;
using TechnicalChallenge.Serializers.ReferenceData.Interfaces;
using TechnicalChallenge.XmlProcessor.Interfaces;

namespace TechnicalChallenge.XmlProcessor.Utils
{
    public class DataProcessor : IDataProcessor
    {
        public IGeneratorTotal[] GetReportTotals(IGenerationReport generationReport, IReferenceData referenceData)
        {
            if (generationReport == null)
                return null;

            var generators = new List<IGenerator>();

            generators.AddRange(generationReport.OnshoreWind ?? new IWindGenerator[0]);
            generators.AddRange(generationReport.OffshoreWind ?? new IWindGenerator[0]);
            generators.AddRange(generationReport.Coal ?? new ICoalGenerator[0]);
            generators.AddRange(generationReport.Gas ?? new IGasGenerator[0]);

            return generators
                .Select(s => new GeneratorTotal
                {
                    Name = s.Name,
                    Total = s.Generation.Sum(g => g.Energy * g.Price * referenceData.ValueFactors[s.Factor.ToString()]),
                }).ToArray();
        }

        public IGeneratorMaxDayEmission[] GetMaxDayEmissions(IGenerationReport generationReport, IReferenceData referenceData)
        {
            var fossilFuelGenerators = new List<IFossilFuelGenerator>();

            fossilFuelGenerators.AddRange(generationReport.Coal);
            fossilFuelGenerators.AddRange(generationReport.Gas);

            return fossilFuelGenerators
                .Select(s => new
                {
                    Name = s.Name,
                    s.EmmisionRating,
                    Daily = s.Generation.Select(g => new
                    {
                        Date = g.Date,
                        DailyEmissions = g.Energy * s.EmmisionRating * referenceData.EmissionsFactors[s.EmissionFactor.ToString()]
                    })
                }).SelectMany(p => p.Daily, (p, c) => new GeneratorMaxDayEmission
                {
                    Name = p.Name,
                    Date = c.Date,
                    Emission = c.DailyEmissions
                }).GroupBy(g => g.Date)
                  .Select(s => s.OrderByDescending(o => o.Emission).FirstOrDefault())
                  .ToArray();
        }

        public IGeneratorHeatRate[] GetGeneratorHeatRates(IGenerationReport generationReport)
        {
            var coalGenerators = new List<ICoalGenerator>();

            coalGenerators.AddRange(generationReport.Coal);

            return coalGenerators
                .Select(s => new GeneratorHeatRate
                {
                    Name = s.Name,
                    HeatRate = s.TotalHeatInput / s.ActualNetGeneration
                })
                .ToArray();
        }
    }
}
