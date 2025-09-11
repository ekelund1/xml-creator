using System.Xml.Serialization;

public class Phone
{
    string mobile;
    string landline;

    [XmlElement("landline")]
    public string Landline { get => landline; set => landline = value; }
    [XmlElement("mobile")]
    public string Mobile { get => mobile; set => mobile = value; }
}