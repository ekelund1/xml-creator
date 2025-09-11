using System.Xml.Serialization;

public class Family
{
    private string name;
    private string born;
    private Address address;
    private Phone phone;

    [XmlElement("name")]
    public string Name { get => name; set => name = value; }

    [XmlElement("born")]
    public string Born { get => born; set => born = value; }

    [XmlElement("address")]
    public Address Address { get => address; set => address = value; }
    
    [XmlElement("phone")]
    public Phone Phone { get => phone; set => phone = value; }
}