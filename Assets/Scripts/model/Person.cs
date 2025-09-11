using System.Collections.Generic;
using System.Xml.Serialization;

public class Person
{
    string firstName;
    string lastName;
    Address address;
    List<Family> family;
    Phone phone;

    [XmlElement("firstname")]
    public string FirstName { get => firstName; set => firstName = value; }

    [XmlElement("lastname")]
    public string LastName { get => lastName; set => lastName = value; }

    [XmlElement("address")]
    public Address Address { get => address; set => address = value; }

    [XmlElement("family")]
    public List<Family> Family
    {
        get
        {
            if (family == null)
            {
                family = new List<Family>();
            }
            return family;
        }
        set => family = value;
    }
    public Phone Phone { get => phone; set => phone = value; }
}