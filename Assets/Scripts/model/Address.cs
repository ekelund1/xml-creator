
using System.Xml.Serialization;

public class Address
{
    string street;
    string city;
    string postalCode;

    [XmlElement("street")]
    public string Street { get => street; set => street = value; }
    
    [XmlElement("city")]
    public string City { get => city; set => city = value; }

    [XmlElement("postalcode")]
    public string PostalCode { get => postalCode; set => postalCode = value; }
}