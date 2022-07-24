namespace TechnicalChallenge.Serializers.GenerationReport.Interfaces;

public interface IDailyGeneratorSummary
{
    public DateTime Date { get; set; }

    public decimal Energy { get; set; }

    public decimal Price { get; set; }

}
