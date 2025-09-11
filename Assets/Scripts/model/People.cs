using System.Collections.Generic;

public class People
{
    List<Person> person;

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