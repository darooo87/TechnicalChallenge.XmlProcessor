namespace TechnicalChallenge.Serializers.GenerationReport.Model.Xml.Generators;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public class CoalGenerator 
{
    public string Name { get; set; }

    [System.Xml.Serialization.XmlArrayItem("Day", IsNullable = true)]
    public DailyGeneratorSummary[] Generation { get; set; }

    public decimal TotalHeatInput { get; set; }

    public decimal ActualNetGeneration { get; set; }

    public decimal EmissionsRating { get; set; }
}
