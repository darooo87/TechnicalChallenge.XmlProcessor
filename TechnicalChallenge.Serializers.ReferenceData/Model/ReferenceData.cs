using TechnicalChallenge.Serializers.ReferenceData.Interfaces;

namespace TechnicalChallenge.Serializers.ReferenceData.Model;

public class ReferenceData : IReferenceData
{
    public IDictionary<string, decimal> ValueFactors { get; set; }

    public IDictionary<string, decimal> EmissionsFactors { get; set; }
}
