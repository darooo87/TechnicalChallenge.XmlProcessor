
namespace TechnicalChallenge.Serializers.GenerationReport.Model.Xml.Generators;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public class WindGenerator 
{
    public string Name { get; set; }
    
    [System.Xml.Serialization.XmlArrayItem("Day", IsNullable = false)]
    public DailyGeneratorSummary[] Generation { get; set; }

    public string Location { get; set; }
}

