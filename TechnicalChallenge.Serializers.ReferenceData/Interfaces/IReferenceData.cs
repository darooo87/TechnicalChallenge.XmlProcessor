namespace TechnicalChallenge.Serializers.ReferenceData.Interfaces;

public interface IReferenceData
{
    public IDictionary<string, decimal> ValueFactors { get; set; }

    public IDictionary<string, decimal> EmissionsFactors { get; set; }
}
