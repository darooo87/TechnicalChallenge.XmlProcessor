namespace TechnicalChallenge.Serializers.GenerationOutput.Model.Xml;

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class GenerationOutputDay
{

    private string nameField;

    private System.DateTime dateField;

    private decimal emissionField;

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
    public System.DateTime Date
    {
        get
        {
            return this.dateField;
        }
        set
        {
            this.dateField = value;
        }
    }

    /// <remarks/>
    public decimal Emission
    {
        get
        {
            return this.emissionField;
        }
        set
        {
            this.emissionField = value;
        }
    }
}

