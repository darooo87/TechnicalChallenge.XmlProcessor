namespace TechnicalChallenge.Serializers.GenerationOutput.Interfaces;

public interface IGeneratorMaxDayEmission
{
    public string Name { get; set; }

    public DateTime Date { get; set; }

    public decimal Emission { get; set; }
}
