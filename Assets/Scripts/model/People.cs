using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("people")]
public class People
{
    List<Person> person;

    [XmlElement("person")]
    public List<Person> Person
    {
        get
        {
            if (person == null)
            {
                person = new List<Person>();
            }
            return person;
        }
        set => person = value;
    }
}