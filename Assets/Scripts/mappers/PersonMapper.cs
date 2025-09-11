using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PersonMapper
{
    public static Person SerializePerson(string input)
    {
        if (!input.StartsWith("P"))
        {
            throw new Exception("PersonMapper input börjar inte på P");
        }

        List<string> split = input.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

        Person person = new Person();

        if (split.ElementAtOrDefault(1) != null)
        {
            person.FirstName = split.ElementAtOrDefault(1);
        }
        if (split.ElementAtOrDefault(2) != null)
        {
            person.LastName = split.ElementAtOrDefault(2);
        }

        Debug.Log($"PersonMapper created new Person");

        return person;
    }
    
}