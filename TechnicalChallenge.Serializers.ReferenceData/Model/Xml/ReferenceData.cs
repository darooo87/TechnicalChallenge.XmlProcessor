namespace TechnicalChallenge.Serializers.ReferenceData.Model.Xml;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
public partial class ReferenceData
{
    public Factors Factors { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public partial class Factors
{
    public ValueFactor ValueFactor { get; set; }

    public EmmisionsFactor EmissionsFactor { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public partial class ValueFactor
{
    public decimal High { get; set; }

    public decimal Medium { get; set; }

    public decimal Low { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public partial class EmmisionsFactor
{
    public decimal High { get; set; }

    public decimal Medium { get; set; }

    public decimal Low { get; set; }
}

