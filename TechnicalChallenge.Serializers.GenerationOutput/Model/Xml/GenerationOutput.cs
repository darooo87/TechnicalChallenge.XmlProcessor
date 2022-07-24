namespace TechnicalChallenge.Serializers.GenerationOutput.Model.Xml;

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
public partial class GenerationOutput
{

    private GenerationOutputGenerator[] totalsField;

    private GenerationOutputDay[] maxEmissionGeneratorsField;

    private ActualHeatRate[] actualHeatRatesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Generator", IsNullable = true)]
    public GenerationOutputGenerator[] Totals
    {
        get
        {
            return this.totalsField;
        }
        set
        {
            this.totalsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Day", IsNullable = true)]
    public GenerationOutputDay[] MaxEmissionGenerators
    {
        get
        {
            return this.maxEmissionGeneratorsField;
        }
        set
        {
            this.maxEmissionGeneratorsField = value;
        }
    }

    /// <remarks/>
    public ActualHeatRate[] ActualHeatRates
    {
        get
        {
            return this.actualHeatRatesField;
        }
        set
        {
            this.actualHeatRatesField = value;
        }
    }
}