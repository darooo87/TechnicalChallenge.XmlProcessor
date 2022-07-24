namespace TechnicalChallenge.Serializers.GenerationOutput.Model.Xml;

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ActualHeatRate
{

    private string nameField;

    private decimal heatRateField;

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public decimal HeatRate
    {
        get
        {
            return this.heatRateField;
        }
        set
        {
            this.heatRateField = value;
        }
    }
}

