namespace TechnicalChallenge.Serializers.ReferenceData.Interfaces;

public interface IReferenceDataSerializer
{
    public IReferenceData Deserialize(string path);
}
