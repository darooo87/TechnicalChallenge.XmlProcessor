using System.Xml.Serialization;
using TechnicalChallenge.Serializers.ReferenceData.Interfaces;

namespace TechnicalChallenge.Serializers.ReferenceData;

public class ReferenceDataSerializer : IReferenceDataSerializer
{
    public IReferenceData Deserialize(string path)
    {
        var serializer = new XmlSerializer(typeof(Model.Xml.ReferenceData));

        using var fileStream = new FileStream(path, FileMode.Open);

        var referenceData = (Model.Xml.ReferenceData)serializer.Deserialize(fileStream);

        return new Model.ReferenceData
        {
            ValueFactors = new Dictionary<string, decimal>()
            {
                { "Low", referenceData.Factors.ValueFactor.Low },
                { "Medium", referenceData.Factors.ValueFactor.Medium },
                { "High", referenceData.Factors.ValueFactor.High },
            },
            EmissionsFactors = new Dictionary<string, decimal>()
            {
                { "Low", referenceData.Factors.EmissionsFactor.Low },
                { "Medium", referenceData.Factors.EmissionsFactor.Medium },
                { "High", referenceData.Factors.EmissionsFactor.High },
            }
        };
    }
}
