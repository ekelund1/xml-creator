using System.Collections.Generic;

public class Person
{
    string firstName;
    string lastName;
    Address address;
    List<Family> family;
    Phone phone;

    public string FirstName { get => firstName; set => firstName = value; }
    public string LastName { get => lastName; set => lastName = value; }
    public Address Address { get => address; set => address = value; }
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