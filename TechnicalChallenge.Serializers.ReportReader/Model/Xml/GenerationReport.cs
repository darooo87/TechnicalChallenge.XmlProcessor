
namespace TechnicalChallenge.Serializers.GenerationReport.Model.Xml;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
public class GenerationReport
{
    [System.Xml.Serialization.XmlArrayItem("WindGenerator", IsNullable = true)]
    public Generators.WindGenerator[] Wind { get; set; }

    [System.Xml.Serialization.XmlArrayItem("GasGenerator", IsNullable = true)]
    public Generators.GasGenerator[] Gas { get; set; }

    [System.Xml.Serialization.XmlArrayItem("CoalGenerator", IsNullable = true)]
    public Generators.CoalGenerator[] Coal { get; set; }
}

