namespace TechnicalChallenge.Serializers.GenerationOutput.Model.Xml;

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class GenerationOutputDay
{
    public string Name { get; set; }
    
    public System.DateTime Date { get; set; }

    public decimal Emission { get; set; }
}

