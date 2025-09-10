using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SofthouseXML;
using System;
using System.Linq;

public class PersonMapperTest
{

    [Test]
    public void ThrowOnInvalidInput()
    {
        string input = "B|a";

        Assert.Throws<Exception>(() => PersonMapper.SerializePerson(input));
    }


    [Test]
    public void OnlyPerson()
    {
        string input = "P|förnamn|efternamn";

        var person = PersonMapper.SerializePerson(input);

        Assert.AreEqual("förnamn", person.FirstName);
        Assert.AreEqual("efternamn", person.LastName);
        Assert.IsNull(person.Phone);
        Assert.IsNull(person.Address);
        Assert.IsEmpty(person.Family);
    }
}
