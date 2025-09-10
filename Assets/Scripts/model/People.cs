using System.Collections.Generic;

public class People
{
    List<Person> personList = new List<Person>();

    public List<Person> PersonList { get => personList; set => personList = value; }
}