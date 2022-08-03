namespace TechnicalChallenge.Serializers.GenerationOutput.Model.Xml;

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
public partial class GenerationOutput
{
    [System.Xml.Serialization.XmlArrayItemAttribute("Generator", IsNullable = true)]
    public GenerationOutputGenerator[] Totals { get; set; }

    [System.Xml.Serialization.XmlArrayItemAttribute("Day", IsNullable = true)]
    public GenerationOutputDay[] MaxEmissionGenerators { get; set; }

    public ActualHeatRate[] ActualHeatRates { get; set; }
}