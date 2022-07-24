namespace TechnicalChallenge.Serializers.GenerationOutput.Interfaces;

public interface IGenerationOutputSerializer
{
    public void Serialize(
        string path, 
        IGeneratorTotal[] generatorTotals, 
        IGeneratorMaxDayEmission[] generatorMaxDayEmissions, 
        IGeneratorHeatRate[] generatorHeatRates);
}
