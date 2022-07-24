namespace TechnicalChallenge.Serializers.GenerationReport.Model.Xml;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public class DailyGeneratorSummary
{
    public DateTime Date { get; set; }

    public decimal Energy { get; set; }

    public decimal Price { get; set; }
}
